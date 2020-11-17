using System.Collections;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public string staticToolTip = "Placeholder";
    // A cyan color
    public Color highlightColor = new Color32(42, 237, 237, 255);

    private Material instanceMaterial;
    private Color startcolor;
    private Color currentTargetColor;
    private bool flashing;

    protected virtual void Awake()
    {
        instanceMaterial = GetComponentInChildren<MeshRenderer>().material;
        startcolor = instanceMaterial.color;
    }

    // Called when the player first looks at the intereactable
    public virtual void OnBeginLook()
    {
        currentTargetColor = highlightColor;
        instanceMaterial.color = currentTargetColor;
    }

    // Playe stops looking at intereactable
    public virtual void OnEndLook()
    {
        if (flashing)
            currentTargetColor = startcolor;
        else
            instanceMaterial.color = startcolor;
    }

    public virtual void Interact(GameObject player)
    {
        StopAllCoroutines();
        StartCoroutine(Flash());
    }

    public virtual string GetToolTip(GameObject player)
    {
        return staticToolTip;
    }

    private IEnumerator Flash()
    {
        flashing = true;
        instanceMaterial.color = Color.blue;
        while (Difference(instanceMaterial.color, currentTargetColor) > 1e-3)
        {
            instanceMaterial.color = Color.Lerp(instanceMaterial.color, currentTargetColor, Time.deltaTime);
            yield return null;
        }

        flashing = false;

        float Difference(Color a, Color b)
        {
            return new Vector3(a.r - b.r, a.g - b.g, a.b - b.b).magnitude;
        }
    }
}
