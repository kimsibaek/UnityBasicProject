using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class csMousePoint : MonoBehaviour {
	public static GameObject blankTile;

	public static GameObject Tile;


	public static bool TileSelect;

	public LayerMask currentMask;
	public LayerMask currentUIMask;

	public Material Mat;
	public Material Mat2;

	public GameObject BtnState;
	public GameObject BtnMoveState;

	public static bool touchTile;

	private GameObject TileState;

	public Material MatUp;
	public Material MatDown;
	public Material MatLeft;
	public Material MatRight;

	// Use this for initialization
	void Start () {
		blankTile = transform.gameObject;
		Tile = blankTile;

		touchTile = true;
		//BtnState = GetComponent<Image> ();
	}
		
	// Update is called once per frame
	void Update () {
		if (Input.touchCount == 1) {
			Touch touch = Input.GetTouch (0);
			if (touch.phase == TouchPhase.Ended && csCameraMove.bMouseDown) {
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit;
				if (Physics.Raycast (ray, out hit, Mathf.Infinity, currentUIMask)) {
					Debug.Log (hit.collider.gameObject.name);
				} else {
					if (Physics.Raycast (ray, out hit, Mathf.Infinity, currentMask)) {
						Debug.Log (hit.collider.gameObject.name);


						if (hit.transform.tag.Equals ("Tile") && touchTile) {
							TileState = hit.transform.gameObject;
							if (TileState.GetComponent<csTileState> ().state) {
								TileSelect = true;
								Tile = hit.transform.gameObject;
								Tile.GetComponent<Renderer> ().material = Mat;

								BtnState.SetActive (true);
								touchTile = false;
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
						Tile.GetComponent<Renderer> ().material = Mat2;
						Tile = blankTile;

					}
				}

			} else {
				
			}
		}



		/*
		if(Input.GetButtonDown("Fire1") ){
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit, Mathf.Infinity, currentMask)) {
				//Debug.Log (hit.collider.gameObject.name);


				if (hit.transform.tag.Equals ("Tile")) {
					TileState = hit.transform.gameObject;
					if(TileState.GetComponent<csTileState> ().state){
						TileSelect = true;
						Tile = hit.transform.gameObject;
						Tile.GetComponent<Renderer> ().material = Mat;
					}
				}
			} else {
				TileSelect = false;
				if(Tile == blankTile){
					return;
				}
				Tile.GetComponent<Renderer> ().material = Mat2;
				Tile = blankTile;
			}
		}
		*/

	}

	public void OnMoveImg(){
		Debug.Log("OnMoveImg");
		BtnMoveState.SetActive(true);
	}

	public void OnMoveImgUp(){
		Tile.GetComponent<Renderer> ().material = MatUp;
		touchTile = true;
		TileSelect = false;
		BtnState.SetActive(false);
		BtnMoveState.SetActive(false);

	}
	public void OnMoveImgDown(){
		Tile.GetComponent<Renderer> ().material = MatDown;
		touchTile = true;
		TileSelect = false;
		BtnState.SetActive(false);
		BtnMoveState.SetActive(false);
	}
	public void OnMoveImgLeft(){
		Tile.GetComponent<Renderer> ().material = MatLeft;
		touchTile = true;
		TileSelect = false;
		BtnState.SetActive(false);
		BtnMoveState.SetActive(false);
	}
	public void OnMoveImgRight(){
		Tile.GetComponent<Renderer> ().material = MatRight;
		touchTile = true;
		TileSelect = false;
		BtnState.SetActive(false);
		BtnMoveState.SetActive(false);
	}
}
