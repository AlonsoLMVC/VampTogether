using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformController: Interactible
{
    public Transform Target;
    public float speed = 2f; // Speed of movement
    public float threshold = 0.1f; // Distance at which the platform stops

    private Vector2 startPosition; // Store the platform's original position

    void Start()
    {
        // Store the platform's original position at the start
        startPosition = transform.position;
    }

    void Update()
    {
        Vector2 destination = isOn ? Target.position : startPosition; // Move based on isOn state

        // Move platform towards the destination
        if (Vector2.Distance(transform.position, destination) > threshold)
        {
            transform.position = Vector2.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        }
    }
}
