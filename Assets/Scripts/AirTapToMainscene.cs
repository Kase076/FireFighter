using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using UnityEngine.SceneManagement;

public class AirTapToMainscene : MonoBehaviour, IInputClickHandler {


    public void OnInputClicked(InputClickedEventData eventData)
    {
        //DontDestroyOnLoad();
        
        //Application.LoadLevelAdditive("Main");        旧型式？
        SceneManager.LoadScene("Main", LoadSceneMode.Additive);
        Destroy(gameObject);
    }

    // Use this for initialization
    void Start () {
        InputManager.Instance.PushFallbackInputHandler(gameObject);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

}
