using UnityEngine;
using System.Collections;
using UnityEngine.UI; 
using UnityEngine.EventSystems;

public class csMousePoint : MonoBehaviour {
	public static GameObject blankTile;

	public static GameObject Tile;


	public static bool TileSelect;

	public LayerMask currentMask;

	public Material Mat;
	public Material Mat2;

	public GameObject BtnState;
	public GameObject BtnMoveState;
	public GameObject BtnStayState;
	public GameObject BtnMenuState;

	public static bool touchTile;

	private GameObject TileState;

	public Material MatUp;
	public Material MatDown;
	public Material MatLeft;
	public Material MatRight;

	public Material MatOneS;
	public Material MatTwoS;
	public Material MatThreeS;


	private int OrderNum;

	GameObject obj1;
	private Text txtStatus1;


	// Use this for initialization
	void Start () {
		blankTile = transform.gameObject;
		Tile = blankTile;

		touchTile = true;

		OrderNum = 0;
		//BtnState = GetComponent<Image> ();

		obj1 = GameObject.Find ("OrderNumber");
		txtStatus1 = obj1.GetComponent<Text> ();
	}
		
	// Update is called once per frame
	void Update () {
		//UI클릭시 뒤에있는 오브젝트 클릭 막아줌
			
		if (EventSystem.current.IsPointerOverGameObject(0)) {
			//Debug.Log ("UI click");
			return;
		}
		if (EventSystem.current.IsPointerOverGameObject(-1)) {
			//Debug.Log ("UI click");
			return;
		}


		if (Input.touchCount == 1) {
			
			Touch touch = Input.GetTouch (0);
			if (touch.phase == TouchPhase.Ended && csCameraMove.bMouseDown && touchTile) {
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit;
				Debug.Log ("touchTile");
				if (Physics.Raycast (ray, out hit, Mathf.Infinity, currentMask)) {
					//Debug.Log (hit.collider.gameObject.name);


					if (hit.transform.CompareTag("Tile")) {
						TileState = hit.transform.gameObject;
						if (TileState.GetComponent<csTileState> ().state) {
							TileSelect = true;
							Tile = hit.transform.gameObject;
							Tile.GetComponent<Renderer> ().sharedMaterial = Mat;
							//csTileState TileST = Tile.GetComponent<csTileState> ();
							//Debug.Log (TileST.stateNum);

							BtnState.SetActive (true);
							BtnMenuState.SetActive (false);
							touchTile = false;
							cameraPosition ();
						}
					}
				} else {
					
					TileSelect = false;
					touchTile = true;
					BtnState.SetActive(false);
					BtnMoveState.SetActive(false);
					BtnMenuState.SetActive (false);
					if (Tile == blankTile) {
						return;
					}
					Tile.GetComponent<Renderer> ().sharedMaterial = Mat2;
					Tile = blankTile;

				}


			} else {
				touchTile = true;
			}
		}
	}

	void cameraPosition(){
		if (TileSelect) {
			//Vector3 moveposition = Tile.transform.position - transform.position;
			//transform.Translate (moveposition * Time.deltaTime);
			transform.position = Tile.transform.position;
			transform.position -= Vector3.down * 6.0f;
			transform.position += Vector3.forward * 2.0f;
		} 
	}

	public void OnMoveImg(){
		//Debug.Log("OnMoveImg");
		BtnMoveState.SetActive(true);

		BtnStayState.SetActive(false);

	}

	public void OnStayImg(){
		//Debug.Log("OnMoveImg");
		BtnStayState.SetActive(true);
	
		BtnMoveState.SetActive(false);

	}

	//
	//GameObject obj2 = GameObject.Find ("txtStatus2");
	//txtStatus1 = obj1.GetComponent<Text> ();
	//txtStatus2 = obj2.GetComponent<Text> ();
	//txtStatus1.text = "화면의 오른쪽 터치...";
	//txtStatus2.text = "Touch Count : " + fingerCount;

	public void OnMoveImgUp(){
		
		Tile.GetComponent<Renderer> ().sharedMaterial = MatUp;
		csTileState TileST = Tile.GetComponent<csTileState> ();
		TileST.stateNum = 1;
		BtnState.SetActive(false);
		BtnMoveState.SetActive(false);
		BtnMenuState.SetActive (false);
		touchTile = true;
		TileSelect = false;

		OrderNumPlus ();
	}
	public void OnMoveImgDown(){
		Tile.GetComponent<Renderer> ().sharedMaterial = MatDown;
		csTileState TileST = Tile.GetComponent<csTileState> ();
		TileST.stateNum = 2;
		BtnState.SetActive(false);
		BtnMoveState.SetActive(false);
		BtnMenuState.SetActive (false);
		touchTile = true;
		TileSelect = false;

		OrderNumPlus ();
	}
	public void OnMoveImgLeft(){
		Tile.GetComponent<Renderer> ().sharedMaterial = MatLeft;
		csTileState TileST = Tile.GetComponent<csTileState> ();
		TileST.stateNum = 3;
		BtnState.SetActive(false);
		BtnMoveState.SetActive(false);
		BtnMenuState.SetActive (false);
		touchTile = true;
		TileSelect = false;

		OrderNumPlus ();
	}
	public void OnMoveImgRight(){
		Tile.GetComponent<Renderer> ().sharedMaterial = MatRight;
		csTileState TileST = Tile.GetComponent<csTileState> ();
		TileST.stateNum = 4;
		BtnState.SetActive(false);
		BtnMoveState.SetActive(false);
		BtnMenuState.SetActive (false);
		touchTile = true;
		TileSelect = false;

		OrderNumPlus ();
	}

	public void OnMoveImgOneS(){
		Tile.GetComponent<Renderer> ().sharedMaterial = MatOneS;
		csTileState TileST = Tile.GetComponent<csTileState> ();
		TileST.stateNum = 5;
		BtnState.SetActive(false);
		BtnStayState.SetActive(false);
		BtnMenuState.SetActive (false);
		touchTile = true;
		TileSelect = false;

		OrderNumPlus ();
	}

	public void OnMoveImgTwoS(){
		Tile.GetComponent<Renderer> ().sharedMaterial = MatTwoS;
		csTileState TileST = Tile.GetComponent<csTileState> ();
		TileST.stateNum = 6;
		BtnState.SetActive(false);
		BtnStayState.SetActive(false);
		BtnMenuState.SetActive (false);
		touchTile = true;
		TileSelect = false;

		OrderNumPlus ();
	}

	public void OnMoveImgThreeS(){
		Tile.GetComponent<Renderer> ().sharedMaterial = MatThreeS;
		csTileState TileST = Tile.GetComponent<csTileState> ();
		TileST.stateNum = 7;
		BtnState.SetActive(false);
		BtnStayState.SetActive(false);
		BtnMenuState.SetActive (false);
		touchTile = true;
		TileSelect = false;

		OrderNumPlus ();
	}

	public void OnMoveImgCancel(){
		csTileState TileST = Tile.GetComponent<csTileState> ();

		if(TileST.stateNum != 0){
			OrderNumMinus ();
		}
		TileST.stateNum = 0;
		Tile.GetComponent<Renderer> ().sharedMaterial = Mat2;
		BtnState.SetActive(false);
		BtnMoveState.SetActive(false);
		BtnStayState.SetActive(false);
		BtnMenuState.SetActive (false);
		//touchTile = true;
		TileSelect = false;


	}

	void OrderNumPlus(){
		OrderNum++;
		txtStatus1.text = "Order " + OrderNum;
	}

	void OrderNumMinus(){
		OrderNum--;
		txtStatus1.text = "Order " + OrderNum;
	}
}
