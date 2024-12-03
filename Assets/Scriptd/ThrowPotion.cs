using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ThrowPotion : XRGrabInteractable
{
    public GameObject prefabBall;
    public Vector3 offset;
    public Transform firePlace;
    public int shots;
   

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
                
                GameObject shotIn = Instantiate(prefabBall, firePlace.position, transform.rotation);
                
                Rigidbody rb = shotIn.GetComponent<Rigidbody>();

                Vector3 throwVel = gameObject.GetComponent<Rigidbody>().velocity;

                rb.AddForce(throwVel, ForceMode.Force);
                Destroy(shotIn,8);
                shots -= 1;
                 if(shots == 0)
                {
                Destroy(gameObject);
                }
        
        
        
        
            }
        }
        
    }
}
