using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreController {

    private static float _score = 0;
    public static float Score { get{ return _score; } }

	public  static void  AddScore () {
        _score++;
	}

    public static void InitScore()
    {
        _score = 0;
    }

}
