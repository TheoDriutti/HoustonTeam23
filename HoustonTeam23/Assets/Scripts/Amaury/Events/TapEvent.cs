using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapEvent : Event {

    public KeyCode lastKey;
    public KeyCode[] keys;
    public int counter,maxCounter;
    public int delay;

    public float lastTimeKeyDown;
}
