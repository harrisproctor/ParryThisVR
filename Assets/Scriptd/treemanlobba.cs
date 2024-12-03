using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treemanlobba : MonoBehaviour
{

    public Transform lefthandik;
    public Transform righthandik;
   public Transform rightthrowpoint;
   public Transform leftthrowpoint;
   public Transform lefthandnut;
    public Transform righthandnut;
    public Transform lobpoint;
        public float hoverheight;
        public Transform playerloc;
         float lockPos = 0;
public GameObject prefabBall;
//public Transform firePlace;
public int fireForce;
public float speed;
public float spawnspeed;
    Vector3 targetDirection;
    bool throwingright = false;
    bool returningright = false;
    bool throwingleft = false;
    bool returningleft = false;
    bool handmoving = false;
  //  bool leftlob = false;
    bool lobbbing = false;
    bool tripright = true;
    bool starting = true;
    public Transform spawnpoint;





    // Start is called before the first frame update
    void Start()
    {
        //  InvokeRepeating("throwRight", 1f, 4f);
        //  InvokeRepeating("throwLeft", 3f, 4f);
       // InvokeRepeating("Triple", 3f, 6f);
       // InvokeRepeating("Attack", 3f, 4f);
       Invoke("Attack",5f);
    }

    // Update is called once per frame
    void Update()
    {
        if(starting){
            transform.position = Vector3.MoveTowards(transform.position, spawnpoint.position, spawnspeed);
       float dist = Vector3.Distance(transform.position, spawnpoint.position);
     if(dist < 0.1f)
     {
     starting = false;
     }

        }else{
          Ray ray = new Ray(transform.position,Vector3.down);
       if(Physics.Raycast(ray, out RaycastHit info, 10))
       {
       transform.position = info.point + new Vector3(0, hoverheight, 0);
       }
        }
      
    
        targetDirection = playerloc.position - transform.position;
       transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward,  targetDirection, 0.01f, 0.0f));
       transform.rotation = Quaternion.Euler(lockPos, transform.rotation.eulerAngles.y, lockPos);
       


       if(handmoving){

        if(throwingright){
       righthandik.position = Vector3.MoveTowards(righthandik.position, rightthrowpoint.position, speed);
       float dist = Vector3.Distance(righthandik.position, rightthrowpoint.position);
     if(dist < 0.01f)
     {
     throwingright = false;
     returningright = true;
     Shoot(rightthrowpoint);
     }
        }else if(returningright){
       righthandik.position = Vector3.MoveTowards(righthandik.position, righthandnut.position, speed);
       float dist = Vector3.Distance(righthandik.position, righthandnut.position);
     if(dist < 0.01f)
     {
     returningright = false;
      handmoving = false;

     }

        }
     if(throwingleft){
       lefthandik.position = Vector3.MoveTowards(lefthandik.position, leftthrowpoint.position, speed);
       float dist = Vector3.Distance(lefthandik.position, leftthrowpoint.position);
     if(dist < 0.01f)
     {
     throwingleft = false;
     returningleft = true;
     Shoot(leftthrowpoint);
     }
        }else if(returningleft){
       lefthandik.position = Vector3.MoveTowards(lefthandik.position, lefthandnut.position, speed);
       float dist = Vector3.Distance(lefthandik.position, lefthandnut.position);
     if(dist < 0.01f)
     {
     returningleft = false;
      handmoving = false;

     }

        }
       
       
         if(lobbbing){
       lefthandik.position = Vector3.MoveTowards(lefthandik.position, lobpoint.position, speed);
       righthandik.position = Vector3.MoveTowards(righthandik.position, lobpoint.position, speed);
       float dist = Vector3.Distance(lefthandik.position, lobpoint.position);
       float dist2 = Vector3.Distance(righthandik.position, lobpoint.position);
     if(dist < 1f && dist2 < 1f)
     {
     returningright = true;
     returningleft = true;
     lobbbing = false;

     }
       
       }
       }




    }

     void Shoot(Transform fire)
    {
        fire.LookAt(playerloc);
        fire.Rotate(-45f,0f,0f);
        float disttoplayer = Vector3.Distance(transform.position, playerloc.position);
        float shotpower = -19.87f + (50.2f*disttoplayer) - (4.24f*(disttoplayer*disttoplayer))+(0.166f*(disttoplayer*disttoplayer*disttoplayer));
        Debug.Log(disttoplayer);
        Debug.Log(shotpower);

        int rad = Random.Range(1, 10);
         GameObject shotIn = Instantiate(prefabBall, fire.position,   Random.rotation);
         Rigidbody rb = shotIn.GetComponent<Rigidbody>();

         rb.AddForce(fire.forward*(shotpower+rad), ForceMode.Force);
         Destroy(shotIn,8);
         

    }
    void throwRight()
    {
    throwingright = true;
    handmoving = true;
    }
    void throwLeft()
    {
    throwingleft = true;
    handmoving = true;
    }
    void Triple()
    {
        if(tripright){
        throwRight();
        Invoke("throwLeft",0.6f);
        Invoke("throwRight",1.2f);
        }else{
            throwLeft();
            Invoke("throwRight",0.6f);
            Invoke("throwLeft",1.2f);
        }
    }

    void Loglob()
    {


    }



    void Attack()
    {
        int rad = Random.Range(1, 5);
        if(rad ==1){
            throwLeft();
        }else if(rad == 2){
            throwRight();
        }else if(rad == 3){
        tripright = false;   
        Triple();
        }else if(rad == 4){
        tripright = true;    
        Triple();
        }//else if(rad == 5){
      //  lobbbing = true;
       // }
       float rad2 = Random.Range(2.1f, 3.3f);
       Invoke("Attack",rad2);


    }

}
