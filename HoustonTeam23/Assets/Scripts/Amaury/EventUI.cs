using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventUI : MonoBehaviour
{
    public Image malus;

    private float timer, step;

    public float flashTime;
    public float preventMalusTime;

    public void Flash()
    {
        if(!EventAudio.instance.malusAnnoucement.isPlaying) 
            EventAudio.instance.malusAnnoucement.Play();
        
        timer += Time.deltaTime;
        step += Time.deltaTime;

        if (timer < preventMalusTime)
        {
            if (step > flashTime)
            {
                malus.enabled = !malus.enabled;
                step = 0f;
            }
        }
        else
        {
            timer = 0f;
            malus.enabled = true;
        }
    }

    public void DisplayIcon(Event currentEvent,bool active) {
        malus.sprite = currentEvent.icon;
        malus.enabled = active;
    }
}
