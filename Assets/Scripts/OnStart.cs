using UnityEngine.SceneManagement;
using UnityEngine;

public class OnStart : MonoBehaviour
{

    void Start()
    {
        SceneManager.LoadScene("End"); 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Locked;
        }

        
            

    }


}
