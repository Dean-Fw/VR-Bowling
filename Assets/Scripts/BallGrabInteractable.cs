using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BallGrabInteractable : XRGrabInteractable
{
    private Rigidbody ballRigidbody;
    private bool isGrabbed;

    protected override void Awake()
    {
        base.Awake();
        ballRigidbody = GetComponent<Rigidbody>();
    }

    protected override void OnSelectEntered(XRBaseInteractor interactor)
    {
        base.OnSelectEntered(interactor);
        isGrabbed = true;

        // Disable physics simulation
        ballRigidbody.isKinematic = true;
    }

    protected override void OnSelectExited(XRBaseInteractor interactor)
    {
        base.OnSelectExited(interactor);
        isGrabbed = false;

        // Enable physics simulation
        ballRigidbody.isKinematic = false;
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        // Enable physics simulation when the object is disabled
        if (isGrabbed)
            ballRigidbody.isKinematic = false;
    }
}
