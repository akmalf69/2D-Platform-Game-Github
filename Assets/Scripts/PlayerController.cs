using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    float hAxis;
    Vector2 direction;

    [SerializeField]
    float speed = 3;
    [SerializeField]
    float jumpPower = 5;

    Rigidbody2D rb;
    [SerializeField]
    bool onGround = false;

    Animator animator;
    
    [SerializeField]
    AudioClip[] audioClips;
    AudioSource audioSource;

    [SerializeField]
    Transform BG;

    [SerializeField]
    Lifes lifeScript;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        Movement();
        Jump();
        Facing();
        animations();
    }
    
    void Movement()
    {
        //Monitor horizontal keypresses and apply movement to player object
        hAxis = Input.GetAxis("Horizontal");
        direction = new Vector2 (hAxis, 0);
        
        transform.Translate(direction * Time.deltaTime * speed);
    }

    void Jump()
    {
        //if spacebar pressed the apply velocity to yAxis
        if(Input.GetKeyDown(KeyCode.Space) && onGround == true )
        {
            rb.velocity = new Vector2(0,1) * jumpPower;

            audioSource.clip = audioClips[1];
            audioSource.Play();
        }
    }

    void Facing()
    {
        //if player moving left scale = -1
        if(hAxis < 0)
        {
            transform.localScale = new Vector3(-1,1,1);
            BG.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
        //if player moving right scale = 1
        if(hAxis > 0)
        {
            transform.localScale = new Vector3(1,1,1);
            BG.localScale = new Vector3(-1.5f, 1.5f, 1.5f);
        }
    }

    void animations()
    {
        //if player moving play running animations
        animator.SetFloat("Moving", Mathf.Abs(hAxis));
        //if player jump play jumping animation
        animator.SetBool("OnGround", onGround);
    }

    private void OnTriggerEnter2D(Collider2D col) 
    {
        //if trigger enter object woth tag "ground" then onGround = true
        if(col.tag == "ground")
        {
            onGround = true;
        }
        if(col.tag == "enemy")
        {
            lifeScript.ReduceLifes();   
        }
        if(col.tag == "collectibles")
        {
            audioSource.clip = audioClips[0];
            audioSource.Play();
        }

    }

    private void OnTriggerExit2D(Collider2D col) 
    {
    //if trigger exit object woth tag "ground" then onGround = false
    if(col.tag == "ground")
        {
            onGround = false;
        }


    }



}
