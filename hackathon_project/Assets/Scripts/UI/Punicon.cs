using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punicon : MonoBehaviour
{
    Vector3 tapPos, drugPos;
    [SerializeField]
    GameObject root,arrow;
    [SerializeField]
    float maxDis,baseSize;
    // Start is called before the first frame update
    void Start()
    {
        root.GetComponent<RectTransform>().localScale = new Vector3(1980 / Screen.width, 1980 / Screen.width, 1);
    }

    // Update is called once per frame
    void Update()
    {
        root.GetComponent<RectTransform>().localScale = new Vector3(Screen.width / 1080f, Screen.width / 1080f, 1);
        if (Input.GetMouseButtonDown(0))
        {
            tapPos = Input.mousePosition;
            root.GetComponent<RectTransform>().position = tapPos;
        }
        if (Input.GetMouseButton(0))
        {
            drugPos = Input.mousePosition;
            Vector2 drugVec = drugPos - tapPos;

            float dis = drugVec.magnitude;
            float sizeRate = dis / maxDis;
            Vector3 temp = arrow.GetComponent<RectTransform>().localScale;
            if (sizeRate >= 0.8f && sizeRate < 2f)
            {
                arrow.GetComponent<RectTransform>().localScale = new Vector3(temp.x, baseSize * dis / maxDis, temp.z);
            }
            else if(sizeRate < 1)
            {
                arrow.GetComponent<RectTransform>().localScale = new Vector3(temp.x, 0, temp.z);
            }

            float rad = Mathf.Atan2(drugVec.y, drugVec.x);
            float degree = rad * Mathf.Rad2Deg;
            arrow.GetComponent<RectTransform>().rotation = new Quaternion(0,0,0,0);
            arrow.GetComponent<RectTransform>().RotateAround(root.GetComponent<RectTransform>().position, arrow.GetComponent<RectTransform>().forward, degree - 90);
        }
    }
}
