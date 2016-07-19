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

	public GameObject BtnActionState;

	public static bool touchTile;

	private GameObject TileState;

	public GameObject BtnAction;

	public Sprite ActionSprite;

	public Sprite ActionObj;
	public Sprite ActionSpeed;
	public Sprite ActionFade;
	public Sprite ActionPositionChange;
	public Sprite ActionSound;
	public Sprite ActionDummy;

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
	public Material MatActionPositionChange;
	public Material MatActionSound;
	public Material MatActionDummy;
	public Material MatActionEMP;
	public Material MatActionWire;
	/// <summary>
	public Material Matbarrior1;
	public Material Matbarrior2;
	public Material Matbarrior3;
	/// </summary>
	GameObject SetAction;

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

		obj1 = GameObject.Find ("OrderNumber");
		txtStatus1 = obj1.GetComponent<Text> ();

		obj2 = GameObject.Find ("ActionText");
		txtStatus2 = obj2.GetComponent<Text> ();
	}
		

	IEnumerator DelayTouch(){
		yield return new WaitForSeconds(0.55f);
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
							BtnAction.GetComponent<Image> ().sprite = ActionSprite;
							SqliteActSelect.Action_Teleki--;

							for (int j = 0; j < BlockObjectNum; j++){
								if (m_BlockObject [j].layer == 8) {
									m_BlockObject [j].GetComponent<Renderer> ().sharedMaterial = Mat2;
								}
							}

							//Debug.Log ("touchObjectTile");

							//선택한 타일 위치 
							SetAction.GetComponent<Renderer> ().sharedMaterial = MatActionObj;
							//Debug.Log (SetAction);
							//obj 이동 위치
							SetAction.GetComponent<csTileState> ().ActionObjPosition = m_BlockObject [i];
							//Debug.Log (SetAction.GetComponent<csTileState> ().ActionObjPosition);
							SetAction.GetComponent<csTileState> ().stateNum = 8;
							OrderNumPlus ();
							ObjectSelect = false;
							break;
						}
					}
				}
			}

			else if (Objecting) {
				if(TouchActionNum == 1){
					touchTile = false;
					Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
					RaycastHit hit;
					if (Physics.Raycast (ray, out hit, Mathf.Infinity, ObjectMask)) {
						for (int i = 0; i < BlockObjectNum; i++) {

							if (m_BlockObject [i] == hit.collider.gameObject) {
								//Debug.Log ("touchObject2");
								//선택한 Obj
								SetAction.GetComponent<csTileState> ().ActionObj = m_BlockObject [i];
								//Debug.Log (SetAction.GetComponent<csTileState> ().ActionObj);
								ObjectSelect = true;

								Material[] matChange = new Material[2];
								for(int k = 0; k < BlockObjectNum; k++){
									if (m_BlockObject [k].layer == 9){
										matChange [0] = Matbarrior1;
										matChange [1] = Matbarrior2;
										m_BlockObject [k].GetComponent<Renderer> ().sharedMaterials = matChange;
									}
								}
							} else {
								m_BlockObject [i].GetComponent<Renderer> ().sharedMaterial = Mat;
							}
						}
					}
				}
				else if(TouchActionNum == 6){
					touchTile = false;
					Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
					RaycastHit hit;
					if (Physics.Raycast (ray, out hit, Mathf.Infinity, currentMask)) {
						for (int i = 0; i < BlockObjectNum; i++) {
							if (m_BlockObject [i] == hit.collider.gameObject) {
								TouchActionNum = 0;
								txtStatus2.text = "행동";
								BtnAction.GetComponent<Image> ().sprite = ActionSprite;
								SqliteActSelect.Action_Dummy--;
								//선택한 타일 위치 
								SetAction.GetComponent<Renderer> ().sharedMaterial = MatActionDummy;
								Debug.Log (SetAction);
								//dummy 위치
								SetAction.GetComponent<csTileState> ().ActionObjPosition = m_BlockObject [i];
								Debug.Log (SetAction.GetComponent<csTileState> ().ActionObjPosition);
								SetAction.GetComponent<csTileState> ().stateNum = 13;
								OrderNumPlus ();

							} 
							m_BlockObject [i].GetComponent<Renderer> ().sharedMaterial = Mat2;

							StartCoroutine ("DelayTouch");
						}

					}
				}
			} else {
				Touch touch = Input.GetTouch (0);
				if (touch.phase == TouchPhase.Ended && csCameraMove.bMouseDown && touchTile) {
					Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
					RaycastHit hit;
					//Debug.Log ("touchTile");
					if (Physics.Raycast (ray, out hit, Mathf.Infinity, currentMask)) {
						//Debug.Log (hit.collider.gameObject.name);

						if (hit.transform.CompareTag("Tile")) {
							TileState = hit.transform.gameObject;
							if (TileState.GetComponent<csTileState> ().state) {
								if(TouchActionNum == 1 || TouchActionNum == 6){
									//오브젝트 이동, 더미 설치
									Tile = hit.transform.gameObject;
									if(TouchActionNum == 1){
										TileLight (Tile, 1);
									}else if(TouchActionNum == 6){
										//더미 설치
										//Tile.GetComponent<Renderer> ().sharedMaterial = MatActionDummy;
										TileLight (Tile);
									}


								}
								else if (TouchActionNum != 0) {
									Tile = hit.transform.gameObject;
									if(TouchActionNum == 2){
										//Speed
										Tile.GetComponent<Renderer> ().sharedMaterial = MatActionSpeed;
										Tile.GetComponent<csTileState> ().stateNum = 9;
										OrderNumPlus ();
										SqliteActSelect.Action_Fast--;
									}
									if(TouchActionNum == 3){
										//Fade
										Tile.GetComponent<Renderer> ().sharedMaterial = MatActionFade;
										Tile.GetComponent<csTileState> ().stateNum = 10;
										OrderNumPlus ();
										SqliteActSelect.Action_Stealth--;
									}
									if(TouchActionNum == 4){
										//위치이동
										Tile.GetComponent<Renderer> ().sharedMaterial = MatActionPositionChange;
										Tile.GetComponent<csTileState> ().stateNum = 11;
										OrderNumPlus ();
										SqliteActSelect.Action_Telepo--;
									}
									if(TouchActionNum == 5){
										//Sound
										Tile.GetComponent<Renderer> ().sharedMaterial = MatActionSound;
										Tile.GetComponent<csTileState> ().stateNum = 12;
										OrderNumPlus ();
										SqliteActSelect.Action_Mute--;
									}

									TouchActionNum = 0;
									txtStatus2.text = "행동";
									BtnAction.GetComponent<Image> ().sprite = ActionSprite;
									touchTile = true;
								} 
								else {
									TileSelect = true;
									Tile = hit.transform.gameObject;
									Tile.GetComponent<Renderer> ().sharedMaterial = Mat;
									//csTileState TileST = Tile.GetComponent<csTileState> ();
									//Debug.Log (TileST.stateNum);

									BtnState.SetActive (true);
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

	void TileLight(GameObject TileObj){
		deleteBlockObject (TileObj);
		m_BlockObject = new GameObject[60];
		//BlockObjectNum = 0;
		for(int i=-5; i<=5; i++){
			for(int k=-5; k<=5; k++){
				int I_abs = Mathf.Abs (i) + Mathf.Abs (k);
				if(I_abs < 6 && I_abs != 0){
					RaycastHit hit;
					Vector3 vec3 = TileObj.transform.position;
					vec3.x += i;
					vec3.y += 5.0f;
					vec3.z += k;
					if (Physics.Raycast (vec3, TileObj.transform.up * -1.0f, out hit, 5, currentMask)) {
						//Debug.Log (hit.collider.gameObject.name);
						TileState = hit.transform.gameObject;

						if (TileState.GetComponent<csTileState> ().state && TileState.GetComponent<csTileState> ().stateNum == 0) {
							//오브젝트 이동, 더미 설치
							//Tile = hit.transform.gameObject;
							//Tile.GetComponent<Renderer> ().sharedMaterial = Mat;
							m_BlockObject [BlockObjectNum] = TileState;
							BlockObjectNum++;
						}
					}
				}
			}
		}
		SetAction = TileObj;
		for(int i=0; i<BlockObjectNum; i++){
			
			Objecting = true;
			m_BlockObject [i].GetComponent<Renderer> ().sharedMaterial = Mat;

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
				//Debug.Log (hit.collider.gameObject.name);
				TileState = hit.transform.gameObject;

				if (hit.transform.gameObject.layer == 9) {
					//오브젝트
					m_BlockObject [BlockObjectNum] = TileState;
					BlockObjectNum++;
				} else {
					if (TileState.GetComponent<csTileState> ().state && TileState.GetComponent<csTileState> ().stateNum == 0) {
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
				//Debug.Log (hit.collider.gameObject.name);
				TileState = hit.transform.gameObject;
				if (hit.transform.gameObject.layer == 9) {
					//오브젝트
					m_BlockObject [BlockObjectNum] = TileState;
					BlockObjectNum++;
				} else {
					if (TileState.GetComponent<csTileState> ().state && TileState.GetComponent<csTileState> ().stateNum == 0) {
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
				//Debug.Log (hit.collider.gameObject.name);
				TileState = hit.transform.gameObject;
				if (hit.transform.gameObject.layer == 9) {
					//오브젝트
					m_BlockObject [BlockObjectNum] = TileState;
					BlockObjectNum++;
				} else {
					if (TileState.GetComponent<csTileState> ().state && TileState.GetComponent<csTileState> ().stateNum == 0) {
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
				//Debug.Log (hit.collider.gameObject.name);
				TileState = hit.transform.gameObject;
				if (hit.transform.gameObject.layer == 9) {
					//오브젝트
					m_BlockObject [BlockObjectNum] = TileState;
					BlockObjectNum++;
				} else {
					if (TileState.GetComponent<csTileState> ().state && TileState.GetComponent<csTileState> ().stateNum == 0) {
						//오브젝트 이동, 더미 설치
						Tile = hit.transform.gameObject;
						//Tile.GetComponent<Renderer> ().sharedMaterial = Mat;
						m_BlockObject [BlockObjectNum] = TileState;
						BlockObjectNum++;
					}
				}
			}

			bool checkobj = false;
			Material[] matChange = new Material[2];
			for(int i=0; i<BlockObjectNum; i++){
				if (m_BlockObject [i].layer == 9) {
					//오브젝트가 있음
					//Debug.Log ("Object");

					Objecting = true;
					SetAction = TileObj;
					checkobj = true;
					matChange [0] = Matbarrior3;
					matChange [1] = Matbarrior2;

					m_BlockObject [i].GetComponent<Renderer> ().sharedMaterials = matChange;
				}
				else if(i == BlockObjectNum-1 && !checkobj){
					deleteBlockObject(TileObj);
				}
			}
		} else if (Num == 2) {
			m_BlockObject = new GameObject[4];

			RaycastHit hit;
			vec3 = TileObj.transform.position;
			vec3.x = xp2;
			vec3.y += 5.0f;
			if (Physics.Raycast (vec3, TileObj.transform.up * -1.0f, out hit, 5, AddLayerMask)) {
				//Debug.Log (hit.collider.gameObject.name);
				TileState = hit.transform.gameObject;

				if (hit.transform.gameObject.layer == 9) {
					//오브젝트
					m_BlockObject [BlockObjectNum] = TileState;
					BlockObjectNum++;
				} else {
					if (TileState.GetComponent<csTileState> ().state && TileState.GetComponent<csTileState> ().stateNum == 0) {
						//오브젝트 이동, 더미 설치
						Tile = hit.transform.gameObject;
						//Tile.GetComponent<Renderer> ().sharedMaterial = Mat;
						m_BlockObject [BlockObjectNum] = TileState;
						BlockObjectNum++;
					}
				}

			}

			vec3.x = xm2;
			if (Physics.Raycast (vec3, TileObj.transform.up * -1.0f, out hit, 5, AddLayerMask)) {
				//Debug.Log (hit.collider.gameObject.name);
				TileState = hit.transform.gameObject;
				if (hit.transform.gameObject.layer == 9) {
					//오브젝트
					m_BlockObject [BlockObjectNum] = TileState;
					BlockObjectNum++;
				} else {
					if (TileState.GetComponent<csTileState> ().state && TileState.GetComponent<csTileState> ().stateNum == 0) {
						//오브젝트 이동, 더미 설치
						Tile = hit.transform.gameObject;
						//Tile.GetComponent<Renderer> ().sharedMaterial = Mat;
						m_BlockObject [BlockObjectNum] = TileState;
						BlockObjectNum++;
					}
				}
			}

			vec3.x = TileObj.transform.position.x;
			vec3.z = zp2;
			if (Physics.Raycast (vec3, TileObj.transform.up * -1.0f, out hit, 5, AddLayerMask)) {
				//Debug.Log (hit.collider.gameObject.name);
				TileState = hit.transform.gameObject;
				if (hit.transform.gameObject.layer == 9) {
					//오브젝트
					m_BlockObject [BlockObjectNum] = TileState;
					BlockObjectNum++;
				} else {
					if (TileState.GetComponent<csTileState> ().state && TileState.GetComponent<csTileState> ().stateNum == 0) {
						//오브젝트 이동, 더미 설치
						Tile = hit.transform.gameObject;
						//Tile.GetComponent<Renderer> ().sharedMaterial = Mat;
						m_BlockObject [BlockObjectNum] = TileState;
						BlockObjectNum++;
					}
				}
			}

			vec3.z = zm2;
			if (Physics.Raycast (vec3, TileObj.transform.up * -1.0f, out hit, 5, AddLayerMask)) {
				//Debug.Log (hit.collider.gameObject.name);
				TileState = hit.transform.gameObject;
				if (hit.transform.gameObject.layer == 9) {
					//오브젝트
					m_BlockObject [BlockObjectNum] = TileState;
					BlockObjectNum++;
				} else {
					if (TileState.GetComponent<csTileState> ().state && TileState.GetComponent<csTileState> ().stateNum == 0) {
						//오브젝트 이동, 더미 설치
						Tile = hit.transform.gameObject;
						//Tile.GetComponent<Renderer> ().sharedMaterial = Mat;
						m_BlockObject [BlockObjectNum] = TileState;
						BlockObjectNum++;
					}
				}
			}

			bool checkobj = false;
			Material[] matChange = new Material[2];
			for(int i=0; i<BlockObjectNum; i++){
				if (m_BlockObject [i].layer == 9) {
					//오브젝트가 있음
					//Debug.Log ("Object");

					Objecting = true;
					SetAction = TileObj;
					checkobj = true;
					matChange [0] = Matbarrior3;
					matChange [1] = Matbarrior2;

					m_BlockObject [i].GetComponent<Renderer> ().sharedMaterials = matChange;
				}
				else if(i == BlockObjectNum-1 && !checkobj){
					deleteBlockObject(TileObj);
				}
			}
		} else {
			
		}

	}

	void deleteBlockObject(GameObject TileObject){
		if(BlockObjectNum != 0){
			for(int i=0; i<BlockObjectNum; i++){
				if (m_BlockObject [i].layer == 8) {
					//Tile 있음
					//Debug.Log ("Tile mat delete");
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
			//Vector3 CameraPosition;
			//CameraPosition = Tile.transform.position;
			//CameraPosition += Vector3.up * 6.0f;
			//CameraPosition += Vector3.forward * 2.0f;
			transform.position = Tile.transform.position;
			transform.position -= Vector3.down * 6.0f;
			transform.position += Vector3.forward * 2.0f;
		}

	}

	IEnumerator ActionFadOut(){
		//Debug.Log ("은신2");
		for(float i = 1f; i >= 0.0f; i -= 0.05f)
		{
			
			yield return 0;
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

			//actionCount
			GameObject text1 = GameObject.Find ("Canvas/ActionState/BtnObjMove/CountText");
			text1.GetComponent<Text> ().text = SqliteActSelect.Action_Teleki.ToString ();

			GameObject text2 = GameObject.Find ("Canvas/ActionState/BtnSpeed/CountText");
			text2.GetComponent<Text> ().text = SqliteActSelect.Action_Fast.ToString ();

			GameObject text3 = GameObject.Find ("Canvas/ActionState/BtnFade/CountText");
			text3.GetComponent<Text> ().text = SqliteActSelect.Action_Stealth.ToString ();

			GameObject text4 = GameObject.Find ("Canvas/ActionState/BtnPositionChange/CountText");
			text4.GetComponent<Text> ().text = SqliteActSelect.Action_Telepo.ToString ();

			GameObject text5 = GameObject.Find ("Canvas/ActionState/BtnSound/CountText");
			text5.GetComponent<Text> ().text = SqliteActSelect.Action_Mute.ToString ();

			GameObject text6 = GameObject.Find ("Canvas/ActionState/BtnBoxInstall/CountText");
			text6.GetComponent<Text> ().text = SqliteActSelect.Action_Dummy.ToString ();

		}
		BtnStayState.SetActive(false);
		BtnMoveState.SetActive(false);
	}

	public void BtnActionObjMove(){
		BtnActionState.SetActive (false);
		if(SqliteActSelect.Action_Teleki == 0){
			return;
		}
		txtStatus2.text = "";
		BtnAction.GetComponent<Image> ().sprite = ActionObj;
		TouchActionNum = 1;
		touchTile = false;

	}

	public void BtnActionSpeed(){
		BtnActionState.SetActive (false);
		if(SqliteActSelect.Action_Fast == 0){
			return;
		}
		txtStatus2.text = "";
		BtnAction.GetComponent<Image> ().sprite = ActionSpeed;
		TouchActionNum = 2;
		touchTile = false;
	}

	public void BtnActionFade(){
		BtnActionState.SetActive (false);
		if(SqliteActSelect.Action_Stealth == 0){
			return;
		}
		txtStatus2.text = "";
		BtnAction.GetComponent<Image> ().sprite = ActionFade;
		TouchActionNum = 3;
		touchTile = false;
	}

	public void BtnActionPositionChange(){
		BtnActionState.SetActive (false);
		if(SqliteActSelect.Action_Telepo == 0){
			return;
		}
		txtStatus2.text = "";
		BtnAction.GetComponent<Image> ().sprite = ActionPositionChange;
		TouchActionNum = 4;
		touchTile = false;
	}

	public void BtnActionSound(){
		BtnActionState.SetActive (false);
		if(SqliteActSelect.Action_Mute == 0){
			return;
		}
		txtStatus2.text = "";
		BtnAction.GetComponent<Image> ().sprite = ActionSound;
		TouchActionNum = 5;
		touchTile = false;
	}

	public void BtnActiondummyInstall(){
		BtnActionState.SetActive (false);
		if(SqliteActSelect.Action_Dummy == 0){
			return;
		}
		txtStatus2.text = "";
		BtnAction.GetComponent<Image> ().sprite = ActionDummy;
		TouchActionNum = 6;
		touchTile = false;
	}



	public void OnMoveImgUp(){
		
		Tile.GetComponent<Renderer> ().sharedMaterial = MatUp;
		csTileState TileST = Tile.GetComponent<csTileState> ();
		TileST.stateNum = 1;
		BtnState.SetActive(false);
		BtnMoveState.SetActive(false);
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
		//touchTile = true;
		TileSelect = false;


	}

	void OrderNumPlus(){
		OrderNum++;
		Debug.Log ("OrderNumPlus");
		txtStatus1.text = "Order " + OrderNum;
	}

	void OrderNumMinus(){
		OrderNum--;
		Debug.Log ("OrderNumMinus");
		txtStatus1.text = "Order " + OrderNum;
	}
}
