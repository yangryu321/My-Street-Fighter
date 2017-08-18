using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelected : MonoBehaviour {

	public GameObject Characters;

	// Use this for initialization
	void Start () {

		for (int i = 0; i < Characters.transform.childCount; i++) {
			Characters.transform.GetChild (i).gameObject.SetActive (false);
		}

		int index = PlayerPrefs.GetInt ("INDEX");
		Characters.transform.GetChild (index).gameObject.SetActive (true);
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
