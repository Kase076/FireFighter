﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.SpatialMapping;
using HoloToolkit.Unity;

public class RandomIns : MonoBehaviour
{
    int count = 0;
    int max = 3;                //初期炎の個数炎

    private float time = 0;     //時間のカウント用

    [SerializeField] GameObject prefab;
    [SerializeField] private float limit = 1.0f;  //何秒ごとに炎を出すか
    [SerializeField] private float frontdistance;  //炎の生成範囲（前）
    [SerializeField] private float sidedistance;   //炎の生成範囲（横）
    [SerializeField] private int FireNumberLimit;  //炎の生成上限

    public static int   FireNumber = 0;        //炎の生成数カウント用

    void Start()
    {
        
        InvokeRepeating("Generate", 3, 1);
     
    }

    void Generate()
    {
        if (count == max) return;
        //float x = Random.Range(-3f, 3f);
        //float y = Random.Range(-1.2f,0f);
        //float z = Random.Range(1f, 4f);
        //Vector3 position = new Vector3(x, y, z);                          //使えない
        //Instantiate(prefab, new Vector3(x, y, z), Quaternion.identity);
        FireInstantiate();
        count++;
    }

    private void Update()
    {
        time += 1 * Time.deltaTime;     //時間の計測
        if (time >= limit && FireNumber < FireNumberLimit)          
        {
            //float x = Random.Range(0.5f, 3f);
            //float y = Random.Range(0f, 0.2f);
            //float z = Random.Range(0.5f, 3f);
            //Vector3 position = new Vector3(x, y, z);                          //使えない
            //Instantiate(prefab, new Vector3(x, y, z), Quaternion.identity);
            FireInstantiate();
            FireNumber++;
            time = 0;
        }
    }

    private void FireInstantiate() {
        float x = Random.Range(-(sidedistance), sidedistance);
        float y = Random.Range(-1.2f,-0.5f);
        float z = Random.Range(2.2f, frontdistance);
        //Vector3 position = new Vector3(x, y, z);
        Instantiate(prefab, new Vector3(x, y, z), Quaternion.identity);
    }

    public static void FireNumberdecrement() {
        FireNumber--;
    }


}