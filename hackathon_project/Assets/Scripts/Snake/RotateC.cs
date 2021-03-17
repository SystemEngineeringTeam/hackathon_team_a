using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateC : MonoBehaviour
{
    GameObject _gameObject;
    // Start is called before the first frame update
    void Start()
    {
        _gameObject = GameObject.Find("C");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 diff = (_gameObject.transform.position - this.transform.position);
        this.transform.rotation = Quaternion.FromToRotation (Vector3.up, diff);
    }
}
