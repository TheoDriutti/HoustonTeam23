using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipCameraEvent : Event
{
    public float flipSpeed;
    public bool flipRotate;

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.H))
        {
            value = true;
        }
        GameObject camera = Camera.main.gameObject;
        if (value)
        {
            if (Mathf.Abs(camera.transform.eulerAngles.z) <= 2f || Mathf.Abs(camera.transform.eulerAngles.z) >= 357 || flipRotate)
            {
                camera.transform.rotation = Quaternion.RotateTowards(camera.transform.rotation, Quaternion.Euler(0, 0, 180), flipSpeed * Time.deltaTime);

                flipRotate = true;

                if (178 <= Mathf.Abs(camera.transform.eulerAngles.z) && Mathf.Abs(camera.transform.eulerAngles.z) <= 182)
                    flipRotate = false;

            }
        }
        else
        {
            if ((178 <= Mathf.Abs(camera.transform.eulerAngles.z) && Mathf.Abs(camera.transform.eulerAngles.z) <= 182) || flipRotate)
            {
                camera.transform.rotation = Quaternion.RotateTowards(camera.transform.rotation, Quaternion.Euler(0, 0, 0), flipSpeed * Time.deltaTime);
                flipRotate = true;

                if (camera.transform.eulerAngles.z == 0)
                    flipRotate = false;
            }

        }
    }
}
