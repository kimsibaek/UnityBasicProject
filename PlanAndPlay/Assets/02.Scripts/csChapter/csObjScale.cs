using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class csObjScale : MonoBehaviour {
	//Content Settings-------------------------------------------------------------------------------------------
	public List<GameObject> LevelThumbnails;
	//Slides Settings--------------------------------------------------------------------------------------------
	public float Transition_In;
	public float Transition_Out;

	//ScrollBar Settings-----------------------------------------------------------------------------------------
	public Scrollbar HorizontalScrollBar;

	//Slides Settings--------------------------------------------------------------------------------------------
	public string SlidesNamePrefix="Button 0";
	public float Element_Width;
	public float Element_Height;
	public float Element_Scale;

	//Other Variables--------------------------------------------------------------------------------------------
	private float n;
	private float ScrollSteps;
	// Use this for initialization
	void Start () {
		for (int b=0; b<LevelThumbnails.Count; b++) {
			LevelThumbnails[b].GetComponent<RectTransform>().sizeDelta=new Vector2(Element_Width,Element_Height);
			//LevelThumbnails[b].GetComponent<RectTransform>().localPosition=new Vector3((2*b+3)*Element_Width/2+(2*b+3)*Element_Margin,0,10);
		}

		n = LevelThumbnails.Count - 1;
		ScrollSteps = 1 / n;
	}
	
	// Update is called once per frame
	void Update () {
	
		for (int s=0; s<LevelThumbnails.Count; s++) {
			for (int t=0; t<LevelThumbnails.Count; t++) {
				if (HorizontalScrollBar.GetComponent<Scrollbar> ().value > (ScrollSteps / 2) + (s - 1) * (ScrollSteps) && 
					HorizontalScrollBar.GetComponent<Scrollbar> ().value <= Mathf.Clamp (ScrollSteps / 2 + s * ScrollSteps, 0, 1)) {
					if(t!=s){
						LevelThumbnails [t].transform.localScale = Vector2.Lerp (LevelThumbnails [t].transform.localScale, new Vector2 (1, 1), Transition_Out);
					}
					if(t==s){
						//In Pro Version Change Color Of Active Slide
						LevelThumbnails [s].transform.localScale = Vector2.Lerp (LevelThumbnails [s].transform.localScale, new Vector2 (Element_Scale, Element_Scale), Transition_In);
						//LevelThumbnails [s].gameObject.transform.SetAsLastSibling();
					}

				}
			}
		}
	}
}
