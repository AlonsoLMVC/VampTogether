using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class LevelExitDoorScript : MonoBehaviour
{
    public string ForCharacter;
    public bool StandingInFront;
    int targetIntensity;
    Light2D lightComponent;
    float glowSpeed = 3f;

    public GameObject OtherDoor;
    public string NextLevel;
    public GameObject canvas;


    // Start is called before the first frame update
    void Start()
    {
        lightComponent = transform.GetChild(0).GetComponent<Light2D>();
        canvas = GameObject.Find("Canvas");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (StandingInFront)

        {
            targetIntensity = 2;
        }
        else
        {
            targetIntensity = 0;

        }

        lightComponent.intensity = Mathf.Lerp(lightComponent.intensity, targetIntensity, glowSpeed * Time.deltaTime);


        if (OtherDoor != null)
        {
            if (StandingInFront && OtherDoor.GetComponent<LevelExitDoorScript>().StandingInFront)
            {

                StartCoroutine(FinishedLevel(0.5f,0.25f));

            }
        }

    }

    public IEnumerator FinishedLevel(float InitialDelay, float FadeSpeed)
    {
        //yield return new WaitForSeconds(InitialDelay);

        StartCoroutine(canvas.GetComponent<CanvasScript>().FadeToBlack(FadeSpeed));
        yield return new WaitForSeconds(FadeSpeed);

        SceneManager.LoadScene(NextLevel);

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.tag == ForCharacter)
            {

                StandingInFront = true;



            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.tag == ForCharacter)
            {

                StandingInFront = false;
            }

        }
    }
}
