using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using System.Net.Http;
using Models;
using UnityEngine.UI;

public class MyImageTargetTrackedEventHandler : MonoBehaviour,
                                            ITrackableEventHandler
{

    private TrackableBehaviour mTrackableBehaviour;
    private static readonly HttpClient client = new HttpClient();

    void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }

    public void OnTrackableStateChanged(
                                    TrackableBehaviour.Status previousStatus,
                                    TrackableBehaviour.Status newStatus)

    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            // GET QUESTION
            var responseString = client.GetStringAsync("http://a5e4dee1.eu.ngrok.io/api/questions/door/"+ mTrackableBehaviour.TrackableName).Result;
            ScoreClass.question = Question.FromJson(responseString);
            GameObject.Find("Answer1Btn").GetComponentInChildren<TextMesh>().text = ScoreClass.question.Choices[0].Content;
            GameObject.Find("Answer2Btn").GetComponentInChildren<TextMesh>().text = ScoreClass.question.Choices[1].Content;
            GameObject.Find("Answer3Btn").GetComponentInChildren<TextMesh>().text = ScoreClass.question.Choices[2].Content;
        }
        else
        {
            //Debug.Log("wutFace");
        }
    }
}
