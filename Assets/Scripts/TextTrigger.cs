using System.Collections;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class TextTrigger : MonoBehaviour
{
    public bool showOnce;
    public string text;
    public float textShowTime = 5f;
    public TextMeshProUGUI label;

    private float exitTime;
    private int collisions = 0;

    private void OnTriggerEnter(Collider other)
    {
        // Only the player should have this component
        if (other.GetComponentInChildren<PlayerController>())
        {
            collisions++;

            if (showOnce && collisions > 1)
                return;

            label.SetText(text);
            label.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        exitTime = Time.time;
        StartCoroutine(FadeText());
    }

    private IEnumerator FadeText()
    {
        Color startColor = label.color;
        Color fadeColor = new Color(label.color.r, label.color.b, label.color.a, 0);
        StartCoroutine(Common.FadeToColor(startColor, fadeColor, textShowTime, col => label.color = col));

        yield return new WaitForSeconds(textShowTime);
        label.gameObject.SetActive(false);
        label.color = startColor;
    }
}
