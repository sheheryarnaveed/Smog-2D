using UnityEngine;
using UnityEngine.SceneManagement;

public class restarter : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "PlayerObject")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
