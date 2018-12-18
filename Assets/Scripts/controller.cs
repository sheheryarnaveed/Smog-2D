using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Collision2D;


public class controller : MonoBehaviour {
    private bool jump;
    public AudioSource music;
    public float moveSpeed;
    public float jumpPower;
    private Rigidbody2D mrb2d;
    public bool onLadder;
    public float climbSpeed;
    private float climbVelocity;
    private float gavityStore;
    public static bool right;
    public static bool left;
    public bool check;
    Animator anim;
    int walk_left = Animator.StringToHash("walk_left");
    int idle = Animator.StringToHash("idle");
    int walk_right = Animator.StringToHash("walk_right");
    int climb = Animator.StringToHash("climb");
    public AudioSource run;
    public AudioSource Jump;
    // Use this for initialization
    void Start () {
        jump = true;
        mrb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        gavityStore = mrb2d.gravityScale;
        anim.SetTrigger(idle);
        check = true;
        right = false;
        left = false;
        music.Play();
	}

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }


        if (Input.GetAxis("Horizontal") > 0)
        {
            //run.PlayOneShot(run.clip);
            if (!run.isPlaying)
            {
                run.Play();
            }
            anim.ResetTrigger(idle);
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            left = false;
            right = true;
            anim.SetTrigger(walk_right);
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            //run.PlayOneShot(run.clip);
            if (!run.isPlaying)
            {
                run.Play();
            }
            anim.ResetTrigger(idle);
            transform.Translate(-Vector2.right * moveSpeed * Time.deltaTime);
            right = false;
            left = true;
            anim.SetTrigger(walk_left);
            
        }

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (Input.GetButton("Jump") && jump)
        {
            //Jump.PlayOneShot(Jump.clip);
            if (!Jump.isPlaying)
            {
                Jump.Play();
            }
            rb.AddForce(Vector2.up * jumpPower);
            jump = false;
            check = false;
            //invoke jumping...jump animation was not prepared!
        }

        if (onLadder)
        {
            anim.SetTrigger(climb);
            mrb2d.gravityScale = 0f;
            climbVelocity = climbSpeed * Input.GetAxis("Vertical");
            mrb2d.velocity = new Vector2(mrb2d.velocity.x, climbVelocity);
            
        }
        if (!onLadder)
        {
            mrb2d.gravityScale = gavityStore;
        }

        
    }

    private void FixedUpdate()
    {
        anim.ResetTrigger(walk_right);
        anim.ResetTrigger(walk_left);
        if (!onLadder)
        {
            anim.SetTrigger(idle);
        }
        else
        {
            anim.SetTrigger(climb);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "ground")
        {
            check = true;
            jump = true;
        }
    }
}
