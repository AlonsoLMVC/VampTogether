using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip[] GrassFootSteps;
    public AudioClip[] WaterSplashes;
    public AudioClip InFrontOfDoorSoundEffect;
    public AudioClip ExitDoorOpenSoundEffect;
    public AudioClip HumanJumpSoundEffect;
    public AudioClip VampireJumpSoundEffect;
    public AudioClip DeathSoundEffect;

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

    public void ExitDoorOpenSound()
    {
        audioSource.clip = ExitDoorOpenSoundEffect;
        audioSource.volume = 0.5f;

        audioSource.Play();
        Destroy(this.gameObject, audioSource.clip.length);

    }
    public void PlayHumanJumpSoundEffect()
    {
        audioSource.clip = HumanJumpSoundEffect;
        audioSource.Play();
        Destroy(this.gameObject, audioSource.clip.length);
    }
    public void PlayVampireJumpSoundEffect()
    {
        audioSource.clip = VampireJumpSoundEffect;
        float randomnum = Random.Range(6f, 10);

        audioSource.pitch = randomnum / 10;
        audioSource.Play();
        Destroy(this.gameObject, audioSource.clip.length);
    }
    public void PlayHumanDeathSound()
    {
        audioSource.clip = DeathSoundEffect;
        audioSource.pitch = 1.1f;
        audioSource.Play();
        Destroy(this.gameObject, audioSource.clip.length);
    }
    public void PlayVampireDeathSound()
    {
        audioSource.clip = DeathSoundEffect;
        audioSource.pitch = .85f;
        audioSource.Play();
        Destroy(this.gameObject, audioSource.clip.length);
    }
}
