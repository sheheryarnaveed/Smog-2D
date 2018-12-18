using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class match_invoke : MonoBehaviour
{
    public AudioSource FiresourecSource;
    public Rigidbody2D match;
    public Transform player;
    private bool fire;
    public GameObject GO;
    public GameObject go;
    Animator anim;
    int idle = Animator.StringToHash("idle");
    int throw_left = Animator.StringToHash("throw_left");
    int throw_right = Animator.StringToHash("throw_right");
    void Start()
    {
        fire = true;
        anim = GetComponent<Animator>();
        anim.SetTrigger(idle);
    }

    // Update is called once per frame
    void Update () {
        
        if (Input.GetButton("Fire1") && fire)
        {
            FiresourecSource.PlayOneShot(FiresourecSource.clip);
            //if (!FiresourecSource.isPlaying)
            //{
            //    FiresourecSource.Play();
            //}
            anim.ResetTrigger(idle);
            //Rigidbody2D matchInstance;
            if (controller.right)
            {
                
                go = Instantiate(GO, new Vector2(player.position.x + 1f, player.position.y + 1f), Quaternion.identity) as GameObject;
                match = go.GetComponent<Rigidbody2D>();
                match.AddForce(Vector2.right * 1600);
                fire = false;
                anim.SetTrigger(throw_right);
                Destroy(go, 1.0f);
            }
            else
            {
                
                go = Instantiate(GO, new Vector2(player.position.x - 1f, player.position.y + 1f), Quaternion.identity) as GameObject;
                match = go.GetComponent<Rigidbody2D>();
                match.AddForce(Vector2.left * 1600);
                fire = false;
                Destroy(go, 1.0f);
                anim.SetTrigger(throw_left);
            }
         
        }
        if (go == null) {
                fire = true;
            }


    }

    void FixedUpdate()
    {
        anim.ResetTrigger(throw_right);
        anim.ResetTrigger(throw_left);
        anim.SetTrigger(idle);
    }
}
