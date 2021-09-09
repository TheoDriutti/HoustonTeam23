using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InertiaEvent : Event
{
    public int inertiaValue;
    public PlayerController pController;
    
    
    private float originalHorizontalSpeed;
    private float originalVerticalSpeed;

    void Start() {
        originalHorizontalSpeed = pController.horizontalSpeed;
        originalVerticalSpeed = pController.verticalSpeed;
    }

    void Update() {
        if (value && pController.horizontalSpeed == originalHorizontalSpeed) {
            pController.horizontalSpeed -= inertiaValue;
            pController.verticalSpeed -= inertiaValue;
        }
        else if (!value && pController.horizontalSpeed != originalHorizontalSpeed) {
            pController.horizontalSpeed = originalHorizontalSpeed;
            pController.verticalSpeed = originalVerticalSpeed;
        }
    }
}
