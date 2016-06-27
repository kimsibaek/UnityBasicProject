using UnityEngine;
using System.Collections;
using System.IO;
using System.Xml;
using System.Text;
using System;

public class csParseXML2 : MonoBehaviour {
	private static csParseXML2 instance;

	public static csParseXML2 Instance(){
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
		string m_strName = "XmlData2.xml";
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

		//XmlNodeList xmlNodeList = null;

		XmlDocument xmlDoc = new XmlDocument();

		xmlDoc.LoadXml (stringReader.ReadToEnd());

		//xmlNodeList = xmlDoc.SelectNodes ("ROOT");

		ProcessBooks (xmlDoc.SelectNodes("books/book"));

	}

	private void ProcessBooks(XmlNodeList nodes){
		foreach (XmlNode node in nodes) {
			
				
			Debug.Log (Convert.ToInt16(node.Attributes.GetNamedItem("id").Value));
			Debug.Log (node.SelectSingleNode("title").InnerText);
			Debug.Log (node.SelectSingleNode("image").InnerText);
			Debug.Log (node.SelectSingleNode("description").InnerText);
				
			foreach (XmlNode author in node.SelectNodes("authors/author")) {
				Debug.Log (author.InnerText);
			}

		}
	}
}
