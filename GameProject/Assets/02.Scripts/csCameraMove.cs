using UnityEngine;
using System.Collections;

public class csCameraMove : MonoBehaviour {
	public float Speed;
	public Vector2 nowPos, prePos;
	public Vector3 movePos;

	public static bool bMouseDown;


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

				bMouseDown = true;
			}
			else if(touch.phase == TouchPhase.Moved)
			{
				bMouseDown = false;

				nowPos = touch.position - touch.deltaPosition;
				movePos = (Vector3)(prePos - nowPos) * Speed;
				transform.Translate(new Vector3(movePos.x, transform.position.y, movePos.y)); 
				prePos = touch.position - touch.deltaPosition;
			}
			else if(touch.phase == TouchPhase.Ended)
			{
			}
		}
		/*
		if( Input.GetMouseButtonDown(0) )
		{			
			prePos = new Vector2(0 - frontx, 0 - fronty);
			bMouseDown = true;			

			//Debug.Log ("GetMouseButtonDown");
		}	
		else if(Input.GetMouseButtonUp(0) )
		{		
			bMouseDown = false;
			//Debug.Log ("GetMouseButtonUp");
		}
		else if( bMouseDown )
		{
			tailx = Input.mousePosition.x;
			taily = Input.mousePosition.y;

			nowPos = new Vector2(tailx - frontx, taily - fronty);
			movePos = (Vector3)(prePos - nowPos) * Speed;

			transform.Translate(movePos);

			prePos = new Vector2(tailx - frontx, taily - fronty);

			frontx = Input.mousePosition.x;
			fronty = Input.mousePosition.y;

		}
		*/



	}
}
