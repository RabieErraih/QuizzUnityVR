using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using System.Net.Http;
using Models;
using UnityEngine.UI;
using System;

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
            string doorCode = mTrackableBehaviour.TrackableName.Split(new string[] { "Salle" }, StringSplitOptions.None)[1];
            var responseString = client.GetStringAsync("http://quizz-vr.api.rabieouledabdallah.fr/api/questions/door/" + doorCode).Result;
            ScoreClass.question = Question.FromJson(responseString);
            for (int i = 0; i<=2; i++)
            {
                GameObject.Find("AnswerBtn"+(i+1)).GetComponentInChildren<TextMesh>().text = ScoreClass.question.Choices[i].Content;
            }
            GameObject.Find("Question Label").GetComponent<TextMesh>().text = ScoreClass.question.Content;
        }
        else
        {
            //Debug.Log("wutFace");
        }
    }
}
