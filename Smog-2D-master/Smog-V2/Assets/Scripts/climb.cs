using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class climb : MonoBehaviour {

    private controller theplayer;
	// Use this for initialization
	void Start () {
        theplayer = FindObjectOfType<controller>();
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "PlayerObject")
        {
            theplayer.onLadder = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "PlayerObject")
        {
            theplayer.onLadder = false;
        }
    }



}
