using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadingScene : MonoBehaviour
{

    public Transform LoadingBar;

    [SerializeField] private float currentAmount;
    [SerializeField] private float speed;

    // Update is called once per frame
    void Update()
    {
        if (currentAmount < 100)
        {
            currentAmount += speed * Time.deltaTime;
            Debug.Log((int)currentAmount);
        }
        else
        {
            Application.LoadLevel("MenuScene");
        }

        LoadingBar.GetComponent<Image>().fillAmount = currentAmount / 100;
    }
}