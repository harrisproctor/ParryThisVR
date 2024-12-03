using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forestlevelwavemanager : MonoBehaviour
{
    int deathcount = 0;
    public GameObject wave2;
    public GameObject wave3;
  //  public int why;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Death(){
        deathcount += 1;
       Debug.Log("die2");
        if (deathcount == 1){
            wave2.SetActive(true);
            // Debug.Log("die3");
        }else if (deathcount == 2){
            wave3.SetActive(true);
             //Debug.Log("die3");
        }






    }
}
