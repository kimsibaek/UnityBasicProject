using UnityEngine;
using System.Collections;
using UnityEngine.UI;

#if UNITY_ADS
using UnityEngine.Advertisements;
#endif

public class UnityAdsExample : MonoBehaviour {
	GameObject obj;
	Text txt;

	// Use this for initialization
	void Start () {
		obj = GameObject.Find ("txtDebug");
		txt = obj.GetComponent <Text>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ShowDefaultAd()
	{
		#if UNITY_ADS
		if(Advertisement.IsReady()){
			Advertisement.Show();
		}
		#endif
	}

	public void ShowRewardedAd(){
		if (Advertisement.IsReady ()) {
			ShowOptions options = new ShowOptions ();
			options.resultCallback = HandleShowResult;
			Advertisement.Show (null, options);
		}
	}

	private void HandleShowResult(ShowResult result)
	{
		switch (result)
		{
		case ShowResult.Finished:
			Debug.Log("The ad was successfully shown.");
			txt.text = "The ad was successfully shown.";
			//
			// YOUR CODE TO REWARD THE GAMER
			// Give coins etc.
			break;
		case ShowResult.Skipped:
			Debug.Log("The ad was skipped before reaching the end.");
			txt.text = "The ad was skipped before reaching the end.";
			break;
		case ShowResult.Failed:
			Debug.LogError("The ad failed to be shown.");
			txt.text = "The ad failed to be shown.";
			break;
		}
	}
}
	