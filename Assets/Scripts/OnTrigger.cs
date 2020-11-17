using UnityEngine.SceneManagement;
using UnityEngine;

public class OnTrigger : MonoBehaviour
{
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Debug.Log("Nurrrr");
        }
    }
}
