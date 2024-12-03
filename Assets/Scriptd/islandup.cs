using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class islandup : MonoBehaviour
{

public Transform target;
    public float speed;
    bool goingup = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if(goingup){
       transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed);
       float dist = Vector3.Distance(target.position, transform.position);
     if(dist < 0.1f)
     {
     goingup = false;
     }
        }
    }
    public void Goup()
    {
        goingup = true;
    }


}
