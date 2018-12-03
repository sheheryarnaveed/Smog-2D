using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class match_invoke : MonoBehaviour {

    public Rigidbody2D match;
    public Transform player;
    private bool fire;
    public GameObject GO;
    public GameObject go;

    void Start()
    {
        fire = true;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKey("/") && fire)
        {
            //Rigidbody2D matchInstance;
            if (controller.right)
            {
                go = Instantiate(GO, new Vector2(player.position.x + 1f, player.position.y + 1f), Quaternion.identity) as GameObject;
                match = go.GetComponent<Rigidbody2D>();
                match.AddForce(Vector2.right * 1600);
                fire = false;
                Destroy(go, 1.0f);
            }
            else
            {
                go = Instantiate(GO, new Vector2(player.position.x - 1f, player.position.y + 1f), Quaternion.identity) as GameObject;
                match = go.GetComponent<Rigidbody2D>();
                match.AddForce(Vector2.left * 1600);
                fire = false;
                Destroy(go, 1.0f);
            }
         
        }
        if (go == null) {
                fire = true;
            }


    }
}
