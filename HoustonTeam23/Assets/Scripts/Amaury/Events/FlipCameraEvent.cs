using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipCameraEvent : Event
{
    public float flipSpeed;
    public bool flipRotate;

    private void Update()
    {

        GameObject camera = Camera.main.gameObject;
        if (value)
        {
            if (camera.transform.eulerAngles.z == 0 || flipRotate)
            {
                camera.transform.rotation = Quaternion.RotateTowards(camera.transform.rotation, Quaternion.Euler(0, 0, 180), flipSpeed * Time.deltaTime);
                flipRotate = true;

                if (camera.transform.eulerAngles.z == 180)
                    flipRotate = false;

            }
        }
        else
        {
            if (camera.transform.eulerAngles.z == 180 || flipRotate)
            {
                camera.transform.rotation = Quaternion.RotateTowards(camera.transform.rotation, Quaternion.Euler(0, 0, 0), flipSpeed * Time.deltaTime);
                flipRotate = true;

                if (camera.transform.eulerAngles.z == 0)
                    flipRotate = false;
            }

        }
    }
}
