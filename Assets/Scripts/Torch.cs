using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Torch : MonoBehaviour
{

    public AudioSource m_open;
    public Light Right_Tool;
    public Light Left_Tool;
    private int m_nowCount;
    private bool check;
    //private static bool direction;
    // Use this for initialization
    void Start () {
        Right_Tool.enabled = false;
        Left_Tool.enabled = false;
        check = true;
        m_nowCount = 0;

    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButton("Fire2") && check && m_nowCount <= 3 && controller.right)
        {
            if (!m_open.isPlaying)
            {
                m_open.Play();
            }
            check = false;
            Right_Tool.enabled = true; // for toggling:  !Tool.enabled;
            m_nowCount++;

            StartCoroutine(LateCall_R());
        }
        if (Input.GetButton("Fire2") && check && m_nowCount <= 3 && controller.left)
        {
            if (!m_open.isPlaying)
            {
                m_open.Play();
            }
            check = false;
            Left_Tool.enabled = true; // for toggling:  !Tool.enabled;
            m_nowCount++;

            StartCoroutine(LateCall_L());
        }

    }

    IEnumerator LateCall_R()
    {

        yield return new WaitForSeconds(3);
        Right_Tool.enabled = false;
        check = true;
    }

    IEnumerator LateCall_L()
    {

        yield return new WaitForSeconds(3);
        Left_Tool.enabled = false;
        check = true;
    }


}
