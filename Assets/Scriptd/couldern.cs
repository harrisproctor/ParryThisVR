using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class couldern : MonoBehaviour
{

// Tag of the object that should trigger the spawn
    
    List<int> elementlist = new List<int>(); 
    int couldshape  = 0;

    public Transform spawnPlace;

    //potion list
    public GameObject throwPotion;
    public GameObject shootPotion;




     private void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object has the specified tag
        if (collision.gameObject.CompareTag("Fruit"))
        {
            // Get the SpawnablePrefabHolder component from the colliding object
            FruitProps fruitprop = collision.gameObject.GetComponent<FruitProps>();

            // Check if the component is present and has a prefab assigned
            if (fruitprop != null)
            {
                if(fruitprop.element != 0)
                {
                elementlist.Add(fruitprop.element);
                }
                
                couldshape = fruitprop.shape;

                // Destroy the colliding object
                Destroy(collision.gameObject);
  
            }
        }
        if (collision.gameObject.CompareTag("Wand"))
        {
            //Debug.Log("wand");
            //throw potion
            var isEmpty = elementlist.Count;
            //Debug.Log(isEmpty);
            //Debug.Log(couldshape);
            if(isEmpty == 0 && couldshape == 3)
            {
              //Debug.Log("throw");
              Instantiate(throwPotion,spawnPlace.position , transform.rotation);
              couldshape = 0;
            }  else if(isEmpty == 0 && couldshape == 1)
            {
              //shoot potion
              Instantiate(shootPotion, spawnPlace.position, transform.rotation);
              couldshape = 0;
            } 
        }
    }
}
