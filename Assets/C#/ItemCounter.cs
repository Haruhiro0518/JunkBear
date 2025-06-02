using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCounter : MonoBehaviour
{
    [SerializeField, Header("総数")]
    public int sum;

    [SerializeField, Header("取得数")]
    public int score;

    [SerializeField, Header("テキスト01")]
    public GameObject result01;

    [SerializeField, Header("テキスト02")]
    public GameObject result02;

    void Start()
    {
        score = 0;
    }

    void Update()
    {
        Text text01 = result01.GetComponent<Text>();
        text01.text = "... " + score + "/" + sum;
        Text text02 = result02.GetComponent<Text>();
        text02.text = "... " + score + "/" + sum;
    }
}
