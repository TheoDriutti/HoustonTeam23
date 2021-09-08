using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{

    //public PlayerController pController;
    ///* Events */
    //public FreezeEvent freezeEvent;
    //public HorizontalEvent horizontalEvent;
    //public VerticalEvent verticalEvent;
    //public DelayEvent delayEvent;
    //public FlipCameraEvent flipCameraEvent;
    //public TapEvent tapEvent;
    //public InertiaEvent inertiaEvent;
    //public SpeedEvent speedEvent;

    ///* Movement */
    //private float x, y, originalHorizontalSpeed, originalVerticalSpeed;

    ///* Incibility */
    //public bool hurt;
    //private float hurtTimer, flashingTimer;
    //public float maxHurtTimer, flashingTime;
    //public MeshRenderer[] spatialship;
    public EventUI ui;

    //void Start()
    //{
    //    flipCameraEvent.camera = transform.parent.gameObject;
    //    originalHorizontalSpeed = pController.horizontalSpeed;
    //}


    //void Update()
    //{

    //    if (!delayEvent.value && !tapEvent.value)  // Il n'y a pas de délai sur l'éxécution des commandes 
    //        actualizePosition();
    //    else if (delayEvent.value)
    //    { // Il y a un délai sur l'éxecution des commandes 
    //        if (Input.GetAxis("Horizontal") != 0 && delayEvent.lastHInput >= -0.1f && delayEvent.lastHInput <= 0.1f)
    //        { // Le joueur vient d'appuyer pour la première fois sur une touche de direction
    //            delayEvent.hDelayTimer += Time.deltaTime;

    //            if (delayEvent.hDelayTimer < delayEvent.hMaxDelayTimer)
    //                return;
    //            else
    //                actualizePosition();

    //        }

    //        if (Input.GetAxis("Vertical") != 0 && delayEvent.lastVInput >= -0.1f && delayEvent.lastVInput <= 0.1f)
    //        { // Le joueur vient d'appuyer pour la première fois sur une touche de direction
    //            delayEvent.vDelayTimer += Time.deltaTime;

    //            if (delayEvent.vDelayTimer < delayEvent.vMaxDelayTimer)
    //                return;
    //            else
    //                actualizePosition();

    //        }

    //        delayEvent.lastHInput = Input.GetAxis("Horizontal");
    //        delayEvent.lastVInput = Input.GetAxis("Vertical");
    //    }
    //    else if (tapEvent.value)
    //    {
    //        foreach (KeyCode key in tapEvent.keys)
    //        {

    //            //if(tapEvent.lastTimeKeyDown == 0 || tapEvent.lastTimeKeyDown - Time.deltaTime <= 0.1f) {
    //            if (Input.GetKeyDown(key) && (key == tapEvent.lastKey || tapEvent.lastKey == KeyCode.None))
    //            {
    //                tapEvent.counter++;
    //                tapEvent.lastKey = key;
    //                tapEvent.lastTimeKeyDown = Time.deltaTime;
    //            }
    //            else if (Input.GetKeyDown(key) && key != tapEvent.lastKey && tapEvent.lastKey != KeyCode.None)
    //            {
    //                tapEvent.counter = 1;
    //                tapEvent.lastKey = key;
    //                tapEvent.lastTimeKeyDown = Time.deltaTime;
    //            }
    //            //} Rajouter le timer 
    //        }

    //        if (tapEvent.counter < tapEvent.maxCounter)
    //            return;
    //        else
    //            actualizePosition();

    //    }


    //    if (inertiaEvent.value && pController.horizontalSpeed == originalHorizontalSpeed)
    //        pController.horizontalSpeed -= inertiaEvent.inertiaValue;
    //    else if (!inertiaEvent.value && pController.horizontalSpeed != originalHorizontalSpeed)
    //        pController.horizontalSpeed = originalHorizontalSpeed;

    //    if (speedEvent.value)
    //    {
    //        float step = speedEvent.maxSpeedTimer / 5;

    //        if (speedEvent.speedTimer <= speedEvent.maxSpeedTimer)
    //        {
    //            speedEvent.speedTimer += Time.deltaTime;
    //            speedEvent.stepTimer += Time.deltaTime;

    //            if (speedEvent.stepTimer >= step - 0.05f)
    //            {
    //                pController.horizontalSpeed += speedEvent.amplifier / 5;
    //                pController.verticalSpeed += speedEvent.amplifier / 5;
    //                speedEvent.index++;
    //                speedEvent.stepTimer = 0;
    //            }
    //        }

    //    }


    //    transform.Translate(x, y, 0);

    //    flipCamera();
    //    hurtRock();


    //}

    //private void actualizePosition()
    //{

    //    float xAxis = Input.GetAxis("Horizontal") * pController.horizontalSpeed * Time.deltaTime;
    //    float yAxis = Input.GetAxis("Vertical") * pController.horizontalSpeed * Time.deltaTime;

    //    x = freezeEvent.value ? 0 : /*flipCameraEvent.value ?  *verticalEvent.value ? yAxis : yAxis * -1 : */horizontalEvent.value ? xAxis : xAxis * -1;
    //    y = freezeEvent.value ? 0 : /*flipCameraEvent.value ? horizontalEvent.value ? xAxis : xAxis * -1 : */verticalEvent.value ? yAxis : yAxis * -1;

    //    delayEvent.hDelayTimer = 0;
    //    delayEvent.vDelayTimer = 0;
    //}

    //private void flipCamera()
    //{
    //    GameObject camera = flipCameraEvent.camera;
    //    if (flipCameraEvent.value)
    //    {
    //        if (camera.transform.eulerAngles.z == 0 || flipCameraEvent.flipRotate)
    //        {
    //            camera.transform.rotation = Quaternion.RotateTowards(camera.transform.rotation, Quaternion.Euler(0, 0, 180), flipCameraEvent.flipSpeed * Time.deltaTime);
    //            flipCameraEvent.flipRotate = true;

    //            if (flipCameraEvent.camera.transform.eulerAngles.z == 180)
    //                flipCameraEvent.flipRotate = false;

    //        }
    //    }
    //    else
    //    {
    //        if (camera.transform.eulerAngles.z == 180 || flipCameraEvent.flipRotate)
    //        {
    //            camera.transform.rotation = Quaternion.RotateTowards(camera.transform.rotation, Quaternion.Euler(0, 0, 0), flipCameraEvent.flipSpeed * Time.deltaTime);
    //            flipCameraEvent.flipRotate = true;

    //            if (camera.transform.eulerAngles.z == 0)
    //                flipCameraEvent.flipRotate = false;
    //        }
    //    }
    //}

    //private void hurtRock()
    //{
    //    if (hurt)
    //    {
    //        hurtTimer += Time.deltaTime;

    //        if (hurtTimer < maxHurtTimer)
    //        {
    //            flashingTimer += Time.deltaTime;

    //            if (flashingTimer >= flashingTime)
    //            {
    //                foreach (MeshRenderer renderer in spatialship)
    //                    renderer.enabled = !renderer.enabled;

    //                flashingTimer = 0;
    //            }

    //        }
    //        else
    //        {
    //            foreach (MeshRenderer renderer in spatialship)
    //                renderer.enabled = true;

    //            hurt = false;
    //            hurtTimer = 0;
    //        }
    //    }
    //}


}
