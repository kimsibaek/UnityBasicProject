using UnityEngine;
using System.Collections;

public class csCharacterState : MonoBehaviour {
	public static int ActionObjMoveState;
	public static int ActionSpeedTimeState;
	public static int ActionFadeTimeState;
	public static int ActionScoutTimeState;
	public static int ActionSoundTimeState;
	public static int ActiondummyTimeState;
	public static int ActionEMPTimeState;
	// Use this for initialization
	void Start () {
		ActionObjMoveState = 1;
		ActionSpeedTimeState = 3;
		ActionFadeTimeState = 2;
		ActionScoutTimeState = 4;
		ActionSoundTimeState = 4;
		ActiondummyTimeState = 4;
		ActionEMPTimeState = 5;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
