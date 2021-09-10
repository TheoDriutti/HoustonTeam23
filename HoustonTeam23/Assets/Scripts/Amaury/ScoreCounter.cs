using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour {
    
    public float score = 0;
    public int baseMultiplier;
    public int streakMultiplier = 1;
    public float streakInterval;

    public Text scoreText;
    public Text feedbackText;

    public static ScoreCounter instance;

    void Awake() {
        instance = this;
    }

    private void Start()
    {
        score = 0;
        streakMultiplier = 1;
        scoreText.text = "0";
    }

    void Update()
    {
        score += streakMultiplier * baseMultiplier * Time.deltaTime;
        scoreText.text = "" + (int)score;
    }

    public void UpdateFeedback()
    {
        if (streakMultiplier > 1)
        {
            feedbackText.text = "x" + streakMultiplier;
        }
        else
        {
            feedbackText.text = "";
        }
    }

}
