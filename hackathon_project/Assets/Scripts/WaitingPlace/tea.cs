using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tea : MonoBehaviour
{

    void Start()
    {
        
    }
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        Destroy(gameObject);    
    }
}
