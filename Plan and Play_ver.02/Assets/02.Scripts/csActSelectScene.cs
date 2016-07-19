using UnityEngine;
using System.Collections;

public class csActSelectScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		int Number1 = SqliteActSelect.Star1[0] + SqliteActSelect.Star1[1] + SqliteActSelect.Star1[2] + 
			SqliteActSelect.Star2[0] + SqliteActSelect.Star2[1] + SqliteActSelect.Star2[2] + 
			SqliteActSelect.Star3[0] + SqliteActSelect.Star3[1] + SqliteActSelect.Star3[2];
		if(Number1 == 9){
			Number1++;
		}
		int Number2 = SqliteActSelect.Star1[3] + SqliteActSelect.Star1[4] + SqliteActSelect.Star1[5] + 
			SqliteActSelect.Star2[3] + SqliteActSelect.Star2[4] + SqliteActSelect.Star2[5] + 
			SqliteActSelect.Star3[3] + SqliteActSelect.Star3[4] + SqliteActSelect.Star3[5];
		if(Number2 == 9){
			Number2++;
		}
		int Number3 = SqliteActSelect.Star1[6] + SqliteActSelect.Star1[7] + SqliteActSelect.Star1[8] + 
			SqliteActSelect.Star2[6] + SqliteActSelect.Star2[7] + SqliteActSelect.Star2[9] + 
			SqliteActSelect.Star3[6] + SqliteActSelect.Star3[7] + SqliteActSelect.Star3[9];
		if(Number3 == 9){
			Number3++;
		}
		int Number4 = SqliteActSelect.Star1[9] + SqliteActSelect.Star1[10] + SqliteActSelect.Star1[11] + 
			SqliteActSelect.Star2[9] + SqliteActSelect.Star2[10] + SqliteActSelect.Star2[11] + 
			SqliteActSelect.Star3[9] + SqliteActSelect.Star3[10] + SqliteActSelect.Star3[11];
		if(Number4 == 9){
			Number4++;
		}
		int numberSum = Number1 + Number2 + Number3 + Number4;
		GameObject obj1 = GameObject.Find ("InstantGUI/StageNumber/SPWindow/MaxSP");
		obj1.GetComponent<InstantGuiButton> ().text = numberSum.ToString();
		SqliteActSelect.MaxSP = numberSum;
		GameObject obj2 = GameObject.Find ("InstantGUI/StageNumber/SPWindow/MySP");
		obj2.GetComponent<InstantGuiButton> ().text = numberSum.ToString();
		SqliteActSelect.MySP = numberSum;

		SqliteActSelect.Action_Telepo = 0;
		SqliteActSelect.Action_Teleki = 0;
		SqliteActSelect.Action_Fast = 0;
		SqliteActSelect.Action_Stealth = 0;
		SqliteActSelect.Action_Mute = 0;
		SqliteActSelect.Action_Dummy = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
