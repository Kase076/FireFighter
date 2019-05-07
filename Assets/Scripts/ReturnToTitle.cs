using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using UnityEngine.SceneManagement;

public class ReturnToTitle : MonoBehaviour, IHoldHandler{

    private float time = 0;
    private int hold_flag = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (hold_flag == 1)
        {
            time += Time.deltaTime;
        }
        else {
            time = 0;
        }

        if (time >= 5.0)
        {
            DontDestroyManager.DestroyAll();
            SceneManager.LoadScene("Title");
        }
    }

    public void OnHoldStarted(HoldEventData eventData)
    {
        hold_flag = 1;
    }

    public void OnHoldCompleted(HoldEventData eventData)
    {
        hold_flag = 0;
    }

    public void OnHoldCanceled(HoldEventData eventData)
    {
        hold_flag = 0;
    }
}
