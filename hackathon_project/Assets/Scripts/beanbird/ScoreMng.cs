using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreMng : MonoBehaviour
{
    public GameObject score_object = null;
    public int score = 0;

    void Start()
    {
        
    }

    void Update()
    {
        Text score_text = score_object.GetComponent<Text> ();
        score_text.text = "Score："+ score;
    }

    public void GetScore(){
        score += 50;
    }
}


//　高さからスコアを判定