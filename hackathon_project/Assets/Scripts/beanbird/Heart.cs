using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        // ハートがブロックに当たると消滅
        if(collision.tag == "block"){
            Destroy(gameObject);
        }
    }
}
