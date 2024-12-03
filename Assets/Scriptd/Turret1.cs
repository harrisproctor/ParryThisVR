using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret1 : MonoBehaviour
{

    public GameObject prefabBall;
    public float fireForce;
    public Transform firePlace;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Shoot", 3.0f, 3.0f);
    }

    void Shoot()
    {
         GameObject shotIn = Instantiate(prefabBall, firePlace.position, transform.rotation);
         Rigidbody rb = shotIn.GetComponent<Rigidbody>();

         rb.AddForce(firePlace.forward*fireForce, ForceMode.Force);
         Destroy(shotIn,8);
    }
}
