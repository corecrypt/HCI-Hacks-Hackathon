using UnityEngine;

public class Flicker : MonoBehaviour
{
    public float frequency;
    public float amplitude;
    public float minIntensity;

    private Light targetLight;

    private void Awake()
    {
        targetLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        targetLight.intensity = amplitude * Mathf.PerlinNoise(transform.position.x + Time.deltaTime * frequency, transform.position.y + Time.deltaTime * frequency) + minIntensity;
    }
}
