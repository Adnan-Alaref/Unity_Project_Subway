using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controller_ : MonoBehaviour
{
    public static bool run=false;
    // Start is called before the first frame update
    private CharacterController character;
    private Vector3 moving=new Vector3();
    private float speed=10,jumpForce=7f,gravity=-20,waitS=0,waitJ=0;
    private int score=0;
    private AudioSource Audio;
    public Text text;
    private Animator anim;
    public Text StartingText;
    private bool GameStarting;
    float IncreaseJump;
    void Start()
    {
        anim = GetComponent<Animator>();
        //Time.timeScale = 0;
        GameStarting = false;
        Audio = GetComponent<AudioSource>();
        character = GetComponent<CharacterController>();
        IncreaseJump = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Return))
        {
            Time.timeScale = 1;
            run=true;
            anim.SetBool("start_game", false);
            GameStarting = true;
        }
        //Debug.Log("ssssss");
        if(run)
        {
            moving.z=.63f*speed;
            speed+=.0004f;
            if (IncreaseJump > 0)
            {
                IncreaseJump -= Time.deltaTime;
            }
            else
                jumpForce = 7;
            //Debug.Log(moving.y);
            //    moving.y+=gravity*Time.deltaTime;
            if (character.isGrounded)
            {
                
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    jump();
                    anim.SetBool("jump", true);
                    character.height=.5f;
                    waitJ=20*Time.deltaTime;
                }
                else
                {
                    anim.SetBool("jump", false);
                    if(waitJ<=0&&waitS<=0)
                        character.height = 1.8f;
                    else
                    {
                        if(waitJ>0)
                        waitJ-=Time.deltaTime;
                    }
                }
                    
                if(Input.GetKeyDown(KeyCode.DownArrow))
                {
                    //jump();
                    anim.SetBool("roll", true);
                    character.height=.3f;
                    waitS=60*Time.deltaTime;
                    //controller.height = 2.0f;
                }
                else
                    {
                        anim.SetBool("roll", false);
                        if(waitJ<=0&&waitS<=0)
                        character.height = 1.8f;
                        else
                        {
                            if(waitS>0)
                            waitS-=Time.deltaTime;
                        }
                    }
            }
            else 
                moving.y+=gravity*Time.deltaTime;
            moving.x=Input.GetAxis("Horizontal")*speed;
        }
    }
    void FixedUpdate(){
        if (!GameStarting)
            return;
        else
        {
            Destroy(StartingText);
            text.text = "Score: " + score;
            character.Move(moving * Time.deltaTime);
        }
    }
    void jump(){
        moving.y=jumpForce;
    }
    void OnTriggerEnter(Collider coll)
    {
        if(coll.tag=="coin")
        {
            score++;
            Audio.Play();
            coll.gameObject.SetActive(false);
        }
        if(coll.tag=="big_coin")
        {
            score+=10;
             Audio.Play();
            coll.gameObject.SetActive(false);
        }
        if(coll.tag=="Obstacle")
        {
            PlayerManager.gameOver=true;
        }
        if (coll.tag == "star")
        {
            IncreaseJump += 350 * Time.deltaTime;
            jumpForce = 11;
            coll.gameObject.SetActive(false);
        }
    }
    
}

