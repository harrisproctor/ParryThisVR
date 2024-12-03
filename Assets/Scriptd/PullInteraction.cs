using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PullInteraction : XRBaseInteractable
{
    
public static event Action<float> PullActionReleased;

public Transform start, end;
public GameObject notch;
public Vector3 offset; 
public float multiplicative;

public float pullAmount { get; private set; } = 0.0f;

private LineRenderer _lineRenderer;
private IXRSelectInteractor pullingInteractor = null;

protected override void Awake()
{
base.Awake(); 
_lineRenderer = GetComponent<LineRenderer>();
}


public void SetPullInteractor (SelectEnterEventArgs args)
{
   // Debug.Log("click start");
pullingInteractor = args.interactorObject;
//Debug.Log("click done");

}


public void Release()
{
//Debug.Log("release start");
PullActionReleased?.Invoke(pullAmount);
pullingInteractor = null;
pullAmount = 0.0f;
notch.transform.localPosition = new Vector3(notch.transform.localPosition.x, notch.transform.localPosition.y, 0f);

UpdateString();
//Debug.Log("release done" + pullAmount);
}

public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
{
    base.ProcessInteractable(updatePhase);
    if (updatePhase == XRInteractionUpdateOrder.UpdatePhase.Dynamic)
    {
        if (isSelected)
        {
            Vector3 pullPosition = pullingInteractor.transform.position; 
            pullAmount = CalculatePull(pullPosition);
            UpdateString();
        }
    }
}

private float CalculatePull(Vector3 pullPosition)
{
    Vector3 pullDirection = pullPosition - start.position;
    Vector3 targetDirection = end.position - start.position;
    float maxLength = targetDirection.magnitude;

    targetDirection.Normalize();
    float pullValue = Vector3.Dot(pullDirection, targetDirection) / maxLength;
    return Mathf.Clamp(pullValue, 0, 1);
}

private void UpdateString()
{
 //Debug.Log("pulla = " + pullAmount);
 Vector3 linePosition = Vector3.forward * Mathf.Lerp(start.transform.localPosition.z, end.transform.localPosition.z, pullAmount); 
 notch.transform.localPosition = new Vector3(notch.transform.localPosition.x, notch.transform.localPosition.y, linePosition.z);
 linePosition = linePosition + offset;
 linePosition.z = linePosition.z * multiplicative;
 //Debug.Log("linepos = " + linePosition);
 _lineRenderer.SetPosition(1, linePosition);
}









}
