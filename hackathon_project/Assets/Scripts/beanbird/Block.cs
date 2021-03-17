using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    RegeneMng rgnscript;

    void Start()
    {
        rgnscript = GameObject.Find("RegenerateMng").GetComponent<RegeneMng>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        // ハートがブロックに当たると消滅
        if(collision.tag == "heart"){
            Vector3 blocktmp = this.transform.position;
            rgnscript.Keeptmp(blocktmp);
            Destroy(gameObject);
        }
    }
}