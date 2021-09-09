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
    void Start()
    {
        StartCoroutine(ShowText(dialogs[0]));
    }

    void Update()
    {
        if(finishDialog) {
            if(Input.GetKeyDown(KeyCode.E)) {
                if(dialogLength < 2) {
                    dialogLength++;
                    StartCoroutine(ShowText(dialogs[dialogLength]));
                }
            }
        }
    }


    public IEnumerator ShowText(string displayText) {
        for(int i = 1;i<displayText.Length + 1;i++) {
           yield return new WaitForSeconds(speedText);
           text.text = displayText.Substring(0,i);
       }

       finishDialog = true;

    }

}
