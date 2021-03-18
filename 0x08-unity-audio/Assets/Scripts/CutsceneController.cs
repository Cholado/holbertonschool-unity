using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    // Start is called before the first frame update
    Animator anim;
    public GameObject mainCam;
    public GameObject sCam;
    public GameObject player;
    public GameObject timerCanvas;

    void Awake()
    {
        Debug.Log("awake de cutscenecontroller");
        anim = GetComponent<Animator>();
        
    }

    void Update()
    {

        if (transform.position == new Vector3(0f, 2.5f, -6.25f))
        {
            Debug.Log("finaliza animacion");
            mainCam.SetActive(true);
            sCam.SetActive(false);
            player.SetActive(true);
            timerCanvas.SetActive(true);
            player.gameObject.GetComponent<PlayerController>().enabled = true;
        }
            Debug.Log("update de cutscenecontroller");
    }

   

}
