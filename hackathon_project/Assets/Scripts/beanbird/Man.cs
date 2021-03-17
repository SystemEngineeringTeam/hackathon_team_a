using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelObjectBase : MonoBehaviour
{
    private Vector3 cashPosition;

    public float speed;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent();
    }

    void FixedUpdate()
    {
        float horizontalKey = Input.GetAxis("Horizontal");
        //右入力で左向きに動く
        if(horizontalKey > 0)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        //左入力で左向きに動く
        else if(horizontalKey < 0)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
        //ボタンを話すと止まる
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    void LateUpdate()
    {
        cashPosition = transform.localPosition;
        transform.localPosition = new Vector3(
                        Mathf.RoundToInt(cashPosition.x),
                        Mathf.RoundToInt(cashPosition.y),
                        Mathf.RoundToInt(cashPosition.z)
                   );
    }

    void OnRenderObject()
    {
        transform.localPosition = cashPosition;
    }
}
