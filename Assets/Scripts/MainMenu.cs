using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public string gameSceneName;
    public float fadeTime = 1;
    public Image fadeOverlay;

    public void PlayGame()
    {
        StartCoroutine(PlayGameImpl());
    }

    public void Quit()
    {
        Application.Quit();
    }

    private IEnumerator PlayGameImpl()
    {
        yield return StartCoroutine(Common.FadeToColor(Color.clear, Color.black, fadeTime, c => fadeOverlay.color = c));

        SceneManager.LoadScene(gameSceneName);
    }
}
