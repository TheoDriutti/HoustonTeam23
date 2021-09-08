using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestClignotement : MonoBehaviour {

    private float timer,step;
    private float maxTimer = 2;

    void Start(){}

    void Update() {
        timer += Time.deltaTime;
        step += Time.deltaTime;

        if(timer < maxTimer) {
            if(step > 0.15f) {
                transform.gameObject.GetComponent<Image>().enabled = !transform.gameObject.GetComponent<Image>().enabled;
                step = 0;
            }
        }
        else {
            transform.gameObject.GetComponent<Image>().enabled = true;
        }
    }
}
