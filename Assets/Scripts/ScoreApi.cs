using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ScoreApi 
{
    public int score;
    public string username;

    public override string ToString()
    {
        return UnityEngine.JsonUtility.ToJson(this, true);
    }
}
