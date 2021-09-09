using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedEvent : Event
{
   public float amplifier;
   public float speedTimer,stepTimer;
   public float maxSpeedTimer;

   public int index;

   public PlayerController pController;

   // Faire une fonction OnFinish qui sexecute a la fin de mon event

   void Update() {
       if (value)
      {  
         float step = maxSpeedTimer / 5;

         if (speedTimer <= maxSpeedTimer)
            {
            speedTimer += Time.deltaTime;
            stepTimer += Time.deltaTime;

            if (stepTimer >= step - 0.05f)
               {
                  pController.horizontalSpeed += amplifier / 5;
                  pController.verticalSpeed += amplifier / 5;
                  index++;
                  stepTimer = 0;
               }
         }
      }
   }
}
