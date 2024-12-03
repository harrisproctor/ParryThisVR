using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class up : MonoBehaviour
{

    public Transform target;
    public Transform target2;
    public float speed;
    bool goingup = true;
    int batch1d = 0;
    public GameObject[] batch2;
    public GameObject wave3;
    public GameObject wave4;


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

    public void Finishbatch1()
    {
        if(batch1d < 2)
        {
            batch1d += 1;
        }else if(batch1d == 2){
            //Debug.Log("harris");
        for (int i = 0; i < 1; i++) 
        {
        batch2[i].SetActive(true);
        }
        batch1d += 1;
        }else if(batch1d < 4){
            batch1d += 1;
            //Debug.Log(batch1d);

        }else if(batch1d == 4){
            
         Invoke("Wave3",5.0f);
          batch1d += 1;

        }else if(batch1d < 7){
            
          batch1d += 1;
        }else if(batch1d == 7){
            
          batch1d += 1;
          Invoke("Wave4",8.0f);
        }else if(batch1d == 8){
          //you win
          //Debug.Log("up up and away");
          Invoke("Finalup",3.0F);
        }





    }

    void Wave3(){
    wave3.SetActive(true);
    
    }
    void Wave4(){
    wave4.SetActive(true);
    
    }
    void Finalup()
    {
         target = target2;
         goingup = true;
    }

   






}
