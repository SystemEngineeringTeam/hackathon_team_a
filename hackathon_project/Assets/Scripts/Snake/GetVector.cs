using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetVector : MonoBehaviour
{
    [SerializeField]
	GameObject _start;

	[SerializeField]
	GameObject _target;
    static float angle;

	void Update () {
		angle = GetAngle (_start.transform.position, _target.transform.position);
		// Debug.Log (angle);
	}
    public static float GetAng(){
        return angle;
    }

	float GetAngle(Vector2 start,Vector2 target)
	{
		Vector2 dt = target - start;
		float rad = Mathf.Atan2 (dt.y, dt.x);
		float degree = rad * Mathf.Rad2Deg;
		
		return degree;
	}
}
