using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float verticalSpeed;
    public float horizontalSpeed;

    public float maxTurnRotation = 35f;
    public AnimationCurve turnBehavior;

    public DelayEvent inputDelay;
    public HorizontalEvent horizontalInversion;
    public VerticalEvent verticalInversion;

    private float horiInput;
    private float vertiInput;

    //singleton
    private static PlayerController _i;
    public static PlayerController i { get { return _i; } }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (_i != null && _i != this)
            Destroy(gameObject);
        _i = this;
    }

    // Update is called once per frame
    void Update()
    {
        horiInput = horizontalInversion.value ? -Input.GetAxis("Horizontal") : Input.GetAxis("Horizontal");
        vertiInput = verticalInversion.value ? -Input.GetAxis("Vertical") : Input.GetAxis("Vertical");

        if (Mathf.Abs(horiInput) > 0f)
        {
            if (inputDelay.value)
            {
                Invoke("MoveHorizontal", inputDelay.duration);
            }
            else
            {
                MoveHorizontal();
            }
        }

        if (Mathf.Abs(vertiInput) > 0f)
        {
            if (inputDelay.value)
            {
                Invoke("MoveVertical", inputDelay.duration);
            }
            else
            {
                MoveVertical();
            }
        }
    }

    private void MoveHorizontal()
    {
        float horiNewPos = transform.position.x + horizontalSpeed * horiInput * Time.deltaTime;

        if (Mathf.Abs(horiNewPos) < GameData.i.horizontalGameSize)
        {
            transform.position = new Vector3(horiNewPos, transform.position.y, transform.position.z);

            float shipAngle = turnBehavior.Evaluate(Mathf.Abs(horiNewPos) / GameData.i.horizontalGameSize) * maxTurnRotation * Mathf.Sign(horiNewPos);
            transform.rotation = Quaternion.Euler(0, 0, shipAngle);
        }
    }

    private void MoveVertical()
    {
        float vertiNewPos = transform.position.y + verticalSpeed * vertiInput * Time.deltaTime;

        if (GameData.i.verticalGameSize.x < vertiNewPos && vertiNewPos < GameData.i.verticalGameSize.y)
        {
            transform.position = new Vector3(transform.position.x, vertiNewPos, transform.position.z);
        }
    }
}
