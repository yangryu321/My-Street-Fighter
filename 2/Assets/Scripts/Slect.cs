using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slect : MonoBehaviour {
	
	public GameObject CharList;
	private int index;
	private GameObject[] List;
	// Use this for initialization
	void Start () {
		List = new GameObject[CharList.transform.childCount];

		for (int i = 0; i < CharList.transform.childCount; i++) {
			List [i] = CharList.transform.GetChild (i).gameObject;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		index = PlayerPrefs.GetInt ("INDEX");
		print (index);
		float x=List [index].transform.position.x;
		transform.position = new Vector2 (x, transform.position.y); //works well
		
	}



}
