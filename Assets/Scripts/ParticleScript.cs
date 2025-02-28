using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScript : MonoBehaviour
{
    ParticleSystem particle_System;

    // Start is called before the first frame update
    void Start()
    {
        particle_System = GetComponent<ParticleSystem>();

        particle_System.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!particle_System.IsAlive())
        {
            Destroy(gameObject);
        }
    }
}
