using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CountController : MonoBehaviour {

    [SerializeField] private TextMesh m_CounterText;

	// Use this for initialization
	void Start () {
        ScoreController.InitScore();
    }
	
	// Update is called once per frame
	void Update () {

        m_CounterText.text = "Score : " + ScoreController.Score.ToString() + " pt";

	}
}
