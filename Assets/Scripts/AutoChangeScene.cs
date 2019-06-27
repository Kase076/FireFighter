using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoChangeScene : MonoBehaviour {

    [SerializeField]
    private float _preparationTime;

    void Start()
    {

    }

    void Update()
    {
        // 毎フレーム毎に残り時間を減らしていく
        _preparationTime -= Time.deltaTime;
        if (_preparationTime < 0)
        {
            SceneManager.LoadScene("Title");
        }
    }
}
