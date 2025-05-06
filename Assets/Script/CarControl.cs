using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.Security.Cryptography;
public class CarControl : MonoBehaviour
{
    float speed = 0.1f;
    public Text s;
    int score = 0;
    public Sprite[] car;
    int carIndex = 0;
    bool isGoingLeft = false;
    bool isGoingRight = false;
    int num = 0;
   // float maxspeed =0.80f;
    public GameObject btn1,btn;
    AudioSource music;
    public AudioClip clip1, clip2;
    float vol;
    public bool isgamepause = false;
    // Start is called before the first frame update
    void Start()
    {
        vol = PlayerPrefs.GetFloat("volume",1f);
        carIndex = PlayerPrefs.GetInt("carIndex",0);
        num = PlayerPrefs.GetInt("num",0);
        GetComponent<SpriteRenderer>().sprite = car[carIndex];
        music = GetComponent<AudioSource>();
        music.volume = vol;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(score >=25)
        {
            speed += 0.0002f;
        }
        if(num==0)
        {
            if (isGoingLeft)
            {
                LeftMoveCar();
            }
            if (isGoingRight)
            {
                rightmovecar();
            }
            btn.SetActive(true);
            btn1.SetActive(true);
        }
        if(num==1)
        {
            keybord();
        }
        if(num==2)
        {      
            touch();       
        }
        if(num==3)
        {
            rotat();
        }
        if(transform.rotation.y != 90)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0),speed);
        }  
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag =="CarWhite")
        {

            music.clip = clip2;
            music.Play();
            isgamepause = true;
            StartCoroutine(chagescene());
           
        }
        if (collision.gameObject.tag == "CarYellow")
        {
            music.clip = clip2;
            music.Play();
            isgamepause = true;
            StartCoroutine(chagescene());
              
        }
        
        if(collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
            score = score + 5;
            s.text = score.ToString();
            music.clip = clip1;
            music.Play();
        }
    }
    // after play audio run this function
    IEnumerator chagescene()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("RESTART");
       // Time.timeScale = 0;
    }
    public void control()
    {
        SceneManager.LoadScene("SETTING");
    }
    void keybord()
    {
        float posx = Mathf.Clamp(transform.position.x - speed, -1.85f, +1.85f);
        float posy = Mathf.Clamp(transform.position.x + speed, -1.85f, +1.85f);
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = new Vector2(posx, transform.position.y);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 47), speed);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = new Vector2(posy, transform.position.y);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, -47), speed);
        }
    }
    public void leftBtnDown()
    {
        isGoingLeft = true;
    }
    public void leftBtnUp()
    {
        isGoingLeft = false;
    }
    public void LeftMoveCar()
    {
        float posx = Mathf.Clamp(transform.position.x - speed, -1.85f, +1.85f);
        transform.position = new Vector2(posx, transform.position.y);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 47), speed);
    }
    public void rightbtndown()
    {
           isGoingRight = true;      
    }
    public void rightbtnup()
    {
           isGoingRight = false;
    }
    public void rightmovecar()
    {
        float posy = Mathf.Clamp(transform.position.x + speed, -1.85f, +1.85f);
        transform.position = new Vector2(posy, transform.position.y);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, -47), speed);      
    }
    void rotat()
    {
        if (Input.acceleration.x<-0.1f)
        {
            LeftMoveCar();
        }
        else if(Input.acceleration.x>0.1f)
        {
            rightmovecar();
        }
        btn.SetActive(false);   
        btn1.SetActive(false);
    }
    void touch()
    {
        if(Input.touchCount>0)
        {
            Touch t = Input.GetTouch(0);    
            if(t.position.x<Screen.width/2)
            {
                LeftMoveCar();
            }
            else if(t.position.x>Screen.width/2)
            {
                rightmovecar(); 
            }
            btn.SetActive(false);
            btn1.SetActive(false);
        }
    }
}