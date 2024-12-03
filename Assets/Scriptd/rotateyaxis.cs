using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateyaxis : MonoBehaviour
{
    public float rotationspeedx;
     public float rotationspeedy;
      public float rotationspeedz;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(rotationspeedx,rotationspeedy,rotationspeedz) * Time.deltaTime);
    }
}
