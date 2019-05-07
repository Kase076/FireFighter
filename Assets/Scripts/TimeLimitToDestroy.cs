using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLimitToDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (TimeLimitController.TimeLimit < 0) {
            Destroy(gameObject);
        }
	}
}
