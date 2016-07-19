using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class csCharacterMove : MonoBehaviour {

	public static Animator anim;
	public static bool b_PlayTime;
	public static float PlayTime;

	public static bool b_StartMove;

	public static bool StartPlay;

	public static bool GameOver;

	public GameObject BodyMat;

	public static float f_staytime;

	GameObject obj1;
	Text txtStatus1;

	GameObject Startobj;
	Text StarttxtStatus;

	public static bool SpeedGame;
	// Use this for initialization

	public Material Mat1;
	public Material Mat2;

	public static bool CharacterNoSound;

	public GameObject Dummy;

	csTileState TS;

	void Start () {
		anim = GetComponent<Animator> ();
		b_PlayTime = false;
		PlayTime = 0;
		StartPlay = true;
		GameOver = false;
		b_StartMove = false;
		SpeedGame = false;
		CharacterNoSound = false;
		obj1 = GameObject.Find ("PlayTimeNumber");
		txtStatus1 = obj1.GetComponent<Text> ();

		Startobj = GameObject.Find ("StartText");
		StarttxtStatus = Startobj.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if(b_PlayTime){
			PlayTime += Time.deltaTime;
			PlayTimeUpdate ();
			if(b_StartMove){
				//Debug.Log ("Move");
				if(f_staytime == 0){
					transform.Translate (Vector3.forward * anim.speed * Time.smoothDeltaTime);
				}

			}
		
		}

	}

	IEnumerator coAnimTime(){
		//Debug.Log ("coAnimTime");
		anim.SetBool ("StateWalk", false);
		yield return new WaitForSeconds(0.55f);
		b_StartMove = true;
		//Debug.Log("coAnimTime");
		anim.SetBool ("StateWalk", true);
	}

	public void PlayTimeUpdate(){
		string hour;
		string second;

		int i = (int)(PlayTime / 60);
		if (i < 10) {
			hour = "0" + i;
		} else {
			hour = "" + i;
		}

		int j = (int)(PlayTime % 60);
		if (j < 10) {
			second = "0" + j;
		} else {
			second = "" + j;
		}


		txtStatus1.text = "Play time " + hour + ":" + second;
	}

	void OnCollisionEnter(Collision collision){
		//Debug.Log (collision.gameObject.name);
		TS = collision.gameObject.GetComponent<csTileState> ();

		if (TS.state) {
			//가능
			switch(TS.stateNum){
			case 0:
				//Debug.Log ("coAnimWalk");
				//StartCoroutine ("coAnimWalk");
				break;
			case 1:
				
				if (!TS.SwitchButton) {
					StartCoroutine ("coAnimTurnUp");
				}
				//coAnimTurnUp ();
				break;
			case 2:
				//Debug.Log ("coAnimTurnDown");
				if (!TS.SwitchButton) {
					StartCoroutine ("coAnimTurnDown");
				}
				//coAnimTurnDown();
				break;
			case 3:
				//Debug.Log ("coAnimTurnLeft");
				if (!TS.SwitchButton) {
					StartCoroutine ("coAnimTurnLeft");
				}
				//coAnimTurnLeft ();
				break;
			case 4:
				//Debug.Log ("coAnimTurnRight");
				if (!TS.SwitchButton) {
					StartCoroutine ("coAnimTurnRight");
				}
				//coAnimTurnRight ();
				break;
			case 5:
				//Debug.Log ("coAnimStayOne");
				StartCoroutine ("coAnimStayOne");
				//coAnimTurnRight ();
				break;
			case 6:
				//Debug.Log ("coAnimStayTwo");
				StartCoroutine ("coAnimStayTwo");
				//coAnimTurnRight ();
				break;
			case 7:
				//Debug.Log ("coAnimStayThree");
				StartCoroutine ("coAnimStayThree");
				//coAnimTurnRight ();
				break;
			case 8:
				//Debug.Log ("오브젝트 이동");
				StartCoroutine ("coAnimStayOne");
				//coAnimTurnRight ();
				break;
			case 9:
				//Debug.Log ("가속");
				StartCoroutine ("ActionSpeed");
				//coAnimTurnRight ();
				break;
			case 10:
				//Debug.Log ("은신");
				StartCoroutine ("ActionFad");
				//coAnimTurnRight ();
				break;
			case 11:
				//Debug.Log ("위치이동");
				StartCoroutine ("ActionPositionChange");
				//coAnimTurnRight ();
				break;
			case 12:
				//Debug.Log ("무음기동");
				StartCoroutine ("ActionSound");
				//coAnimTurnRight ();
				break;
			case 13:
				Debug.Log ("더미 설치");
				StartCoroutine ("ActiondummyInstall");
				Dummy = Instantiate (Resources.Load ("0.0")) as GameObject;
				Dummy.transform.position = collision.gameObject.GetComponent<csTileState>().ActionObjPosition.transform.position;
				Dummy.transform.position += Vector3.up * 0.1f;
				//coAnimTurnRight ();
				break;
			case 14:
				//Debug.Log ("EMP");
				StartCoroutine ("coAnimStayThree");
				//coAnimTurnRight ();
				break;
			case 15:
				//Debug.Log ("와이어");
				StartCoroutine ("coAnimStayThree");
				//coAnimTurnRight ();
				break;
			}

		} else {
			//불가능
			Debug.Log ("game over");
			GameOver = true;
			anim.SetBool ("StateWalk", false);
			f_staytime = 1;
			//Application.LoadLevel("Result");

		}
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag("Sucess")) {
			Debug.Log ("game Sucess");
			GameOver = false;
		}
		else if(other.gameObject.CompareTag("NoSound")){
			if(!CharacterNoSound){
				Debug.Log ("game over");
				GameOver = true;
			}
		}else {
			Debug.Log ("game over");
			GameOver = true;
		}
		//Application.LoadLevel("Result");
	}

	public void StartAnim(){
		csMousePoint.touchTile = false;
		if (StartPlay) {
			StartPlay = false;
			gameObject.transform.position -= Vector3.up * 0.1f; 
			StartCoroutine ("coAnimTime");
			b_PlayTime = true;



		} else {
			if (b_PlayTime) {
				b_PlayTime = false;
				anim.SetBool ("StateWalk", false);
				//Debug.Log ("일시정지");
				StarttxtStatus.text = "재생";
				Time.timeScale = 0;

			} else {
				b_PlayTime = true;
				anim.SetBool ("StateWalk", true);
				//Debug.Log ("재생");

				StarttxtStatus.text = "일시정지";
				Time.timeScale = 1;
			}
		}


	}

	public void SpeedTime(){
		csMousePoint.touchTile = false;
		if(Time.timeScale == 0){
			return;
		}
		if (anim.speed == 1) {
			//2배속
			SpeedGame = true;
			anim.speed = 2;

		} else {
			//1배속
			SpeedGame = false;
			anim.speed = 1;

		}

	}

	void coAnimWalk(){
		//anim.SetBool ("StateWalk", true);

	}

	IEnumerator ReStartWalk(){
		yield return new WaitForSeconds (f_staytime/anim.speed);
		anim.SetBool ("StateWalk", true);
		f_staytime = 0;
	}

	IEnumerator coAnimTurnUp(){
		if(!TS.SwitchButtonDelay){
			yield return new WaitForSeconds (0.55f/anim.speed);
		}
		transform.rotation = Quaternion.Euler (0, 0, 0);

		//anim.SetBool ("StateWalk", true);
	}

	IEnumerator coAnimTurnDown(){
		if(!TS.SwitchButtonDelay){
			yield return new WaitForSeconds (0.55f/anim.speed);
		}
		transform.rotation = Quaternion.Euler (0, 180.0f, 0);

		//anim.SetBool ("StateWalk", true);
	}

	IEnumerator coAnimTurnLeft(){
		if(!TS.SwitchButtonDelay){
			yield return new WaitForSeconds (0.55f/anim.speed);
		}
		transform.rotation = Quaternion.Euler (0, 270.0f, 0);
		//anim.SetBool ("StateWalk", true);
	}

	IEnumerator coAnimTurnRight(){
		if(!TS.SwitchButtonDelay){
			yield return new WaitForSeconds (0.55f/anim.speed);
		}
		transform.rotation = Quaternion.Euler (0, 90.0f, 0);
			
		//anim.SetBool ("StateWalk", true);
	}
	IEnumerator coAnimStayOne(){
		yield return new WaitForSeconds (0.55f/anim.speed);
		f_staytime = 1;
		anim.SetBool ("StateWalk", false);
		StartCoroutine ("ReStartWalk");

	}
	IEnumerator coAnimStayTwo(){
		yield return new WaitForSeconds (0.55f/anim.speed);
		f_staytime = 2;
		anim.SetBool ("StateWalk", false);
		StartCoroutine ("ReStartWalk");
	}
	IEnumerator coAnimStayThree(){
		yield return new WaitForSeconds (0.55f/anim.speed);
		f_staytime = 3;
		anim.SetBool ("StateWalk", false);
		StartCoroutine ("ReStartWalk");
	}

	IEnumerator ActionObjMove(){
		yield return new WaitForSeconds (0.55f/anim.speed);
		StartCoroutine("ActionObjMove2");
	}

	IEnumerator ActionObjMove2(){
		anim.SetBool ("StateWalk", false);
		yield return new WaitForSeconds (1.0f/anim.speed);
		anim.SetBool ("StateWalk", true);
	}

	IEnumerator ActionSpeed(){
		yield return new WaitForSeconds (0.55f/anim.speed);
		StartCoroutine("ActionSpeed2");
	}

	IEnumerator ActionSpeed2(){
		anim.speed *= 2;
		yield return new WaitForSeconds (3.0f/(anim.speed/2));
		anim.speed /= 2;
	}

	IEnumerator ActionFad(){
		yield return new WaitForSeconds (0.55f/anim.speed);
		StartCoroutine("ActionFadeInOut");
	}

	IEnumerator ActionFadeInOut(){
		//Debug.Log ("은신1");
		StartCoroutine("ActionFadeOut");
		yield return new WaitForSeconds (2.0f/anim.speed);
		StartCoroutine("ActionFadeIn");
	}

	IEnumerator ActionFadeOut(){
		//Debug.Log ("은신2");
		BodyMat.transform.GetComponent<Renderer> ().sharedMaterial = Mat2;
		for(float i = 1f; i >= 0.3f; i -= 0.05f)
		{
			Color color = new Vector4(1,1,1, i);

			BodyMat.transform.GetComponent<Renderer> ().sharedMaterial.color = color;
			yield return 0;
		}
	}

	IEnumerator ActionFadeIn(){
		//Debug.Log ("은신3");
		for(float i = 0.3f; i <= 1; i += 0.05f)
		{
			Color color = new Vector4(1,1,1, i);
			BodyMat.transform.GetComponent<Renderer> ().sharedMaterial.color = color;
			yield return 0;
		}
		BodyMat.transform.GetComponent<Renderer> ().sharedMaterial = Mat1;
	}

	IEnumerator ActionPositionChange(){
		yield return new WaitForSeconds (0.55f/anim.speed);
		anim.SetBool ("StateWalk", false);
		f_staytime = 1;
		StartCoroutine("ActionPositionChangeFadeOutIn");
	}
	IEnumerator ActionPositionChangeFadeOutIn(){
		//
		StartCoroutine("ActionPositionChangeFadeOut");
		yield return new WaitForSeconds (0.55f/anim.speed);
		transform.position += Vector3.forward * 2.0f;

		StartCoroutine("ActionPositionChangeFadeIn");
	}

	IEnumerator ActionPositionChangeFadeOut(){
		BodyMat.transform.GetComponent<Renderer> ().sharedMaterial = Mat2;
		for(float i = 1f; i >= 0.3f; i -= 0.05f)
		{
			Color color = new Vector4(1,1,1, i);

			BodyMat.transform.GetComponent<Renderer> ().sharedMaterial.color = color;
			yield return 0;
		}
	}

	IEnumerator ActionPositionChangeFadeIn(){
		for(float i = 0.3f; i <= 1; i += 0.05f)
		{
			Color color = new Vector4(1,1,1, i);
			BodyMat.transform.GetComponent<Renderer> ().sharedMaterial.color = color;
			yield return 0;
		}
		BodyMat.transform.GetComponent<Renderer> ().sharedMaterial = Mat1;
		anim.SetBool ("StateWalk", true);
		f_staytime = 0;
	}

	IEnumerator ActionSound(){
		yield return new WaitForSeconds (0.55f/anim.speed);
		StartCoroutine("ActionSoundOnOff");
	}

	IEnumerator ActionSoundOnOff(){
		CharacterNoSound = true;
		yield return new WaitForSeconds (4.0f/anim.speed);
		CharacterNoSound = false;
	}

	IEnumerator ActiondummyInstall(){
		yield return new WaitForSeconds (0.55f/anim.speed);
		anim.SetBool ("StateWalk", false);
		f_staytime = 1;
		StartCoroutine("ActiondummyInstall2");
	}
	IEnumerator ActiondummyInstall2(){
		StartCoroutine("ActiondummyInstallIn");
		yield return new WaitForSeconds (1.0f/anim.speed);
		anim.SetBool ("StateWalk", true);
		f_staytime = 0;
	}

	IEnumerator ActiondummyInstallIn(){
		for(float i = 0.0f; i <= 1; i += 0.05f)
		{
			Color color = new Vector4(1,1,1, i);
			Dummy.transform.GetComponent<Renderer> ().sharedMaterial.color = color;
			yield return 0;
		}
		Destroy (Dummy, 4.0f);
	}

	IEnumerator ActionEMP(){
		yield return new WaitForSeconds (0.55f/anim.speed);
	}
	IEnumerator ActionWire(){
		yield return new WaitForSeconds (0.55f/anim.speed);
	}
}
