using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player1_Selection : MonoBehaviour {

	private GameObject[] character;
	private int index;
	private bool canPressNext=true;
	// Update is called once per frame

	void Start()
	{
		index = 0;
		PlayerPrefs.SetInt("INDEX",index);
	}

	void Update () {
		if (canPressNext && Input.GetKey ("a")) {
			canPressNext = false;
			SelectLeft ();
		}
		else if(canPressNext && Input.GetKey ("d")) {
			canPressNext = false;
			SelectRight ();
		}


		if (Input.GetKey ("j")) 
		{
			SceneManager.LoadScene (1);
			
		}


	}

	void SelectLeft ()
	{
		transform.GetChild (index).gameObject.SetActive(false);
		index--;
		canPressNext = false;
		if (index < 0)
			index = 1;
		
		
		transform.GetChild (index).gameObject.SetActive(true);
		PlayerPrefs.SetInt("INDEX",index);
		StartCoroutine (NextPress());


	}

	void SelectRight ()
	{

		transform.GetChild (index).gameObject.SetActive(false);
		index++;
		canPressNext = false;
		if (index > 1)
			index = 0;

		transform.GetChild (index).gameObject.SetActive(true);
		PlayerPrefs.SetInt("INDEX",index);
		StartCoroutine (NextPress());

	}

	IEnumerator NextPress()
	{
		yield return new WaitForSeconds (0.3f);
		canPressNext = true;
		
	}


}
