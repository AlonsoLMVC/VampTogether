using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    CanvasScript canvasscript;
    Image fadeScreen;

    private void Start()
    {
        canvasscript = GetComponent<CanvasScript>();
        fadeScreen = transform.Find("BlackScreen").GetComponent<Image>();
    }

    public void startGame()
    {
        Debug.Log("START");
        StartCoroutine(FadeToBlack(1));

        
    }


    void endGame()
    {
    
    }
    public IEnumerator FadeToBlack(float fadeDuration)
    {
        fadeScreen.color = new Color(0, 0, 0, 0);
        fadeScreen.gameObject.SetActive(true); // Make sure the fade screen is visible

        float timeElapsed = 0f;

        // Gradually fade to black over the duration
        while (timeElapsed < fadeDuration)
        {
            timeElapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(0, 1, timeElapsed / fadeDuration);
            fadeScreen.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        // Ensure it's fully black at the end
        fadeScreen.color = Color.black;
        SceneManager.LoadScene("TinsScene");
    }


}
