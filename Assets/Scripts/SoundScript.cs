using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip[] GrassFootSteps;
    public AudioClip[] WaterSplashes;
    public AudioClip InFrontOfDoorSoundEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }


    public void PlayFootStep(string SurfaceType)
    {
        if (SurfaceType == "Grass")
        {
            if (GrassFootSteps.Length > 0)
            {
                audioSource.clip = GrassFootSteps[Random.Range(0, GrassFootSteps.Length)];

                float randomnum = Random.Range(12, 16);

                audioSource.pitch = randomnum/10;
                Debug.Log(audioSource.pitch);
                audioSource.Play();

                Destroy(this.gameObject,audioSource.clip.length);
            }
        }
    }

    public void PlayWaterSplash()
    {
        audioSource.clip = WaterSplashes[Random.Range(0,WaterSplashes.Length)];

        audioSource.Play();
        Destroy(this.gameObject, audioSource.clip.length);

    }

    public void PlayInFrontOfDoorSound()
    {
        audioSource.clip = InFrontOfDoorSoundEffect;
        audioSource.Play();
        Destroy(this.gameObject, audioSource.clip.length);

    }
}
