using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class criticalpoint : MonoBehaviour
{

    public GameObject mainboed;
    public int critmod;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
     private void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object has the specified tag
        if (collision.gameObject.CompareTag("Bullet") && enabled == true)
        {
            // Get the SpawnablePrefabHolder component from the colliding object
            bulletscript bs = collision.gameObject.GetComponent<bulletscript>();

            killable kil = mainboed.gameObject.GetComponent<killable>();
                // Destroy the colliding object
                //Destroy(collision.gameObject);

                
                kil.health = kil.health - (bs.dmg* critmod);
                kil.Hit2();
                 if(kil.health <1){
                    Destroy(gameObject);
                    Debug.Log("die");
                   // GameObject TheGameController = GameObject.Find("manag");
                    //forestlevelwavemanager TheScript = TheGameController.GetComponent<forestlevelwavemanager>();
                   // TheScript.Death();
                   
                }
                
               
                
            
        }
    
}
}
