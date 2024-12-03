using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invinbullet : MonoBehaviour
{
    
    public GameObject prefabToSpawn;



       private void OnCollisionEnter(Collision collision)
    {
         if (!collision.gameObject.CompareTag("Knife") && enabled == true && !collision.gameObject.CompareTag("Bullet"))
        {
        Quaternion randomizeRotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
        Quaternion randomizeRotation2 = Quaternion.Euler(0, Random.Range(0, 360), 0);
        Destroy(gameObject);

       GameObject s = Instantiate(prefabToSpawn, transform.position,randomizeRotation);
       GameObject s2 = Instantiate(prefabToSpawn, transform.position, randomizeRotation2);
       GameObject s3 = Instantiate(prefabToSpawn, transform.position, transform.rotation);
       Destroy(s,1);
       Destroy(s2,1);
       Destroy(s3,1); 
        }

       




    }
}
