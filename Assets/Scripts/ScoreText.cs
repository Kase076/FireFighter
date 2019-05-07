using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour {

    public Text text;

	// Use this for initialization
	void Start () {
        text.text = "Your Score : " + ScoreController.Score + " pt\r\nThank You For Playing";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
