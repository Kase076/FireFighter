using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeLimitController : MonoBehaviour {

    private static float _time = 0;
    public static float TimeLimit { get { return _time; } }

    [SerializeField]
    private float limit_time;

    void Start()
    {
        _time = limit_time;
    }

    void Update()
    {
        // 毎フレーム毎に残り時間を減らしていく
        _time -= Time.deltaTime;
        if (_time < 0)
        {
            SceneManager.LoadScene("End", LoadSceneMode.Additive);
            Destroy(gameObject);
        }
        
    }
}
