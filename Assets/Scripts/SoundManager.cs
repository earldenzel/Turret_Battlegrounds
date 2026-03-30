using UnityEngine;

public static class SoundManager
{
    public static void Play3DSound(AudioClip clip, Vector2 position, float volume = 1f, float maxDist = 20f, float spatialBlend = 1f)
    {
        GameObject soundObj = new GameObject("Temp3DSound");
        AudioListener listener = Object.FindObjectOfType<AudioListener>();
        float listenerZ = listener ? listener.transform.position.z : 0f;
        soundObj.transform.position = new Vector3(position.x, position.y, listenerZ);
        AudioSource source = soundObj.AddComponent<AudioSource>();
        source.clip = clip;
        source.volume = volume;
        source.spatialBlend = spatialBlend;  
        source.rolloffMode = AudioRolloffMode.Logarithmic; 
        source.minDistance = 1f;              
        source.maxDistance = maxDist;         
        source.dopplerLevel = 0f;            

        source.Play();

        Object.Destroy(soundObj, clip.length);
    }
}
