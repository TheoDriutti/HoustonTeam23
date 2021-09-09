using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour {
    
    public List<int> collideObj;

    public float score;
    public int dodge;

    public static ScoreCounter instance;

    public Text text;

    
    public int timerScorePerMiliSecond;

    void Start() {
        collideObj = new List<int>();
        instance = this;
    }


    void Update() {

        foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Pool")) {
            for(int i = 0;i < obj.transform.childCount;i++) {
                float distance = obj.transform.GetChild(i).position.z - transform.position.z;

                if(distance < 0 && !collideObj.Contains(obj.GetComponent<ObstacleMovement>().id)) {
                    dodge++;
                    collideObj.Remove(obj.GetComponent<ObstacleMovement>().id);
                }
            }
        }

        score += Time.deltaTime  * timerScorePerMiliSecond;
        score += dodge;

        text.text = "Score: " + (int)score;
    }
}
