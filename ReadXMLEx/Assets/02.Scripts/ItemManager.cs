using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ItemManager : MonoBehaviour {
	private static ItemManager _instance = null;
	public static ItemManager Instance (){
		return _instance;
	}

	void Awake(){
		if (ItemManager._instance == null) {
			ItemManager._instance = this;
		}
	}

	Dictionary<int, ItemInfo> m_dicData = new Dictionary<int, ItemInfo>();

	public void AddItem (ItemInfo _cInfo){
		if (m_dicData.ContainsKey (_cInfo.ID))
			return;

		m_dicData.Add (_cInfo.ID, _cInfo);
	}

	public ItemInfo GetItem (int _nID){
		if (m_dicData.ContainsKey (_nID))
			return m_dicData [_nID];

		return null;
	}

	public Dictionary<int, ItemInfo> GetAllItems(){
		return m_dicData;
	}

	public int GetItemsCount(){
		return m_dicData.Count;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

public class ItemInfo
{
	private int m_nID;
	private string m_strName;
	private string m_strIcon;
	private int m_nBuyCost;
	private int m_nSellCost;

	public int ID{
		set { m_nID = value; }
		get { return m_nID; }
	}

	public string NAME{
		set { m_strName = value; }
		get { return m_strName; }
	}

	public string ICON{
		set { m_strIcon = value; }
		get { return m_strIcon; }
	}

	public int BUY_COST{
		set { m_nBuyCost = value; }
		get { return m_nBuyCost; }
	}

	public int SELL_COST{
		set { m_nSellCost = value; }
		get { return m_nSellCost; }
	}
}