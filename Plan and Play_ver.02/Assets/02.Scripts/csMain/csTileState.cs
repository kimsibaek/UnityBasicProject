using UnityEngine;
using System.Collections;

public class csTileState : MonoBehaviour {
	public Material Mat;
	public Material Mat2;
	/// <summary>
	/// /////////////
	public Material ChangeMat1;
	public Material ChangeMat2;
	public Material ChangeMat3;
	public Material ChangeMat4;
	public Material ChangeMat5;
	public Material ChangeMat6;
	public Material ChangeMat7;
	public Material ChangeMat8;
	/// </summary>


	public bool state;

	public int stateNum;

	public GameObject ActionObj;
	public GameObject ActionObjPosition;

	// Use this for initialization
	void Start () {
		stateNum = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision collision){
		//Debug.Log (stateNum);
		//오브젝트 이동
		if(stateNum == 8){
			//Debug.Log ("OnCollisionEnter");
			Material[] matChange = new Material[2];
			Debug.Log (ActionObj);
			Debug.Log (ActionObjPosition);
			if (ActionObj.CompareTag ("Object1")) {
				matChange [0] = ChangeMat2;
				matChange [1] = ChangeMat4;
				ActionObj.GetComponent<Renderer> ().sharedMaterials = matChange;
			} else if (ActionObj.CompareTag ("Object2")) {
				matChange [0] = ChangeMat8;
				ActionObj.GetComponent<Renderer> ().sharedMaterial = matChange[0];
			} else if (ActionObj.CompareTag ("Object3")){
				matChange [0] = ChangeMat6;
				ActionObj.GetComponent<Renderer> ().sharedMaterial = matChange[0];
			}

			StartCoroutine ("ActionFad");


		}
	}

	IEnumerator ActionFad(){
		//Debug.Log ("은신1");
		StartCoroutine ("ActionFadOut");
		yield return new WaitForSeconds (0.5f/csCharacterMove.anim.speed);
		float x = ActionObj.transform.position.x - ActionObjPosition.transform.position.x;
		float z = ActionObj.transform.position.z - ActionObjPosition.transform.position.z;
		Debug.Log (x + " " + z);
		Debug.Log (ActionObj.transform.position);
		Vector3 vec;
		vec = ActionObj.transform.position;
		vec.x -= x;
		vec.z -= z;
		ActionObj.transform.localPosition = vec;
		Debug.Log (ActionObj.transform.localPosition);
		StartCoroutine ("ActionFadIn");
	}

	IEnumerator ActionFadOut(){
		//Debug.Log ("은신2");
		for(float i = 1f; i >= 0.0f; i -= 0.05f)
		{
			Color color = new Vector4(1,1,1, i);
			ActionObj.transform.GetComponent<Renderer> ().sharedMaterial.color = color;
			yield return 0;
		}
	}

	IEnumerator ActionFadIn(){
		//Debug.Log ("은신3");
		for(float i = 0.0f; i <= 1; i += 0.05f)
		{
			Color color = new Vector4(1,1,1, i);
			ActionObj.transform.GetComponent<Renderer> ().sharedMaterial.color = color;
			yield return 0;
		}

		Material[] matChange = new Material[2];
		if (ActionObj.CompareTag ("Object1")) {
			matChange [0] = ChangeMat1;
			matChange [1] = ChangeMat3;
			ActionObj.GetComponent<Renderer> ().sharedMaterials = matChange;
		} else if (ActionObj.CompareTag ("Object2")) {
			matChange [0] = ChangeMat7;
			ActionObj.GetComponent<Renderer> ().sharedMaterial = matChange[0];
		} else if (ActionObj.CompareTag ("Object3")){
			matChange [0] = ChangeMat5;
			ActionObj.GetComponent<Renderer> ().sharedMaterial = matChange[0];
		}
	}

}
