using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killable : MonoBehaviour
{
    public int health;
    public string targetTag;
    public GameObject midbod;
    bool goingback;
    bool goingfor;
    public float rotationspeed;

    // Update is called once per frame
    void Update()
    {
        if(goingback)
        {
            

        midbod.transform.Rotate(new Vector3(-rotationspeed,-rotationspeed,-rotationspeed) * Time.deltaTime);
        }else if(goingfor){
            midbod.transform.Rotate(new Vector3(rotationspeed,rotationspeed,rotationspeed) * Time.deltaTime);
        }

        
    }

    void Hit()
    {
        goingback = true;
        Invoke("Return",0.2f);

    }
    void Return()
    {
         goingback = false;
         goingfor = true;
         Invoke("Returnend",0.2f);
    }
      public void Hit2()
    {
        rotationspeed = rotationspeed * 2;
        goingback = true;
        Invoke("Return2",0.4f);

    }
    void Return2()
    {
         goingback = false;
         goingfor = true;
         Invoke("Returnend2",0.4f);
    }
     void Returnend2()
    {
         goingfor = false;
         rotationspeed = rotationspeed/2;
    }
    void Returnend()
    {
         goingfor = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object has the specified tag
        if (collision.gameObject.CompareTag(targetTag) && enabled == true)
        {
            // Get the SpawnablePrefabHolder component from the colliding object
            bulletscript bs = collision.gameObject.GetComponent<bulletscript>();

                
                // Destroy the colliding object
                //Destroy(collision.gameObject);

                
                health = health - bs.dmg;
               Hit();
                //Debug.Log(health);
                if(health <1){
                    Destroy(gameObject);
                    Debug.Log("die");
                    GameObject TheGameController = GameObject.Find("manag");
                    forestlevelwavemanager TheScript = TheGameController.GetComponent<forestlevelwavemanager>();
                    TheScript.Death();
                   
                }
                
               
                
            
        }
    }
}
