using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using System.Collections.Generic;

public class ScoreManager : MonoBehaviour
{
    private IEnumerable<TrackableBehaviour> trackable;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(ScoreClass.PlayerScore);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
