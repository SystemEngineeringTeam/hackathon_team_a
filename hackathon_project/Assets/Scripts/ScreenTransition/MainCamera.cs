using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    int flag = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(flag == 0){
            transform.position += new Vector3(0.03f,0,0);
            if(transform.position.x > 8){
                flag = 1;
            }
        }
        if(flag == 1){
            transform.position -= new Vector3(0,0.03f,0);
            if(transform.position.y < -2.5){
                flag = 2;
            }
        }
        if(flag == 2){
            transform.position -= new Vector3(0.03f,0,0);
            if(transform.position.x < -10){
                flag = 3;
            }
        }
        if(flag == 3){
            transform.position += new Vector3(0,0.03f,0);
            if(transform.position.y > 0){
                flag = 0;
            }
        }
    }
}
