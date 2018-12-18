using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    public AudioSource m_Win;
    void OnTriggerEnter2D(Collider2D other)
    {
        System.Diagnostics.Debug.WriteLine("Apple");
        if (other.name == "PlayerObject")
        {
            if (!m_Win.isPlaying)
            {
                m_Win.Play();
            }
            Invoke("load",2);
        }
    }

    void load()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}




