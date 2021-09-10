using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventAudio : MonoBehaviour
{
    
    public static EventAudio instance;

    public AudioSource moove;
    public AudioSource moove_reverse;

    public AudioSource explosion;
    public AudioSource impactFullHealth;
    public AudioSource impactLowHealth;

    public AudioSource malusAnnoucement;
    public AudioSource acceleration;
    public AudioSource deceleration;

    void Awake() {
        instance = this;
    }
}
