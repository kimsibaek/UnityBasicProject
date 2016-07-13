using UnityEngine;
using System.Collections;
using UnityEngine.UI; 
using UnityEngine.EventSystems;

public class csMousePoint : MonoBehaviour {
	public static GameObject blankTile;

	public static GameObject Tile;


	public static bool TileSelect;

	public LayerMask currentMask;
	public LayerMask ObjectMask;
	public LayerMask AddLayerMask;

	public Material Mat;
	public Material Mat2;

	public GameObject BtnState;

	public GameObject BtnMoveState;
	public GameObject BtnStayState;
	public GameObject BtnMenuState;

	public GameObject BtnActionState;

	public static bool touchTile;

	private GameObject TileState;

	public Material MatUp;
	public Material MatDown;
	public Material MatLeft;
	public Material MatRight;

	public Material MatOneS;
	public Material MatTwoS;
	public Material MatThreeS;

	public Material MatActionObj;
	public Material MatActionSpeed;
	public Material MatActionFade;
	public Material MatActionScout;
	public Material MatActionSound;
	public Material MatActionDummy;
	public Material MatActionEMP;
	public Material MatActionWire;

	GameObject[] SetAction;

	private int OrderNum;

	GameObject obj1;
	private Text txtStatus1;

	GameObject obj2;
	private Text txtStatus2;

	int TouchActionNum;

	bool b_AddAction;


	GameObject[] m_BlockObject;
	int BlockObjectNum;

	bool Objecting;

	bool ObjectSelect;
	// Use this for initialization
	void Start () {
		blankTile = transform.gameObject;
		Tile = blankTile;

		touchTile = true;

		b_AddAction = false;

		TouchActionNum = 0;

		OrderNum = 0;

		BlockObjectNum = 0;

		Objecting = false;

		ObjectSelect = false;
		//BtnState = GetComponent<Image> ();

		SetAction = new GameObject[2];

		obj1 = GameObject.Find ("OrderNumber");
		txtStatus1 = obj1.GetComponent<Text> ();

		obj2 = GameObject.Find ("ActionText");
		txtStatus2 = obj2.GetComponent<Text> ();
	}
		

	IEnumerator DelayTouch(){
		yield return new WaitForSeconds(0.45f);
		touchTile = false;
		Objecting = false;
		ObjectSelect = false;
	}

