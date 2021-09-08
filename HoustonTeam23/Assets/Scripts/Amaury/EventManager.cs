using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {

/* Events */
    public Event freezeEvent;
    public Event horizontalEvent;
    public Event verticalEvent;
    public DelayEvent delayEvent;
    public FlipCameraEvent flipCameraEvent;
    public Event tapEvent;
    public Event inertiaEvent;

/* Movement */
    public float speed;
    private float x,y,originalSpeed;   


/* Incibility */
    public bool hurt;
    private float hurtTimer,flashingTimer;
    public float maxHurtTimer,flashingTime;
    public MeshRenderer[] spatialship;


    /* Tap Event */
    private KeyCode lastKey;
    public KeyCode[] keys;

    void Start() { 
        flipCameraEvent.camera = transform.parent.gameObject;
        originalSpeed = speed;
    }

    /*
        Inversion axe horizontale / Inversion axe verticale - Fait
        Immobilisation temporaire  -Fait 
        Retournement de la fusée -> retournement écran + inversion combinée axes - et | - Fait
        Délai avant que le déplacement ne se fasse (valeur à tweaker) : tu appuies sur ->, il y a un temps avant que le vaisseau aille à droite - Fait
        Invicibilité avec clignotement a la mario - Fait 
        Double tap/triple tap des commandes - fait 

        Accélération/décélération du vaisseau - Attendre déplacement fusée   
        Inertie plus/moins forte du vaisseau - Attendre déplacement fusée   
    */


// < >
    void Update() {

        if(!delayEvent.value && !tapEvent.value)  // Il n'y a pas de délai sur l'éxécution des commandes 
            actualizePosition();
        else if(delayEvent.value) { // Il y a un délai sur l'éxecution des commandes 
            if(Input.GetAxis("Horizontal") != 0 && delayEvent.lastHInput >= -0.1f && delayEvent.lastHInput <= 0.1f ) { // Le joueur vient d'appuyer pour la première fois sur une touche de direction
                delayEvent.hDelayTimer += Time.deltaTime;

                 if(delayEvent.hDelayTimer < delayEvent.hMaxDelayTimer) 
                    return;            
                else 
                    actualizePosition(); 

            }

            if(Input.GetAxis("Vertical") != 0 && delayEvent.lastVInput >= -0.1f && delayEvent.lastVInput <= 0.1f) { // Le joueur vient d'appuyer pour la première fois sur une touche de direction
                delayEvent.vDelayTimer += Time.deltaTime;

                if(delayEvent.vDelayTimer < delayEvent.vMaxDelayTimer) 
                    return;
                else  
                    actualizePosition();
                                       
            }

            delayEvent.lastHInput = Input.GetAxis("Horizontal");
            delayEvent.lastVInput = Input.GetAxis("Vertical");
        }
        else if(tapEvent.value) {
            foreach(KeyCode key in keys) {
                
                if(Input.GetKeyDown(key) && (key == lastKey || lastKey == KeyCode.None)) {
                   // tapEvent.counter++;
                    lastKey = key;
                }
                else if(Input.GetKeyDown(key) && key != lastKey && lastKey != KeyCode.None) {
                   // tapEvent.counter = 1;
                    lastKey = key;
                }
            }

           /* if(tapEvent.counter < tapEvent.maxCounter) 
                return;
            else 
                actualizePosition();
        */
        }


      /*  if(inertiaEvent.value)
            speed -= inertiaEvent.counter;
*/
        

        transform.Translate(x,y,0);

        flipCamera();
        hurtRock();
        
        
    }

    private void actualizePosition() {
        
        float xAxis = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float yAxis = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        x = freezeEvent.value ? 0 : flipCameraEvent.value ? verticalEvent.value ? yAxis : yAxis * -1 : horizontalEvent.value ? xAxis : xAxis * -1;
        y = freezeEvent.value ? 0 : flipCameraEvent.value ? horizontalEvent.value ? xAxis : xAxis * -1 : verticalEvent.value ? yAxis : yAxis * -1;

        delayEvent.hDelayTimer = 0;
        delayEvent.vDelayTimer = 0;
    }

    private void flipCamera() {
        GameObject camera = flipCameraEvent.camera;
        if(flipCameraEvent.value) {
            if(camera.transform.eulerAngles.z == 0 || flipCameraEvent.flipRotate) {
                camera.transform.rotation = Quaternion.RotateTowards(camera.transform.rotation,Quaternion.Euler(0,0,180),flipCameraEvent.flipSpeed * Time.deltaTime);
                flipCameraEvent.flipRotate = true;

                if(flipCameraEvent.camera.transform.eulerAngles.z == 180)
                    flipCameraEvent.flipRotate = false;

            }
        }
        else {
            if(camera.transform.eulerAngles.z == 180 || flipCameraEvent.flipRotate) {
                camera.transform.rotation = Quaternion.RotateTowards(camera.transform.rotation,Quaternion.Euler(0,0,0),flipCameraEvent.flipSpeed * Time.deltaTime);
                flipCameraEvent.flipRotate = true;

                if(camera.transform.eulerAngles.z == 0)
                    flipCameraEvent.flipRotate = false;
            }
        }
    }

    private void hurtRock() {
        if(hurt) {
            hurtTimer += Time.deltaTime;

            if(hurtTimer < maxHurtTimer) {
                flashingTimer += Time.deltaTime;

                if(flashingTimer >= flashingTime) {
                    foreach(MeshRenderer renderer in spatialship) 
                        renderer.enabled = !renderer.enabled;

                    flashingTimer = 0;
                }
                
            }
            else {
                foreach(MeshRenderer renderer in spatialship) 
                    renderer.enabled = true;
                    
                hurt = false;
                hurtTimer = 0;           
            }
        }
    }


}
