using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Collision2D;


public class controller : MonoBehaviour {
    private bool jump;
    public float moveSpeed;
    public float jumpPower;
    
    // Use this for initialization
    void Start () {
        jump = true;
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

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "ground")
        {
            jump = true;
        }
    }
}
