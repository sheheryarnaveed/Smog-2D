using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Torch : MonoBehaviour {

    
    public Light Tool;
    private int m_nowCount;
    private bool check;
    // Use this for initialization
    void Start () {
        Tool.enabled = false;
        check = true;
        m_nowCount = 0;

    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(".") && check && m_nowCount <= 3)
        {
            check = false;
            Tool.enabled = true; // for toggling:  !Tool.enabled;
            m_nowCount++;

            StartCoroutine(LateCall());
        }

    }

    IEnumerator LateCall()
    {

        yield return new WaitForSeconds(3);
        Tool.enabled = false;
        check = true;
    }


}
