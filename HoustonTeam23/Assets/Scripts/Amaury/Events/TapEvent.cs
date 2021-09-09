using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapEvent : Event {

    public KeyCode lastKey;
    public KeyCode[] keys;
    public int counter,maxCounter;

    public float lastTimeKeyDown;

   void Update() {
       foreach (KeyCode key in keys)
       {

        //  if(tapEvent.lastTimeKeyDown == 0 || tapEvent.lastTimeKeyDown - Time.deltaTime <= 0.1f) {
        if (Input.GetKeyDown(key) && (key == lastKey || lastKey == KeyCode.None))
           {
                counter++;
                lastKey = key;
                lastTimeKeyDown = Time.deltaTime;
            }
            else if (Input.GetKeyDown(key) && key != lastKey && lastKey != KeyCode.None)
            {
                counter = 1;
                lastKey = key;
                lastTimeKeyDown = Time.deltaTime;
            }
          //} Rajouter le timer 
       }

   } 
}
