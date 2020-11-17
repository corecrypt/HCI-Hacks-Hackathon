using UnityEngine;

public class FlashLight : MonoBehaviour
{
    public GameObject flashLight;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("f");
            flashLight.SetActive(!flashLight.activeSelf);
        }
    }
}
