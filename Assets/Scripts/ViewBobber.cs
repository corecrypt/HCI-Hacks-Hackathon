using UnityEngine;

public class ViewBobber : MonoBehaviour
{
    public float settleSpeed = 1;
    public float frequencyIdle = 3;
    public float amplitudeIdle = 0.05f;
    public float frequencyMoving = 3;
    public float amplitudeMoving = 0.05f;

    public Transform target;
    public PlayerController controller;

    void Update()
    {
        Vector3 local = target.localPosition;

        float a = controller.IsMoving ? amplitudeMoving : amplitudeIdle;
        float f = controller.IsMoving ? frequencyMoving : frequencyIdle;

        float desiredY = a * Mathf.Cos(Mathf.PI * Time.time * f);

        target.localPosition = new Vector3(local.x, Mathf.Lerp(local.y, desiredY, Time.deltaTime * settleSpeed), local.z);
    }
}