	// Update is called once per frame
	void Update () {
		
		if (EventSystem.current.IsPointerOverGameObject(0)) {
			//Debug.Log ("UI click");
			return;
		}
		if (EventSystem.current.IsPointerOverGameObject (-1)) {
			//Debug.Log ("UI click");
			return;
		}

		if (Input.touchCount == 1) {
			
			if(ObjectSelect){
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit;
				if (Physics.Raycast (ray, out hit, Mathf.Infinity, currentMask)) {
					for (int i = 0; i < BlockObjectNum; i++) {
						if (m_BlockObject [i] == hit.collider.gameObject && hit.collider.gameObject.layer == 8) {
							StartCoroutine ("DelayTouch");

							TouchActionNum = 0;
							txtStatus2.text = "행동";

							for (int j = 0; j < BlockObjectNum; j++){
								if (m_BlockObject [j].layer == 8) {
									m_BlockObject [j].GetComponent<Renderer> ().sharedMaterial = Mat2;
								}
							}

							Debug.Log ("touchObjectTile");

							//선택한 타일 위치 
							SetAction[0].GetComponent<Renderer> ().sharedMaterial = MatActionObj;
							//obj 이동 위치
							SetAction [0].GetComponent<csTileState> ().ActionObjPosition = m_BlockObject [i];

							TileState.GetComponent<csTileState> ().stateNum = 8;

							break;
						}
					}
				}
			}

			else if (Objecting) {
				touchTile = false;
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit;
				if (Physics.Raycast (ray, out hit, Mathf.Infinity, ObjectMask)) {
					for (int i = 0; i < BlockObjectNum; i++) {
						if (m_BlockObject [i] == hit.collider.gameObject) {
							Debug.Log ("touchObject2");
							//선택한 Obj
							SetAction [0].GetComponent<csTileState> ().ActionObj = m_BlockObject [i];

							ObjectSelect = true;
						} else {
							m_BlockObject [i].GetComponent<Renderer> ().sharedMaterial = Mat;
						}
					}
				}

			} else {
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
								if(TouchActionNum == 1 || TouchActionNum == 6){
									//오브젝트 이동, 더미 설치
									Tile = hit.transform.gameObject;
									if(TouchActionNum == 1){
										//오브젝트 이동
										//Tile.GetComponent<Renderer> ().sharedMaterial = MatActionObj;
									}else if(TouchActionNum == 6){
										//더미 설치
										//Tile.GetComponent<Renderer> ().sharedMaterial = MatActionDummy;
									}

									b_AddAction = true;

									TileLight (Tile, 1);
								}
								else if (TouchActionNum != 0) {
									Tile = hit.transform.gameObject;
									if(TouchActionNum == 2){
										//Speed
										Tile.GetComponent<Renderer> ().sharedMaterial = MatActionSpeed;
										Tile.GetComponent<csTileState> ().stateNum = 9;
									}
									if(TouchActionNum == 3){
										//Fade
										Tile.GetComponent<Renderer> ().sharedMaterial = MatActionFade;
										Tile.GetComponent<csTileState> ().stateNum = 10;
									}
									if(TouchActionNum == 4){
										//Scout
										Tile.GetComponent<Renderer> ().sharedMaterial = MatActionScout;
										Tile.GetComponent<csTileState> ().stateNum = 11;
									}
									if(TouchActionNum == 5){
										//Sound
										Tile.GetComponent<Renderer> ().sharedMaterial = MatActionSound;
										Tile.GetComponent<csTileState> ().stateNum = 12;
									}

									TouchActionNum = 0;
									txtStatus2.text = "행동";
									touchTile = true;
								} 
								else {
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
	}

	void TileLight(GameObject TileObj, int Num){

		deleteBlockObject (TileObj);

		//TileObj.GetComponent<Renderer> ().sharedMaterial = MatActionObj;

		Vector3 vec3;
		float xp1 = TileObj.transform.position.x + 1;
		float xm1 = TileObj.transform.position.x - 1;
		float zp1 = TileObj.transform.position.z + 1;
		float zm1 = TileObj.transform.position.z - 1;
		float xp2 = TileObj.transform.position.x + 2;
		float xm2 = TileObj.transform.position.x - 2;
		float zp2 = TileObj.transform.position.z + 2;
		float zm2 = TileObj.transform.position.z - 2;
		if (Num == 1) {
			m_BlockObject = new GameObject[4];

			RaycastHit hit;
			vec3 = TileObj.transform.position;
			vec3.x = xp1;
			vec3.y += 5.0f;
			if (Physics.Raycast (vec3, TileObj.transform.up * -1.0f, out hit, 5, AddLayerMask)) {
				Debug.Log (hit.collider.gameObject.name);
				TileState = hit.transform.gameObject;

				if (hit.transform.gameObject.layer == 9) {
					//오브젝트
					m_BlockObject [BlockObjectNum] = TileState;
					BlockObjectNum++;
				} else {
					if (TileState.GetComponent<csTileState> ().state) {
						//오브젝트 이동, 더미 설치
						Tile = hit.transform.gameObject;
						//Tile.GetComponent<Renderer> ().sharedMaterial = Mat;
						m_BlockObject [BlockObjectNum] = TileState;
						BlockObjectNum++;
					}
				}

			}

			vec3.x = xm1;
			if (Physics.Raycast (vec3, TileObj.transform.up * -1.0f, out hit, 5, AddLayerMask)) {
				Debug.Log (hit.collider.gameObject.name);
				TileState = hit.transform.gameObject;
				if (hit.transform.gameObject.layer == 9) {
					//오브젝트
					m_BlockObject [BlockObjectNum] = TileState;
					BlockObjectNum++;
				} else {
					if (TileState.GetComponent<csTileState> ().state) {
						//오브젝트 이동, 더미 설치
						Tile = hit.transform.gameObject;
						//Tile.GetComponent<Renderer> ().sharedMaterial = Mat;
						m_BlockObject [BlockObjectNum] = TileState;
						BlockObjectNum++;
					}
				}
			}

			vec3.x = TileObj.transform.position.x;
			vec3.z = zp1;
			if (Physics.Raycast (vec3, TileObj.transform.up * -1.0f, out hit, 5, AddLayerMask)) {
				Debug.Log (hit.collider.gameObject.name);
				TileState = hit.transform.gameObject;
				if (hit.transform.gameObject.layer == 9) {
					//오브젝트
					m_BlockObject [BlockObjectNum] = TileState;
					BlockObjectNum++;
				} else {
					if (TileState.GetComponent<csTileState> ().state) {
						//오브젝트 이동, 더미 설치
						Tile = hit.transform.gameObject;
						//Tile.GetComponent<Renderer> ().sharedMaterial = Mat;
						m_BlockObject [BlockObjectNum] = TileState;
						BlockObjectNum++;
					}
				}
			}

			vec3.z = zm1;
			if (Physics.Raycast (vec3, TileObj.transform.up * -1.0f, out hit, 5, AddLayerMask)) {
				Debug.Log (hit.collider.gameObject.name);
				TileState = hit.transform.gameObject;
				if (hit.transform.gameObject.layer == 9) {
					//오브젝트
					m_BlockObject [BlockObjectNum] = TileState;
					BlockObjectNum++;
				} else {
					if (TileState.GetComponent<csTileState> ().state) {
						//오브젝트 이동, 더미 설치
						Tile = hit.transform.gameObject;
						//Tile.GetComponent<Renderer> ().sharedMaterial = Mat;
						m_BlockObject [BlockObjectNum] = TileState;
						BlockObjectNum++;
					}
				}
			}
		} else if (Num == 2) {

		} else {
			
		}

		for(int i=0; i<BlockObjectNum; i++){
			if (m_BlockObject [i].layer == 9) {
				//오브젝트가 있음
				Debug.Log ("Object");
				Objecting = true;
				SetAction[0] = TileObj;
				break;
			}
			else if(i == BlockObjectNum-1){
				deleteBlockObject(TileObj);
			}
		}
	}

	void deleteBlockObject(GameObject TileObject){
		if(BlockObjectNum != 0){
			for(int i=0; i<BlockObjectNum; i++){
				if (m_BlockObject [i].layer == 8) {
					//Tile 있음
					Debug.Log ("Tile mat delete");
					m_BlockObject [i].GetComponent<Renderer> ().sharedMaterial = Mat2;
				}
			}

			BlockObjectNum = 0;
		}
		TileObject.GetComponent<Renderer> ().sharedMaterial = Mat2;
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
		BtnActionState.SetActive(false);
	}

	public void OnStayImg(){
		//Debug.Log("OnMoveImg");
		BtnStayState.SetActive(true);
		BtnActionState.SetActive(false);
		BtnMoveState.SetActive(false);

	}

	public void OnActionBtn(){
		touchTile = false;
		if (BtnActionState.activeInHierarchy) {
			BtnActionState.SetActive (false);
		} else {
			BtnActionState.SetActive(true);
		}
		BtnStayState.SetActive(false);
		BtnMoveState.SetActive(false);
	}

	public void BtnActionObjMove(){
		txtStatus2.text = "오브젝트";
		BtnActionState.SetActive (false);
		TouchActionNum = 1;
		touchTile = false;
	}

	public void BtnActionSpeed(){
		txtStatus2.text = "가 속";
		BtnActionState.SetActive (false);
		TouchActionNum = 2;
		touchTile = false;
	}

	public void BtnActionFade(){
		txtStatus2.text = "은 신";
		BtnActionState.SetActive (false);
		TouchActionNum = 3;
		touchTile = false;
	}

	public void BtnActionScout(){
		txtStatus2.text = "스카우터";
		BtnActionState.SetActive (false);
		TouchActionNum = 4;
		touchTile = false;
	}

	public void BtnActionSound(){
		txtStatus2.text = "무음기동";
		BtnActionState.SetActive (false);
		TouchActionNum = 5;
		touchTile = false;
	}

	public void BtnActiondummyInstall(){
		txtStatus2.text = "더미설치";
		BtnActionState.SetActive (false);
		TouchActionNum = 6;
		touchTile = false;
	}

	public void BtnActionEMP(){
		txtStatus2.text = "EMP";
		BtnActionState.SetActive (false);
		TouchActionNum = 7;
		touchTile = false;
	}

	public void BtnActionWire(){
		txtStatus2.text = "와이어";
		BtnActionState.SetActive (false);
		TouchActionNum = 8;
		touchTile = false;
	}



	public void OnMoveImgUp(){
		
		Tile.GetComponent<Renderer> ().sharedMaterial = MatUp;
		csTileState TileST = Tile.GetComponent<csTileState> ();
		TileST.stateNum = 1;
		BtnState.SetActive(false);
		BtnMoveState.SetActive(false);
		BtnMenuState.SetActive (false);
		//touchTile = true;
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
		//touchTile = true;
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
		//touchTile = true;
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
		//touchTile = true;
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
		//touchTile = true;
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
		//touchTile = true;
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
		//touchTile = true;
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
