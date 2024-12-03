using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TREEMANFOOT : MonoBehaviour
{

    bool grounded = false;
    public Transform poin;
    Vector3 currentPosition;
    Vector3 oldPosition;
    Vector3 newPosition;
    public float stepHeight;
    public float stepDistance;
    public float lerp;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        currentPosition = transform.position;
        newPosition = transform.position;
        oldPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = currentPosition;    

       Ray ray = new Ray(poin.position,Vector3.down);
       if(Physics.Raycast(ray, out RaycastHit info, 10))
       {
       //transform.position = info.point;
       if(Vector3.Distance(newPosition, info.point) > stepDistance)
       {
           lerp = 0;
           newPosition = info.point;
       }
       }
       if (lerp < 1)
       {
           Vector3 footPosition = Vector3.Lerp(oldPosition,newPosition,lerp);
           footPosition.y += Mathf.Sin(lerp * Mathf.PI) * stepHeight;

           currentPosition = footPosition;
           lerp += Time.deltaTime * speed;



       }else{
           oldPosition = newPosition;
       }


    }


}
