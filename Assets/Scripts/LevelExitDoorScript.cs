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
    float glowSpeed = 5f;
    float AttractionAmount = 4;
    float OpenSpeed = 2;

    public GameObject OtherDoor;
    public string NextLevel;
    public GameObject canvas;

    GameObject OverlappedPlayer;

    GameObject OpeningSquare;

    bool open = false;

    public GameObject SoundObj;

    // Start is called before the first frame update
    void Start()
    {
        lightComponent = transform.GetChild(0).GetComponent<Light2D>();
        canvas = GameObject.Find("Canvas");
        OpeningSquare = transform.Find("Opening").gameObject;

        foreach(GameObject g in GameObject.FindGameObjectsWithTag("ExitDoor"))
        {
            if(g != this.gameObject)
            {
                OtherDoor = g;
            }
        }
        


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

                StartCoroutine(FinishedLevel(1f , 0.25f));

            }
        }

        if (open)
        {
            OpeningSquare.transform.localScale = Vector3.Lerp(OpeningSquare.transform.localScale, new Vector3(0.7346335f, OpeningSquare.transform.localScale.y, 1), OpenSpeed * Time.deltaTime);
        }

    }

    public IEnumerator FinishedLevel(float InitialDelay, float FadeSpeed)
    {
        if(OverlappedPlayer != null)
        {
            if(OverlappedPlayer.GetComponent<Player1MovementScript>() != null)
            {
                OverlappedPlayer.GetComponent<Player1MovementScript>().MovementEnabled = false;
            }
            else if (OverlappedPlayer.GetComponent<Player2Movement>() != null)
            {
                OverlappedPlayer.GetComponent<Player2Movement>().MovementEnabled = false;

            }
            
            if(Vector3.Distance(OverlappedPlayer.transform.position, transform.position) >0.25f)
            OverlappedPlayer.gameObject.transform.position = Vector3.Lerp(OverlappedPlayer.gameObject.transform.position,transform.position, AttractionAmount * Time.deltaTime);

            open = true;
        }

        yield return new WaitForSecondsRealtime(InitialDelay);

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
                OverlappedPlayer = collision.gameObject;
                StandingInFront = true;

                GameObject NewSound = Instantiate(SoundObj, transform.position, Quaternion.identity);
                NewSound.GetComponent<SoundScript>().PlayInFrontOfDoorSound();

            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.tag == ForCharacter)
            {
               OverlappedPlayer = null;
               StandingInFront = false;
            }

        }
    }
}
