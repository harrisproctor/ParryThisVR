using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RaygunPotion : XRGrabInteractable
{
    
    public Transform firePlace;
    public int shots;
    public GameObject Fire;
    public GameObject hitfire;
   

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        base.ProcessInteractable(updatePhase);
        
        if(updatePhase == XRInteractionUpdateOrder.UpdatePhase.Dynamic)
        {
            if(isSelected)
            {
            shoot();
            }
        }

    }
    void shoot()
    {
        if(firstInteractorSelecting is XRBaseControllerInteractor interactor)
        {
            InteractionState activateState = interactor.xrController.activateInteractionState;
            if(activateState.activatedThisFrame)
            {
                RaycastHit hit;

                if(Physics.Raycast(firePlace.position, transform.TransformDirection(Vector3.forward), out hit, 100))
                {
                Debug.DrawRay(firePlace.position, transform.TransformDirection(Vector3.forward)*hit.distance, Color.yellow);

                //at hit play particle
                GameObject a = Instantiate(hitfire,hit.point, Quaternion.identity);
                Destroy(a, 1);
                //at gun
                GameObject b = Instantiate(Fire, firePlace.position, Quaternion.identity);
                Destroy(b, 1);

                //code to get script called enemy attached to where ray hit
                //Enemy ene = hit.transform.GetComponent<Enemy>();


                }
                
               
        
        
        
            }
        }
        
    }
}
