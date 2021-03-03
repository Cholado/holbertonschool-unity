using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
    public Text timerText;
    public GameObject player;

    void OnTriggerEnter(Collider other)
    {
        player.GetComponent<Timer>().enabled = false;
        //timerText.text = string.Format("{0:0}:{1:00}.{2:00}", timer / 60, timer % 60, timer * 100 % 100);
        timerText.fontSize = 36;
        timerText.color = Color.green;
    }
}