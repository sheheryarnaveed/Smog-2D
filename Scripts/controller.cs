using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Collision2D;


public class controller : MonoBehaviour {
    private bool jump;
    public float moveSpeed;
    public float jumpPower;

    private Rigidbody2D mrb2d;
    public bool onLadder;
    public float climbSpeed;
    private float climbVelocity;
    private float gavityStore;


    // Use this for initialization
    void Start () {
        jump = true;
        mrb2d = GetComponent<Rigidbody2D>();
        gavityStore = mrb2d.gravityScale;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.RightArrow))
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Translate(-Vector2.right * moveSpeed * Time.deltaTime);

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (Input.GetKey(KeyCode.UpArrow) && jump)
        {
            rb.AddForce(Vector2.up * jumpPower);
            jump = false;
        }

        if (onLadder)
        {
            mrb2d.gravityScale = 0f;
            climbVelocity = climbSpeed * Input.GetAxis("Vertical");
            mrb2d.velocity = new Vector2(mrb2d.velocity.x, climbVelocity);
        }
        if (!onLadder)
        {
            mrb2d.gravityScale = gavityStore;
        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "ground")
        {
            jump = true;
        }
    }
}
