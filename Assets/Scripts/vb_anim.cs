using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using Models;

public class vb_anim : MonoBehaviour, IVirtualButtonEventHandler
{
    public GameObject vbBtnObj;
    public TextMesh label_result;

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        if (ScoreClass.question.Choices[0].IsRightChoice)
        {
            label_result.text = "C'est correct! \n Indice:" + ScoreClass.question.IndiceNext ;
        } else
        {
            label_result.text = "C'est FAUX!";
        }
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        vbBtnObj = GameObject.Find("Answer1Btn");
        vbBtnObj.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
