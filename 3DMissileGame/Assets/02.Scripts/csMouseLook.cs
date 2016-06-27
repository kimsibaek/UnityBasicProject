using UnityEngine;
using System.Collections;

public class csMouseLook : MonoBehaviour {
	public float sensitivity = 10.0f;
	public float rotationX;
	public float rotationY;
	public float speed = 200.0f;
	float height = Screen.height;
	float width = Screen.width;

	public static Vector3 movePosition;

	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		movePosition = Input.mousePosition;

		if(movePosition.x < width / 2){
			//왼쪽
			movePosition.x = -(width / 2 - movePosition.x);
		}
		else if(width / 2 < movePosition.x){
			//오른쪽
			movePosition.x = movePosition.x - (width / 2);
		}

		if(movePosition.y < height / 2){
			//아래
			anim.SetInteger ("GearState", -1);
			movePosition.y = -(height / 2 - movePosition.y);
		}
		else if(height / 2 < movePosition.y){
			//위
			anim.SetInteger ("GearState", 1);
			movePosition.y = movePosition.y - (height / 2);
		}

		float h;// = Input.GetAxis ("Mouse X");
		float v;// = Input.GetAxis ("Mouse Y");

		h = movePosition.x/width * speed * Time.deltaTime;
		v = movePosition.y/width * speed * Time.deltaTime;

		//float temp = movePosition.z;
		//movePosition.z = movePosition.y;
		//movePosition.y = temp;

		transform.rotation *= Quaternion.AngleAxis(h, Vector3.up);
		transform.rotation *= Quaternion.AngleAxis(v, Vector3.left);
	}

	void FixedUpdate(){
		
	}
}
