using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapEvent : Event {

    public KeyCode lastKey;
    public KeyCode[] keys;
    public int counter,maxCounter;

   void Update() {
       foreach (KeyCode key in keys)
       {
            if (Input.GetKeyDown(key) && (key == lastKey || lastKey == KeyCode.None))
            {
                counter++;
                lastKey = key;
            }
            else if (Input.GetKeyDown(key) && key != lastKey && lastKey != KeyCode.None)
            {
                counter = 1;
                lastKey = key;
            }
        } 

        if(!Input.GetKey(lastKey) && counter >= maxCounter) 
            counter = 0;   
   } 
}
