using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity;
using HoloToolkit.Unity.InputModule;

//ステートリスト
public enum StateList
{
    Easy,
    Normal,
    Hard
}

public class FireGeneAI : MonoBehaviour
{
    private float time = 0;     //時間のカウント用

    [SerializeField] private GameObject fireball;
    [SerializeField] private float frontdistance;  //炎の生成範囲（前）
    [SerializeField] private float sidedistance;   //炎の生成範囲（横）

    private float count = 1.0f;  //何秒ごとに炎を出すか
    private float FireNumberLimit;  //炎の生成上限
    public static int FireNumber = 0;        //炎の生成数カウント用

    //StateMachine用
    private StateList CurrentState;
    Dictionary<StateList, float[]> State = new Dictionary<StateList, float[]>();

    // Stateごとのパラメータ //
    private float[] easy    = { 2.5f, 4.0f };
    private float[] normal  = { 1.5f, 8.0f };
    private float[] hard    = { 0.5f, 10.0f };

    private float[] param;

    // Use this for initialization
    void Start()
    {
        State.Add(StateList.Easy, easy);
        State.Add(StateList.Normal, normal);
        State.Add(StateList.Hard, hard);
        CurrentState = StateList.Easy;
    }

    // Update is called once per frame
    void Update()
    {
        time += 1 * Time.deltaTime;     //時間の計測

        ReadCurrentState(CurrentState);

        if (time >= count && FireNumber < FireNumberLimit)
        {
            FireInstantiate();
            time = 0;
        }

        ChangeState(CurrentState);

        //Debug.Log(CurrentState);
        //Debug.Log(param[0] + " " + param[1]);
        //Debug.Log(FireNumber);
    }

    private void FireInstantiate()
    {
        float x = Random.Range(-(sidedistance), sidedistance);
        float y = Random.Range(-1.2f, -0.5f);
        float z = Random.Range(2.2f, frontdistance);
        Instantiate(fireball, new Vector3(x, y, z), Quaternion.identity);
        FireNumber++;
    }

    private void ReadCurrentState(StateList current_state)
    {
        param = State[current_state];
        count = param[0];
        FireNumberLimit = param[1];
    }

    private void ChangeState(StateList current_state)
    {
        if (current_state == StateList.Easy) {
            if (ScoreController.Score >= 3)
            {
                this.CurrentState = StateList.Normal;
            }
            else if (time >= 15)
            {
                this.CurrentState = StateList.Hard;
            }
            else
            {
                return;
            }
        }

        if (current_state == StateList.Normal)
        {
            if (ScoreController.Score >= 10 && ScoreController.Score <= 18)
            {
                this.CurrentState = StateList.Hard;
            }
            else
            {
                return;
            }
        }

        if (current_state == StateList.Hard)
        {
            if (ScoreController.Score > 18)
            {

                this.CurrentState = StateList.Normal;
            }
            else
            {
                return;
            }
        }
    }

    public static void FireNumberdecrement()
    {
        FireNumber--;
    }
}
