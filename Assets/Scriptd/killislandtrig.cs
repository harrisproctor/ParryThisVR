using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killislandtrig : MonoBehaviour
{
    public int health;
    public string targetTag;
    //public string objecttrig;

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object has the specified tag
        if (collision.gameObject.CompareTag(targetTag) && enabled == true)
        {
            // Get the SpawnablePrefabHolder component from the colliding object
            bulletscript bs = collision.gameObject.GetComponent<bulletscript>();

                
                // Destroy the colliding object
                Destroy(collision.gameObject);

                
                health = health - bs.dmg;
                //Debug.Log(health);
                if(health <1){
                    Destroy(gameObject);
                    GameObject TheGameController = GameObject.Find("up");
                    up TheScript = TheGameController.GetComponent<up>();
                    TheScript.Finishbatch1();

                }
                
               
                
            
        }
    }
}
