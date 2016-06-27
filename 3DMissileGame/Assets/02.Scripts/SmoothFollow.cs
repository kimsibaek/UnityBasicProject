using UnityEngine;

namespace UnityStandardAssets.Utility
{
	public class SmoothFollow : MonoBehaviour
	{

		// The target we are following
		[SerializeField]
		private Transform target;
		// The distance in the x-z plane to the target
		[SerializeField]
		private float distance = 10.0f;
		// the height we want the camera to be above the target
		[SerializeField]
		private float height = 5.0f;

		[SerializeField]
		private float rotationDamping;
		[SerializeField]
		private float heightDamping;
		bool check = false;
		// Use this for initialization
		void Start() { }

		// Update is called once per frame
		void LateUpdate()
		{
			// Early out if we don't have a target
			if (!target)
				return;

			// Calculate the current rotation angles
			var wantedRotationAngleX = target.eulerAngles.x;
			var wantedRotationAngleY = target.eulerAngles.y;

			var wantedHeightX = target.position.x;
			var wantedHeightY = target.position.y + height;

			var currentRotationAngleX = transform.eulerAngles.x;
			var currentRotationAngleY = transform.eulerAngles.y;

			var currentHeightX = transform.position.x;
			var currentHeightY = transform.position.y;

			// Damp the rotation around the y-axis
			currentRotationAngleX = Mathf.LerpAngle(currentRotationAngleX, wantedRotationAngleX, rotationDamping * Time.deltaTime);
			currentRotationAngleY = Mathf.LerpAngle(currentRotationAngleY, wantedRotationAngleY, rotationDamping * Time.deltaTime);
			//Debug.Log ("currentRotationAngleX : " + currentRotationAngleX);
			//Debug.Log ("currentRotationAngleY : " + currentRotationAngleY);
			// Damp the height
			currentHeightX = Mathf.Lerp(currentHeightX, wantedHeightX, heightDamping * Time.deltaTime);
			currentHeightY = Mathf.Lerp(currentHeightY, wantedHeightY, heightDamping * Time.deltaTime);

			// Convert the angle into a rotation
			var currentRotationX = Quaternion.Euler(currentRotationAngleX, 0, 0);
			var currentRotationY = Quaternion.Euler(0, currentRotationAngleY, 0);
			Debug.Log ("currentRotationX : " + currentRotationX);
			//Debug.Log ("currentRotationY : " + currentRotationY);
			// Set the position of the camera on the x-z plane to:
			// distance meters behind the target
			transform.localPosition = target.localPosition;
			transform.rotation = target.rotation;

			Debug.Log ("Input.mousePosition.y : " + Input.mousePosition);
		
			transform.localPosition += currentRotationX * Vector3.down * distance;
			//transform.localPosition -= currentRotationY * Vector3.forward * distance;

			Debug.Log ("transform.localPosition : " + transform.localPosition);

			// Set the height of the camera
			//transform.localPosition = new Vector3(currentHeightX, transform.position.y, -10);

			// Always look at the target
			//transform.LookAt(target);
		}
	}
}