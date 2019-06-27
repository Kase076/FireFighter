using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using UnityEngine.SceneManagement;

public class ReturnToTitle : MonoBehaviour, IInputClickHandler { 

	// Use this for initialization
	void Start () {
        //InputManager.Instance.PushFallbackInputHandler(gameObject);
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        SceneManager.LoadScene("Title");
        ScoreController.InitScore();
    }
}