using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour
{

    Image fadeScreen;
    //float fadeDuration = 0.25f;

    // Start is called before the first frame update
    void Start()
    {
        fadeScreen = transform.Find("BlackScreen").GetComponent<Image>();

        StartCoroutine(FadeFromBlack(0.25f));
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void startFadeToBlack()
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
    }

    public IEnumerator FadeFromBlack(float fadeDuration)
    {
        fadeScreen.color = Color.black;
        fadeScreen.gameObject.SetActive(true); // Make sure the fade screen is visible

        float timeElapsed = 0f;

        // Gradually fade to black over the duration
        while (timeElapsed < fadeDuration)
        {
            timeElapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(1, 0, timeElapsed / fadeDuration);
            fadeScreen.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        // Ensure it's fully black at the end
        fadeScreen.color = new Color(0, 0, 0, 0);
    }
}
