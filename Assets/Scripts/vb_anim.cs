using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using Models;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using System;
using System.Net.Http;
using System.Text;

public class vb_anim : MonoBehaviour, IVirtualButtonEventHandler
{
    public GameObject vbBtnObj;
    public TextMesh label_result;
    private int[] BtnsArray;
    private static readonly HttpClient client = new HttpClient();

    private async Task WaitSecondAsync(int seconde)
    {
        await Task.Delay(TimeSpan.FromSeconds(seconde));
        Debug.Log("Finished waiting.");
    }

    public async void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        
        var choiceID = vbBtnObj.name.Substring(vbBtnObj.name.Length - 1);
        var parsed = int.Parse(choiceID)-1;
        if (ScoreClass.question.Choices[parsed].IsRightChoice)
        {
            BtnsArray = new int[3] { 1, 2, 3 };
            foreach (int i in BtnsArray)
            {
                Debug.Log("AnswerBtn" + i);
                vbBtnObj = GameObject.Find("AnswerBtn"+i);
                vbBtnObj.SetActive(false);
            }
            label_result.text = "C'est correct!";
            ScoreClass.PlayerScore += 10;
            if (ScoreClass.question.Position != 3)
            {
                GameObject.Find("Indice Label").GetComponent<Text>().text = ScoreClass.question.IndiceNext;
                ScoreClass.playerAnswered = true;
                await WaitSecondAsync(2);
                SceneManager.LoadScene("GameScene" + ScoreClass.question.Position);
            }
            else
            {
                string myJson = "{'Username': 'myusername','Score':"+ScoreClass.PlayerScore+"}";
                using (var client = new HttpClient())
                {
                    var response = await client.PostAsync(
                        "http://quizz-vr.api.rabieouledabdallah.fr/api/users/score",
                         new StringContent(myJson, Encoding.UTF8, "application/json"));
                    Debug.Log(response);
                }
            }
        }
        else
        {
            BtnsArray = new int[3] { 1, 2, 3 };
            foreach (int i in BtnsArray)
            {
                vbBtnObj = GameObject.Find("AnswerBtn" + i);
                vbBtnObj.SetActive(false);
            }
            label_result.text = "C'est FAUX!";
            ScoreClass.PlayerScore -= 10;
            if (ScoreClass.question.Position != 3)
            {
                GameObject.Find("Indice Label").GetComponent<Text>().text = ScoreClass.question.IndiceNext;
                ScoreClass.playerAnswered = true;
                await WaitSecondAsync(2);
                SceneManager.LoadScene("GameScene" + ScoreClass.question.Position);
            } else
            {
                string myJson = "{'Username': 'myusername','Score':" + ScoreClass.PlayerScore + "}";
                using (var client = new HttpClient())
                {
                    var response = await client.PostAsync(
                        "http://quizz-vr.api.rabieouledabdallah.fr/api/users/score",
                         new StringContent(myJson, Encoding.UTF8, "application/json"));
                    Debug.Log(response);
                }
            }
        }
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        //vbBtnObj = GameObject.Find("Answer1Btn");
        vbBtnObj.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
