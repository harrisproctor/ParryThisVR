using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class head : MonoBehaviour
{



       bool red = true;

       public MeshRenderer PLS;

       public int health;

       int hits = 0;



    // Start is called before the first frame update
    void Start()
    {
        Redtoggle();
    }

     private void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object has the specified tag
        if (collision.gameObject.CompareTag("Bullet") && enabled == true)
        {
        hits += 1;

         Redtoggle();
         Debug.Log(hits);
            
        }
    }

     void Redtoggle(){
        if(red){
         red = false;
         PLS.enabled=false;
        
     }else{
         red = true;
         PLS.enabled=true;
         Invoke("Redtoggle",0.2f);

     }
    }






}
