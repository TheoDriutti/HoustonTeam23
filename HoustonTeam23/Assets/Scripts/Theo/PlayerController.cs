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
    public FreezeEvent freeze;
    public TapEvent tap;

    private float horiInput;
    private float vertiInput;

    //singleton
    private static PlayerController _i;
    public static PlayerController i { get { return _i; } }


    public bool hurt;
    private float hurtTimer, flashingTimer;
    public float maxHurtTimer, flashingTime;
    public MeshRenderer[] spatialship;

    private void Awake()
    {
        if (_i != null && _i != this)
            Destroy(gameObject);
        _i = this;
    }

    void Update()
    {
        horiInput = horizontalInversion.value ? -Input.GetAxis("Horizontal") : Input.GetAxis("Horizontal");
        vertiInput = verticalInversion.value ? -Input.GetAxis("Vertical") : Input.GetAxis("Vertical");

        if (tap.value) {
            if (tap.counter < tap.maxCounter) return;          
        }


        if (Mathf.Abs(horiInput) > 0f && !freeze.value)
        {

            if (inputDelay.value)
            {
                if (inputDelay.delayTimer < inputDelay.duration)
                {
                    inputDelay.delayTimer += Time.deltaTime;
                    return;
                }

                MoveVertical();
                inputDelay.delayTimer = 0;
            }
            else
            {
                MoveHorizontal();
            }
        }

        if (Mathf.Abs(vertiInput) > 0f && !freeze.value)
        {

            if (inputDelay.value)
            {
                if (inputDelay.delayTimer < inputDelay.duration)
                {
                    inputDelay.delayTimer += Time.deltaTime;
                    return;
                }

                MoveVertical();
                inputDelay.delayTimer = 0;
            }
            else
            {
                MoveVertical();
            }
        }

        hurtRock();
    }

    private void MoveHorizontal()
    {
        float horiNewPos = transform.position.x + horizontalSpeed * horiInput * Time.deltaTime;

        if (Mathf.Abs(horiNewPos) < GameData.i.horizontalGameSize)
        {
            transform.position = new Vector3(horiNewPos, transform.position.y, transform.position.z);

            float shipAngle = turnBehavior.Evaluate(Mathf.Abs(horiNewPos) / GameData.i.horizontalGameSize) * maxTurnRotation * Mathf.Sign(horiNewPos);
            transform.localRotation = Quaternion.Euler(0, shipAngle, 0);
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

    private void hurtRock()
    {
        if (hurt)
        {
            hurtTimer += Time.deltaTime;

            if (hurtTimer < maxHurtTimer)
            {
                flashingTimer += Time.deltaTime;

                if (flashingTimer >= flashingTime)
                {
                    foreach (MeshRenderer renderer in spatialship)
                        renderer.enabled = !renderer.enabled;

                    flashingTimer = 0;
                }

            }
            else
            {
                foreach (MeshRenderer renderer in spatialship)
                    renderer.enabled = true;

                hurt = false;
                hurtTimer = 0;
            }
        }
    }
}
