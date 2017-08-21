using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLevel : MonoBehaviour {


	public GameObject Loadingscreen;
	public Slider slider;
	public void LevelLoader(int index)
	{
		StartCoroutine (AnimationProgress(index));

		slider.value = 0.0f;
	}



	IEnumerator LoadAsynchronously(int index)
	{
		AsyncOperation operation = SceneManager.LoadSceneAsync (index);


		while (!operation.isDone)
		{
			float progress = Mathf.Clamp01 (operation.progress / .9f);
			slider.value = progress/10;
			yield return null; //return after a frame time
	
		}


	}

	IEnumerator AnimationProgress(int index)
	{	
		Loadingscreen.SetActive (true);
		yield return new WaitForSeconds (2);
		StartCoroutine (LoadAsynchronously (index));
	
	}



}
