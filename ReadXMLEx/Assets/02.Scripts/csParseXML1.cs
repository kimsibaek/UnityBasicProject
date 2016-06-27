using UnityEngine;
using System.Collections;
using System.IO;
using System.Xml;
using System.Text;
using System;

public class csParseXML1 : MonoBehaviour {

	private static csParseXML1 instance;

	public static csParseXML1 Instance(){
		return instance;
	}

	public void Awake(){
		if (instance == null)
			instance = this;
	}
	// Use this for initialization
	void Start () {
		StartCoroutine (Process());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator Process(){
		string m_strName = "XmlData1.xml";
		string strPath = string.Empty;

		#if(UNITY_EDITOR || UNITY_STANDALONE_WIN)
		strPath += ("file:///");
		strPath += (Application.streamingAssetsPath + "/" + m_strName);
		#elif UNITY_ANDROID
		#endif

		WWW www = new WWW (strPath);

		yield return www;

		Interpret (www.text);
	}

	private void Interpret(string _strSource){
		StringReader stringReader = new StringReader (_strSource);

		XmlNodeList xmlNodeList = null;

		XmlDocument xmlDoc = new XmlDocument();

		xmlDoc.LoadXml (stringReader.ReadToEnd());

		xmlNodeList = xmlDoc.SelectNodes ("ROOT");

		foreach (XmlNode node in xmlNodeList) {
			if (node.Name.Equals ("ROOT") && node.HasChildNodes) {
				foreach(XmlNode child in node.ChildNodes){
					Debug.Log ("id : " + child.Attributes.GetNamedItem("id").Value);
					Debug.Log ("name : " + child.Attributes.GetNamedItem("name").Value);
					Debug.Log ("maxValue : " + child.Attributes.GetNamedItem("maxValue").Value);
					Debug.Log ("minValue : " + child.Attributes.GetNamedItem("minValue").Value);
				}

			}
		}
	}
}
