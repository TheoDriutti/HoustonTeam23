using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public float horizontalGameSize;
    public Vector2 verticalGameSize;

    // singleton
    private static GameData _i;
    public static GameData i { get { return _i; } }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (_i != null && _i != this)
            Destroy(gameObject);
        _i = this;
    }
}
