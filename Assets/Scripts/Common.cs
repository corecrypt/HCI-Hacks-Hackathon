using System;
using System.Collections;
using UnityEngine;

public static class Common
{
    public static IEnumerator FadeToColor(Color startColor, Color endColor, float fadeTime, Action<Color> setter)
    {
        float startTime = Time.time;

        while (Time.time - startTime < fadeTime)
        {
            float progress = (Time.time - startTime) / fadeTime;
            setter?.Invoke(Color.Lerp(startColor, endColor, progress));
            yield return null;
        }
    }
}
