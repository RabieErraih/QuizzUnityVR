using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class vb_anim : MonoBehaviour, IVirtualButtonEventHandler
{
    public GameObject vbBtnObj;
    public TextMesh label_result;

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        Debug.Log("BTN PRESSED");
        label_result.text = "C'est correct! \n Indice:";
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        Debug.Log("BTN RELEASED");
    }

    // Start is called before the first frame update
    void Start()
    {
        vbBtnObj = GameObject.Find("Answer1Btn");
        vbBtnObj.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
