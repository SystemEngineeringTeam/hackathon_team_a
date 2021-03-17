using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{
    GameObject ScoreMng;
    ScoreMng script;
    public float hearttmp;
    void Start()
    {   
        ScoreMng = GameObject.Find("ScoreMng");
        script = ScoreMng.GetComponent<ScoreMng>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        // ハートがブロックに当たると消滅
        if(collision.tag == "block"){
            Destroy(gameObject);
        }else if(collision.tag == "knife"){
            hearttmp = this.transform.position.y;
            script.GetScore(hearttmp);// 得点
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible()// 画面外にいくと消滅
    {
        Destroy(gameObject);    
    }


}