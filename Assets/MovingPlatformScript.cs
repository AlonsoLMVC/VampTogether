using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformScript : MonoBehaviour
{
    public Transform StartPoint;
    public Transform EndPoint;
    Transform Target;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector2 Direction = EndPoint.position - StartPoint.position;

        transform.Translate(Direction.normalized);


        //if(Vector2.Distance(transform.position, Target.transform.position) < 0.5f)
        {
            
        }


    }




}
