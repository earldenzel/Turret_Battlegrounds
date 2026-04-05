using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float thrustForce;
    public float rotationSpeed;
    public float backLimit;

    public GameObject bullet;
    public Transform tankBarrel;
    public GameObject generator;
    public GameObject electricity;
    public Text message;
    public Text playerInfo;

    private Rigidbody2D rb;
    private float multiplier;
    private bool onSecret;
    private DestroyByBullet hpvalues;
    private GameObject boss;
    
    //Time delay for shooting
    public float nextFire = 0.5f;
    private float myTime = 0.0f;
    private float elapsedTime = 0.0f;

    private int powerup; 
    [SerializeField] float minPitch = 0.4f;
	[SerializeField] float maxPitch = 2.5f;
	[SerializeField] float maxSpeed = 10f;
	[SerializeField] float stopThreshold = 0.1f;
	[SerializeField] float pitchSmoothSpeed = 5f;
	[SerializeField] float volumeSmoothSpeed = 3f;
	[SerializeField] float maxVolumeSpeed = 3f;  // speed at which volume maxes out
	[SerializeField] float idleVolume = 0.3f;  // volume when stopped
	[SerializeField] float maxVolume = 1f;      // volume at max speed

	//Audio settings added as part of EECS4482
    public AudioClip tankSoundClip;
    public AudioClip bgmEarlyGame;
    public AudioClip bgmMidGame;
    public AudioClip bgmBossBattle;

    // Dialogue audio clips from Assets/Dialogue folder
    public AudioClip[] dialogueClips;

	private AudioSource tankSource;
    private AudioSource bgmSource;
    private AudioSource dialogueSource;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        onSecret = false;
        powerup = 0;
        hpvalues = GameObject.FindGameObjectWithTag("Player").GetComponent<DestroyByBullet>();
        boss = GameObject.FindGameObjectWithTag("Boss");
        ShowTankInfo();
        StartCoroutine(SetMessage("Press W/S to move\nPress A/D to steer\nClick mouse to fire bullet!"));

        //vehicle sounds audio source
        tankSource = gameObject.AddComponent<AudioSource>();
        tankSource.clip = tankSoundClip;
		tankSource.loop = true;
		tankSource.playOnAwake = true;
		tankSource.Play();

        // BGM AudioSource
        bgmSource = gameObject.AddComponent<AudioSource>();
        bgmSource.clip = bgmEarlyGame;
        bgmSource.loop = true;
        bgmSource.playOnAwake = true;
        bgmSource.volume = 0.5f;

        bgmSource.Play();

        // Dialogue AudioSource
        dialogueSource = gameObject.AddComponent<AudioSource>();
        dialogueSource.loop = false;
        dialogueSource.playOnAwake = false;

        // Play dialogue 15 after a few seconds
        StartCoroutine(PlayDialogueDelayed(3f, 15));
	}

    void Update()
    {

        DetermineTankSound();

		myTime += Time.deltaTime;
        if (boss != null) elapsedTime += Time.deltaTime;

        if (Input.GetButton("Fire1") && (myTime > nextFire) && (GetComponent<Renderer>().enabled == true))
        {
            Instantiate(bullet, tankBarrel.position, tankBarrel.rotation);
            myTime = 0.0f;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

	void FixedUpdate ()
    {
        ShowTankInfo();
        // Thrust the tank if necessary. Pressing the reverse key will use backLimit which should be between 0 and 1.
        // To simulate tank heaviness, please tweak linear drag and angular drag settings
        if (GetComponent<Renderer>().enabled == true)
        {
            if (Input.GetAxis("Vertical") < 0)
            {
                multiplier = backLimit * Input.GetAxis("Vertical");
            }
            else
            {
                multiplier = Input.GetAxis("Vertical");
            }
            rb.AddForce(transform.up * thrustForce * multiplier);

            // Rotate the tank if necessary
            transform.Rotate(0, 0, -Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime);

            //First teleport map.
            if (transform.position.y > 49 && transform.position.y < 50 && transform.position.x > 0 && transform.position.x < 4)
            {
                transform.position = new Vector3(transform.position.x + 7, transform.position.y - 23);
                bgmSource.clip = bgmMidGame;
                bgmSource.Play();
                PlayDialogue(16);
            }

            //Second teleport map. To secret area.
            if (transform.position.y > 52 && transform.position.y < 54 && transform.position.x > 0 && transform.position.x < 1 && !onSecret)
            {
                transform.position = new Vector3(transform.position.x + 18, transform.position.y - 5);
            }
            if (transform.position.y > 47 && transform.position.y < 49 && transform.position.x > 15 && transform.position.x < 18 && !onSecret)
            {
                onSecret = true;
            }
            if (transform.position.y > 47 && transform.position.y < 49 && transform.position.x > 18 && transform.position.x < 19 && onSecret)
            {
                transform.position = new Vector3(8.5f, 51.5f);
                onSecret = false;
            }

            //Last teleport map to boss.
            if (transform.position.y > 71 && transform.position.y < 74 && transform.position.x > 18 && transform.position.x < 19)
            {
                transform.position = new Vector3(transform.position.x - 18, transform.position.y + 10);
                bgmSource.clip = bgmBossBattle;
                bgmSource.Play();
                PlayDialogue(17);

                Instantiate(generator, new Vector3(9.5f, 83.5f), Quaternion.Euler(0, 0, 180));                
                Instantiate(electricity, new Vector3(9.5f, 82.5f), Quaternion.identity);
                Instantiate(electricity, new Vector3(9.5f, 81.5f), Quaternion.identity);
                Instantiate(electricity, new Vector3(9.5f, 80.5f), Quaternion.identity);
                Instantiate(electricity, new Vector3(9.5f, 79.5f), Quaternion.identity);
                Instantiate(electricity, new Vector3(9.5f, 78.5f), Quaternion.identity);
                Instantiate(electricity, new Vector3(9.5f, 77.5f), Quaternion.identity);
                Instantiate(electricity, new Vector3(9.5f, 76.5f), Quaternion.identity);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb.linearVelocity = Vector2.zero;
    }

    public void AddPowerUp()
    {
        powerup++;

        switch (powerup)
        {
            case 1:
            case 2:
            case 4:
            case 5:
            case 6:
            case 8:
            case 9:
            case 11:
                hpvalues.maxhp += 1;
                hpvalues.hitsToKill = hpvalues.maxhp;
                StartCoroutine(SetMessage("HP UP!"));
                break;
            case 3:
            case 7:
            case 10:
            case 12:
            case 13:
                nextFire -= 0.05f;
                StartCoroutine(SetMessage("Fire speed UP!"));
                break;
            default:
                break;
        }
        PlayDialogue(12, 13, 14, 6, 7, 8);
    }

    public IEnumerator SetMessage(string text)
    {
        message.text = text;
        yield return new WaitForSeconds(3);
        message.text = "";
    }

    void ShowTankInfo()
    {
        string text = "";
        text += "LIFE: [ " + hpvalues.hitsToKill + " / " + hpvalues.maxhp + "]";
        text += string.Format("\nTIME: {0:f2} seconds", elapsedTime);

        if (boss == null)
        {            
            text += "\nGAME OVER! YOU WIN!";
            PlayDialogue(18);
        }
        playerInfo.text = text;
    }

	void DetermineTankSound()
	{
		float speedMagnitude = rb.linearVelocity.magnitude;

		// Pitch: more dramatic range based on speed
		float pitchT = Mathf.Clamp01(speedMagnitude / maxSpeed);
		float targetPitch = Mathf.Lerp(minPitch, maxPitch, pitchT);

		// Volume: reaches max at maxVolumeSpeed
		float volumeT = Mathf.Clamp01(speedMagnitude / maxVolumeSpeed);
		float targetVolume = speedMagnitude > stopThreshold ?
			Mathf.Lerp(idleVolume, maxVolume, volumeT) : idleVolume;

		tankSource.pitch = Mathf.Lerp(tankSource.pitch, targetPitch, Time.deltaTime * pitchSmoothSpeed);
		tankSource.volume = Mathf.Lerp(tankSource.volume, targetVolume, Time.deltaTime * volumeSmoothSpeed);

	}

    public float PlayDialogue(int clipIndex)
    {
        float delay = 0;
        if (dialogueSource != null && dialogueClips != null && clipIndex >= 0 && clipIndex < dialogueClips.Length && dialogueClips[clipIndex] != null)
        {
            // Lower other audio sources by 50%
            tankSource.volume *= 0.5f;
            bgmSource.volume *= 0.5f;

            dialogueSource.clip = dialogueClips[clipIndex];
            dialogueSource.Play();

            // Restore volumes after dialogue finishes
            StartCoroutine(RestoreAudioVolumes(dialogueClips[clipIndex].length));
            delay = dialogueClips[clipIndex].length;
        }
        return delay;
    }

    private IEnumerator RestoreAudioVolumes(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Restore volumes back to normal (multiply by 2 to undo the 0.5 reduction)
        tankSource.volume *= 2f;
        bgmSource.volume *= 2f;
    }

    public float PlayDialogue(params int[] clipIndices)
    {
        if (clipIndices != null && clipIndices.Length > 0)
        {
            int randomIndex = clipIndices[Random.Range(0, clipIndices.Length)];
            return PlayDialogue(randomIndex);
        }
        return 0;
    }

    private IEnumerator PlayDialogueDelayed(float delay, int clipIndex)
    {
        yield return new WaitForSeconds(delay);
        PlayDialogue(clipIndex);
    }
}
