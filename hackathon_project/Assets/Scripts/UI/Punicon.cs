using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punicon : MonoBehaviour
{
    const float BASE_SHOTTER = 1080;
    const float BASE_LONGER = 1920;

    enum ScreenInclination {
        holizontal,
        vertical
    }

    ScreenInclination curScreenInc, preScreenInc;
    Vector3 tapPos, drugPos;
    [SerializeField]
    GameObject root, arrow, unmask;
    [SerializeField]
    float stretchSpeed, baseSize;
    // Start is called before the first frame update
    void Start()
    {
        CheckScreen();
    }

    // Update is called once per frame
    void Update()
    {
        CheckScreen();

        //押された瞬間の挙動
        if (Input.GetMouseButtonDown(0))
        {
            tapPos = Input.mousePosition;
            root.GetComponent<RectTransform>().position = tapPos;
        }
        //押されてる間の矢印の動き
        if (Input.GetMouseButton(0))
        {
            drugPos = Input.mousePosition;
            Vector2 drugVec = drugPos - tapPos;
            float dis;
            //矢印の大きさ
            if (curScreenInc == ScreenInclination.holizontal) 
            { 
                dis = drugVec.magnitude * BASE_SHOTTER / Screen.width;
            }
            else
            {
                dis = drugVec.magnitude * BASE_LONGER / Screen.width;
            }
           
            float sizeRate = dis / stretchSpeed;
            Vector3 temp = arrow.GetComponent<RectTransform>().localScale;
            if (sizeRate >= 0.8f && sizeRate < 2f)
            {
                arrow.GetComponent<RectTransform>().localScale = new Vector3(temp.x, baseSize * dis / stretchSpeed, temp.z);
                unmask.GetComponent<RectTransform>().localScale = new Vector3(unmask.GetComponent<RectTransform>().localScale.x, stretchSpeed / (baseSize * dis), unmask.GetComponent<RectTransform>().localScale.z);
            }
            else if(sizeRate < 1)
            {
                arrow.GetComponent<RectTransform>().localScale = new Vector3(temp.x, 0, temp.z);
            }

            //矢印の向き
            float rad = Mathf.Atan2(drugVec.y, drugVec.x);
            float degree = rad * Mathf.Rad2Deg;
            arrow.GetComponent<RectTransform>().rotation = new Quaternion(0,0,0,0);
            arrow.GetComponent<RectTransform>().RotateAround(root.GetComponent<RectTransform>().position, arrow.GetComponent<RectTransform>().forward, degree - 90);

            preScreenInc = curScreenInc;
        }
    }

    void CheckScreen()
    {
        //縦横
        if (Screen.width < Screen.height)
        {
            curScreenInc = ScreenInclination.vertical;
        }
        else
        {
            curScreenInc = ScreenInclination.holizontal;
        }
        //縦横に合わせて大きさ変更
        if (curScreenInc == ScreenInclination.vertical)
        {
            root.GetComponent<RectTransform>().localScale = new Vector3(Screen.width / BASE_SHOTTER, Screen.width / BASE_SHOTTER, 1);
        }
        else
        {
            root.GetComponent<RectTransform>().localScale = new Vector3(Screen.width / BASE_LONGER, Screen.width / BASE_LONGER, 1);
        }
    }
}
