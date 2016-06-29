using UnityEngine;
using System.Collections;

public class csMousePoint : MonoBehaviour {
	public static GameObject blankTile;

	public static GameObject Tile;
	public static bool TileSelect;
	public LayerMask currentMask;
	public Material Mat;
	public Material Mat2;

	bool bMouseDown;

	Vector3 scrSpace;
	Vector3 offset;

	float frontx;
	float fronty;
	float tailx;
	float taily;



	private GameObject TileState;
	// Use this for initialization
	void Start () {
		blankTile = transform.gameObject;
		Tile = blankTile;
	}
		
	// Update is called once per frame
	void Update () {
		
		/*
		if(Input.GetButtonDown("Fire1")){
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

}
