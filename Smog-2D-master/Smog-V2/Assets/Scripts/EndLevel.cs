using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour {
    
    void OnTriggerEnter2D(Collider2D other)
    {
        System.Diagnostics.Debug.WriteLine("Apple");
        if (other.name == "PlayerObject")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}




