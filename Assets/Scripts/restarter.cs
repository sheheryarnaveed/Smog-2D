using UnityEngine;
using UnityEngine.SceneManagement;

public class restarter : MonoBehaviour
{

    public AudioSource m_end;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "PlayerObject")
        {

            if (!m_end.isPlaying)
            {
                m_end.Play();
            }
            Invoke("end",2);
        }
    }

    void end()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
