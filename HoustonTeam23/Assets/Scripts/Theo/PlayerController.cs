using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float verticalSpeed;
    public float horizontalSpeed;

    public float maxTurnRotation = 35f;
    public AnimationCurve turnBehavior;

    // Update is called once per frame
    void Update()
    {
        float horiInput = Input.GetAxis("Horizontal");
        float vertiInput = Input.GetAxis("Vertical");

        if (Mathf.Abs(horiInput) > 0f)
        {
            float horiNewPos = transform.position.x + horizontalSpeed * horiInput * Time.deltaTime;

            if (Mathf.Abs(horiNewPos) < GameData.i.horizontalGameSize)
            {
                transform.position = new Vector3(horiNewPos, transform.position.y, transform.position.z);

                float shipAngle = turnBehavior.Evaluate(Mathf.Abs(horiNewPos) / GameData.i.horizontalGameSize) * maxTurnRotation * Mathf.Sign(horiNewPos);
                transform.rotation = Quaternion.Euler(0, 0, shipAngle);
            }
        }

        if (Mathf.Abs(vertiInput) > 0f)
        {
            float vertiNewPos = transform.position.y + verticalSpeed * vertiInput * Time.deltaTime;

            if (GameData.i.verticalGameSize.x < vertiNewPos && vertiNewPos < GameData.i.verticalGameSize.y)
            {
                transform.position = new Vector3(transform.position.x, vertiNewPos, transform.position.z);
            }
        }
    }
}
