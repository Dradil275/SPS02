using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SantaEngine : MonoBehaviour
{
    // object counters
    public GameObject[] presents = new GameObject[19];
    public  int presentCount;
    public int netzCount;
    public bool isPresentPastNetzRange;

    // panels and ui
    public GameObject outOfPresents;
    public GameObject GameOverPanel;
    public GameObject SpawnPoint;
    public Text Pcount;
    public Text Ncount;
    public GameObject TripplePointButtonGO;
    public bool isOutOfpresentsActive;
    //progression
    public float chimnysPassed;

    //controls
    public float touchEquilizer;
    public float speed;
    public float direction;
    float firstTouchY;
    Vector2 StartTouchPosition;
    Vector2 EndTouchPosition;
    float diffrence;
    public Vector3 targetPosition;
    //sounds
    public AudioSource audioSource;
    public AudioClip[] presentDropSounds = new AudioClip[4];
    public AudioClip twinkle;

    //Particles
    public ParticleSystem NetzParitcles;
    public GameObject plusPresent;

    // rigidbody
    Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        //TenjinIntegration.Scripts.TenjinMono.SendTenjinEvent("test02.08","0");

        isPresentPastNetzRange = false;

        // load Save
        SceneLoader.LoadGameSave();
        // rigid body
        rb = GetComponent<Rigidbody2D>();


    
        //Partilces


        isOutOfpresentsActive = false;
        presentCount = 3  + Shop.GetBagSize();
        chimnysPassed = 0;
        netzCount = Shop.GetNetzLevel();
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector2 playerpos =new Vector2 (transform.position.x, transform.position.y);

        if (outOfPresents.activeSelf == true)
        {
            isOutOfpresentsActive = true;
        }
        else isOutOfpresentsActive = false;


        if (Input.touchCount > 0)
        {
             
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            Vector2 santaPos = gameObject.transform.position;
            if (touch.phase == TouchPhase.Began)
            {
                 firstTouchY = touchPos.y;
                
                if(santaPos.y > firstTouchY)
                {
                    diffrence = santaPos.y - firstTouchY;
                    
                }  
                if(santaPos.y < firstTouchY)
                {
                    diffrence =  firstTouchY - santaPos.y;
                    diffrence = diffrence * -1;

                }

                
            }

    

          
          
            float newTouchY;
            if(touch.phase == TouchPhase.Moved)
            {
                newTouchY = Camera.main.ScreenToWorldPoint(touch.position).y;
                float moveBy = touchPos.y + diffrence;
                moveBy = Mathf.Clamp(moveBy, -4.5f, 4.5f);
                transform.position = new Vector3(transform.position.x, moveBy , transform.position.z) ;


            }
     
            if (touch.phase == TouchPhase.Ended)
            {
                diffrence = 0;
                newTouchY = 0;
                firstTouchY = 0;
            }

        }


        float y = Input.GetAxis("Vertical");
        transform.Translate(0, y / 10, 0);

        //Netz and Present counters

        Ncount.text = netzCount.ToString();
        Pcount.text = presentCount.ToString();
       if(netzCount < 0)
        {
            netzCount = 0;
        }
        
        // out of presents
        if(presentCount <= 0 && isOutOfpresentsActive == false)
        {
   
            
                if (isPresentPastNetzRange == true)
                {
                    Invoke("OutofPresents", 1f);
                    isPresentPastNetzRange = false;
                }
            
            else Invoke("OutofPresents", 1f);
           
          
           

        }

        if(Input.GetKeyDown(KeyCode.F))
        {
            PlayerPrefs.SetInt("bagSize", 0);
            PlayerPrefs.SetInt("netzLevel", 0);
            SceneLoader.ResetGame();
            CameraMovement.isInstructionsRead = false;
        }
        
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "PresentRange")
        {
            if (presentCount > 0)
            {

                float xOffset = 0.354f;
                float yOffset = -1;
                int RandomSound = Random.Range(0, 4);
                int RandomPresent = Random.Range(0, 19);

                if(ObstacleSpawner.isDontPlaySounds == false)
                {
                    audioSource.PlayOneShot(presentDropSounds[RandomSound]);
                }

                Instantiate(presents[RandomPresent], new Vector3(transform.position.x + xOffset, transform.position.y + yOffset, transform.position.z), presents[RandomPresent].transform.rotation);
                presentCount--;
                Pcount.text = presentCount.ToString();
                chimnysPassed++;
            }
        }
        if (collision.gameObject.tag == "Obstacle")
        {
            Rv_maneger.isScoreset = true;
            GameOverPanel.SetActive(true);
            GameObject.Find("Main Camera").GetComponent<CameraMovement>().isMoving = false;
            GameObject.Find("Backround").GetComponent<LoopingBackround>().isLooping = false;
            SpawnPoint.GetComponent<ObstacleSpawner>().isGameOver = true;
            SceneLoader.interstialCounter++;
            Debug.Log(SceneLoader.interstialCounter);
            DestroySelf();

        }
    }

    public void OutofPresents()
    {
        
       
        outOfPresents.SetActive(true);
        SpawnPoint.GetComponent<ObstacleSpawner>().isGameOver = true;
        
        GameObject[] chimnys = GameObject.FindGameObjectsWithTag("Chimny");
        foreach (GameObject c in chimnys)
        {
            
            Destroy(c);
        }

    }
    public void DestroySelf()
    {
        Destroy(gameObject);
    }    

    public void MoveUp()
    {
        Vector2 newPos = (Vector2)transform.position + (new Vector2(0, direction) * speed * Time.deltaTime);
        Physics2D.SyncTransforms();
        rb.MovePosition(newPos);

    }  
    public void MoveDown()
    {
        Vector2 newPos = (Vector2)transform.position + (new Vector2(0, -direction) * speed * Time.deltaTime);
        Physics2D.SyncTransforms();
        rb.MovePosition(newPos);
    }
    public void StopMoving()
    {
        rb.velocity = new Vector2(transform.position.x, transform.position.y)  + new Vector2(rb.velocity.x, 0);
    }
     
    public void PlayParticles()
    {
        NetzParitcles.Play();
        plusPresent.SetActive(true);
        audioSource.PlayOneShot(twinkle);
        Invoke("DeactivePlusPresent", 0.6f);
    }

    public void DeactivePlusPresent()
    {
        plusPresent.SetActive(false);
    }
}
