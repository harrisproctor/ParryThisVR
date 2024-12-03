using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Uppies : MonoBehaviour
{
    public Transform target;
     public Transform target2;

    public float speed;
    bool goingup;
    public GameObject[] level2mons;
    public bool check1 = false;
    public bool check2 = false;



    // Start is called before the first frame update
    void Start()
    {
     //  Up();
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

    public void Up()
    {
    goingup = true;
    Invoke("Activateen",0.5f);
    }

    public void Up2()
    {
        if(check1 && check2){
        target = target2;
        goingup = true;
        Invoke("Nextscence",11f);


        }
       
    }

    void Activateen()
    {
         for (int i = 0; i < 2; i++) 
    {
      level2mons[i].SetActive(true);
    }
    }
    
    void Nextscence()
    {
    SceneManager.LoadScene("Cavelevel2", LoadSceneMode.Single);
    }


}
