using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    Vector2 drugVec;
    [SerializeField]
    GameObject root, arrow, unmask, triangle, circle;
    [SerializeField]
    float stretchSpeed, baseSize, maxSize, minSize;

    [SerializeField]
    float timeOut;
    float timeElapsed;

    // Start is called before the first frame update
    void Start()
    {
        CheckScreen();
        VisualOff();
    }

    // Update is called once per frame
    void Update()
    {
        CheckScreen();
        drugVec = Vector2.zero;


        //押された瞬間の挙動
        if (Input.GetMouseButtonDown(0))
        {
            tapPos = Input.mousePosition;
            root.GetComponent<RectTransform>().position = tapPos;
            timeElapsed = 0;
            VisualOn();
        }
        //押されてる間の矢印の動き
        if (Input.GetMouseButton(0))
        {
            drugPos = Input.mousePosition;
            drugVec = drugPos - tapPos;
            float dis;

            //矢印の大きさ
            if (curScreenInc == ScreenInclination.vertical) 
            { 
                dis = drugVec.magnitude * BASE_SHOTTER / Screen.width;
            }
            else
            {
                dis = drugVec.magnitude * BASE_LONGER / Screen.width;
            }
           
            float sizeRate = dis / stretchSpeed;
            Vector3 temp = arrow.GetComponent<RectTransform>().localScale;
            if (sizeRate >= minSize && sizeRate <= maxSize)
            {
                arrow.GetComponent<RectTransform>().localScale = new Vector3(temp.x, baseSize * sizeRate, temp.z);
                unmask.GetComponent<RectTransform>().localScale = new Vector3(unmask.GetComponent<RectTransform>().localScale.x, stretchSpeed / (baseSize * dis), unmask.GetComponent<RectTransform>().localScale.z);
            }
            else if(sizeRate < minSize)
            {
                arrow.GetComponent<RectTransform>().localScale = new Vector3(temp.x, 0, temp.z);
            }
            else if (sizeRate > maxSize)
            {
                arrow.GetComponent<RectTransform>().localScale = new Vector3(temp.x, baseSize * maxSize, temp.z);
                unmask.GetComponent<RectTransform>().localScale = new Vector3(unmask.GetComponent<RectTransform>().localScale.x, baseSize / maxSize, unmask.GetComponent<RectTransform>().localScale.z);
            }

            //矢印の向き
            float rad = Mathf.Atan2(drugVec.y, drugVec.x);
            float degree = rad * Mathf.Rad2Deg;
            arrow.GetComponent<RectTransform>().rotation = new Quaternion(0,0,0,0);
            arrow.GetComponent<RectTransform>().RotateAround(root.GetComponent<RectTransform>().position, arrow.GetComponent<RectTransform>().forward, degree - 90);

            preScreenInc = curScreenInc;
        }
        else
        {
            timeElapsed += Time.deltaTime;
        }

        //一定時間で消す
        if (timeElapsed >= timeOut)
        {
            VisualOff();
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

    void VisualOn()
    {
        circle.GetComponent<Image>().enabled = true;
        triangle.GetComponent<Image>().enabled = true;
    }

    void VisualOff()
    {
        circle.GetComponent<Image>().enabled = false;
        triangle.GetComponent<Image>().enabled = false;
    }

    public Vector2 GetMoveVector()
    {
        return this.drugVec;
    }
}
