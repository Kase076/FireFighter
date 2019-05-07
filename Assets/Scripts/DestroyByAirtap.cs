using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity;
//using HoloToolkit.Unity.SpatialMapping;
using HoloToolkit.Unity.InputModule;


public class DestroyByAirtap : MonoBehaviour, IInputClickHandler {

    private Rigidbody _rigidbody;

    // Use this for initialization
    void Start () {

        _rigidbody = this.GetComponent<Rigidbody>();

        //InputManager.Instance.PushFallbackInputHandler(gameObject);
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    private void FixedUpdate()
    {
        if(_rigidbody.velocity.magnitude > 10f) {
            Destroy(gameObject);
        }
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        if (TimeLimitController.TimeLimit > 0) {
            //GameObject obj = GazeManager.Instance.HitObject;
            //Destroy(obj);
            ScoreController.AddScore();
            RandomIns.FireNumberdecrement();
            Destroy(gameObject);
        }
    }

}
