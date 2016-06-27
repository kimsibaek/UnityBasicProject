using UnityEngine;
using System.Collections;
using System.IO;
using System.Xml;
using System.Text;
using System;

public class ItemParse : MonoBehaviour {
	string m_strName = "XmlData3.xml";
	// Use this for initialization
	void Start () {
		StartCoroutine (Process());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator Process(){
		//string m_strName = "XmlData1.xml";
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

		try{
			xmlDoc.LoadXml (stringReader.ReadToEnd());
		}
		catch(Exception e){
			xmlDoc.LoadXml (_strSource);
		}


		xmlNodeList = xmlDoc.SelectNodes ("Items");

		foreach (XmlNode node in xmlNodeList) {
			if (node.Name.Equals ("Items") && node.HasChildNodes) {
				foreach(XmlNode child in node.ChildNodes){
					ItemInfo item = new ItemInfo();

					item.ID = int.Parse(child.Attributes.GetNamedItem("id").Value);
					item.NAME = child.Attributes.GetNamedItem("name").Value;
					item.ICON = child.Attributes.GetNamedItem("icon").Value;
					item.BUY_COST = int.Parse(child.Attributes.GetNamedItem("buy_cost").Value);
					item.SELL_COST = int.Parse(child.Attributes.GetNamedItem("sell_cost").Value);

					ItemManager.Instance().AddItem(item);

					Debug.Log (" ID : " + item.ID + " NAME : " + item.NAME + " ICON : " + item.ICON + " BUY_COST : " + item.BUY_COST + " SELL_COST : " + item.SELL_COST);

				}

			}
		}
	}
}
