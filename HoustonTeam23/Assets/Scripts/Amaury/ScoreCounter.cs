using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour {
    
    public List<GameObject> collideObj;

    void Start() {
        collideObj = new List<GameObject>();
    }


    void Update() {

        foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Pool")) {
            for(int i = 0;i < obj.transform.childCount;i++) {
                float distance = obj.transform.GetChild(i).position.z - transform.position.z;

               // if(distance < 0 && colli)
            }
        }
    }
}
