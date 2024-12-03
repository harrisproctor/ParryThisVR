using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class TeleportationManager : MonoBehaviour
{
    public XRRayInteractor leftTeleportRay;
    public XRRayInteractor rightTeleportRay;
    public InputHelpers.Button teleportActivationButton;
    public float activationThreshold = 0.1f;
    private TeleportationProvider teleportationProvider;

    void Start()
    {
        teleportationProvider = GetComponent<TeleportationProvider>();
    }

    void Update()
    {
        if (leftTeleportRay)
        {
            CheckIfActivated(leftTeleportRay);
        }

        if (rightTeleportRay)
        {
            CheckIfActivated(rightTeleportRay);
        }
    }

    private void CheckIfActivated(XRRayInteractor rayInteractor)
    {
        XRController controller = rayInteractor.GetComponent<XRController>();
        if (controller != null)
        {
            if (InputHelpers.IsPressed(controller.inputDevice, teleportActivationButton, out bool isActivated, activationThreshold) && isActivated)
            {
                Debug.Log("Teleportation button pressed on " + rayInteractor.name);
                TryTeleport(rayInteractor);
            }
        }
    }

    private void TryTeleport(XRRayInteractor rayInteractor)
    {
        if (rayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit))
        {
            Debug.Log("Hit point: " + hit.point);
            TeleportRequest request = new TeleportRequest()
            {
                destinationPosition = hit.point,
            };
            teleportationProvider.QueueTeleportRequest(request);
            Debug.Log("Teleportation request queued.");
        }
        else
        {
            Debug.Log("No valid hit for teleportation.");
        }
    }
}
