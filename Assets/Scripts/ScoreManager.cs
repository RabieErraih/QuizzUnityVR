using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class ScoreManager : MonoBehaviour
{
    private IEnumerable<TrackableBehaviour> trackable;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GameObject.Find("Score Label").GetComponent<Text>();
        scoreText.text = "Score : " + ScoreClass.PlayerScore;
        if (ScoreClass.playerAnswered == true)
        {
            GameObject.Find("Indice Label").GetComponent<Text>().text = ScoreClass.question.IndiceNext;
        }
        ScoreClass.playerAnswered = false;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score : " + ScoreClass.PlayerScore;
    }
}
