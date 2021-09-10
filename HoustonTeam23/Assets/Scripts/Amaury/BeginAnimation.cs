using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BeginAnimation : MonoBehaviour {

    public bool runAnim;

    public float speedText;
    public Text text;


    private string[] dialogs = {"....","....","Huston, nous avons un problème"};
    private bool finishDialog;
    private int dialogLength;

    public Image white,black;
    public bool fade = true;
    public float alpha,fadeTimer;
    private bool beginDialog;

    public GameObject dialogFont;

    public AudioSource[] sounds;

    public static BeginAnimation instance;

    void Awake() {
        instance = this;
    }

    void Start()
    {
        alpha = white.color.a;
        dialogFont.SetActive(false);
    }

    void Update()
    {
        if(runAnim) {
            if(fade) {
                fadeTimer += Time.deltaTime;

                if(fadeTimer >= 0.005) {
                    alpha -= 0.05f;
                    white.color = new Color(white.color.r,white.color.g,white.color.b,alpha);

                    if(white.color.a <= 0)
                        fade = false;

                    fadeTimer = 0;
                }    
        }

        else {
            if(finishDialog) {
                if(Input.GetKeyDown(KeyCode.E))  {
                    if(dialogLength != 3) {
                        dialogFont.SetActive(false);
                        StartCoroutine(WaitDialog(2f));
                    }  
                    else {
                        runAnim = false;
                        black.gameObject.SetActive(false);
                        dialogFont.SetActive(false);
                    }           
                }
            }
            else {
                if(!beginDialog) {
                    beginDialog = true;
                    StartCoroutine(WaitDialog(2f));
                }
            }
        }
        }
    }


    public IEnumerator ShowText(string displayText) {
        beginDialog = true;
        dialogFont.SetActive(true);



        for(int i = 1;i<displayText.Length + 1;i++) {
           yield return new WaitForSeconds(speedText);
           text.text = displayText.Substring(0,i);
       }

       finishDialog = true;

    }

    public IEnumerator WaitDialog(float timeToWait) {
        yield return new WaitForSeconds(timeToWait);

        if(dialogLength == 0) {
            StartCoroutine(UIShake.instance.Shake(1f, 2f));     
            sounds[0].Play();
            sounds[0].volume = 0.1f;
        }
        if(dialogLength == 1) {
            StartCoroutine(UIShake.instance.Shake(1f, 2.5f));   
            sounds[0].Play();
            sounds[0].volume = 0.5f;
        }
        if(dialogLength == 2) 
            sounds[1].Play();
        

        StartCoroutine(ShowText(dialogs[dialogLength]));
        dialogLength++;

    }

    public IEnumerator Timer() {
        yield return new WaitForSeconds(3f);
        
        dialogFont.SetActive(false);

    }

}
