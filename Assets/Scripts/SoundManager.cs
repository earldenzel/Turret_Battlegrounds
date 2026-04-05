using UnityEngine;
using System.Collections.Generic;

public static class SoundManager
{
    private static Queue<GameObject> audioPool = new Queue<GameObject>();
    private const int poolSize = 20;
    private static bool poolInitialized = false;

    private const float pitchRandomMin = 0.65f;
    private const float pitchRandomMax = 1.25f;
    private const float volumeRandomMin = 0.95f;
    private const float volumeRandomMax = 1.05f;

    private static void InitializePool()
    {
        if (poolInitialized) return;

        GameObject poolContainer = new GameObject("AudioSourcePool");
        for (int i = 0; i < poolSize; i++)
        {
            GameObject soundObj = new GameObject("PooledAudioSource");
            soundObj.transform.SetParent(poolContainer.transform);
            var source = soundObj.AddComponent<AudioSource>();
            var reverb = soundObj.AddComponent<AudioReverbFilter>();
            soundObj.SetActive(false);
            audioPool.Enqueue(soundObj);
        }
        poolInitialized = true;
    }

    private static GameObject GetAudioSource()
    {
        InitializePool();
        
        if (audioPool.Count > 0)
        {
            GameObject soundObj = audioPool.Dequeue();
            soundObj.SetActive(true);
            AudioSource source = soundObj.GetComponent<AudioSource>();
            source.Stop();
            source.clip = null;
            source.pitch = 1f;
            source.volume = 1f;
            return soundObj;
        }
        else
        {
            // Create new one if pool is exhausted
            GameObject soundObj = new GameObject("PooledAudioSource");
            var source = soundObj.AddComponent<AudioSource>();
            var reverb = soundObj.AddComponent<AudioReverbFilter>();
            return soundObj;
        }
    }

    private static void ReturnAudioSource(GameObject soundObj, float delay)
    {
        // Schedule return to pool
        MonoBehaviour mono = soundObj.GetComponent<MonoBehaviour>();
        if (mono == null)
        {
            // Use a simple coroutine starter
            var returnRoutine = ReturnToPoolDelayed(soundObj, delay);
            CoroutineRunner.Instance.StartCoroutine(returnRoutine);
        }
    }

    private static System.Collections.IEnumerator ReturnToPoolDelayed(GameObject soundObj, float delay)
    {
        yield return new WaitForSeconds(delay);
        AudioSource source = soundObj.GetComponent<AudioSource>();
        source.Stop();
        source.clip = null;
        soundObj.SetActive(false);
        audioPool.Enqueue(soundObj);
    }

    public static void Play3DSound(AudioClip clip, Vector2 position, float volume = 1f, float maxDist = 10f, float spatialBlend = 1f)
    {
        if (clip == null) return;

        GameObject soundObj = GetAudioSource();
        AudioListener listener = Object.FindAnyObjectByType<AudioListener>();
        float listenerZ = listener ? listener.transform.position.z : 0f;
        soundObj.transform.position = new Vector3(position.x, position.y, listenerZ);

        AudioSource source = soundObj.GetComponent<AudioSource>();
        source.clip = clip;
        source.pitch = Random.Range(pitchRandomMin, pitchRandomMax);
        source.volume = Mathf.Clamp01(volume * Random.Range(volumeRandomMin, volumeRandomMax));
        source.spatialBlend = spatialBlend;  
        source.rolloffMode = AudioRolloffMode.Logarithmic; 
        source.minDistance = 1f;              
        source.maxDistance = maxDist;         
        source.dopplerLevel = 0f;            

        var reverbFilter = soundObj.GetComponent<AudioReverbFilter>();
        reverbFilter.reverbPreset = AudioReverbPreset.Generic;
        reverbFilter.reverbLevel = -6000;

        source.Play();
        
        ReturnAudioSource(soundObj, clip.length + 0.1f);
    }
}
