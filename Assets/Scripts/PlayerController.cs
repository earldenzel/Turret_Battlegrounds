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

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        onSecret = false;
        powerup = 0;
        hpvalues = GameObject.FindGameObjectWithTag("Player").GetComponent<DestroyByBullet>();
        boss = GameObject.FindGameObjectWithTag("Boss");
        ShowTankInfo();
        StartCoroutine(SetMessage("Press W/S to move\nPress A/D to steer\nClick mouse to fire bullet!"));
    }

    void Update()
    {        
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

            //First teleport map. Will probably put a non-collider sprite later!
            if (transform.position.y > 49 && transform.position.y < 50 && transform.position.x > 0 && transform.position.x < 4)
            {
                transform.position = new Vector3(transform.position.x + 7, transform.position.y - 23);
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
        rb.velocity = Vector2.zero;
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
        }
        playerInfo.text = text;
    }
}
