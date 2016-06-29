using UnityEngine;
using System.Collections;

public class csCameraMove : MonoBehaviour {
	public float Speed;
	public Vector2 nowPos, prePos;
	public Vector3 movePos;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.touchCount == 1)
		{
			Touch touch = Input.GetTouch (0);
			if(touch.phase == TouchPhase.Began)
			{
				prePos = touch.position - touch.deltaPosition;
			}
			else if(touch.phase == TouchPhase.Moved)
			{
				nowPos = touch.position - touch.deltaPosition;
				movePos = (Vector3)(prePos - nowPos) * Speed;
				transform.Translate(movePos);
				prePos = touch.position - touch.deltaPosition;
			}
			else if(touch.phase == TouchPhase.Ended)
			{
			}
		}
	}
}
