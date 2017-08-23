using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {


	public GameObject PlayRoundfight;
	private bool isDone=false;
	// Use this for initialization
	void Start () 
	{
		StartCoroutine(PlayRoundFight ());
		print ("WORK333");
		PlayRoundfight.SetActive (false);
	}


	void Update()
	{
		
		if (isDone)
			Time.timeScale = 1;
	}


	IEnumerator PlayRoundFight()
	{

		Time.timeScale = 0;
		yield return new WaitForSecondsRealtime (1.0f);
		PlayRoundfight.SetActive (true);
		//yield return StartCoroutine(CoroutineUtilities.WaitForRealTime(3.0f));
		yield return new WaitForSecondsRealtime (3.5f);
		PlayRoundfight.SetActive (false);
		isDone=true;
		print ("WORK");

	}



	/*
	public static class CoroutineUtilities {                  //this class works independent of Time.scaletime; 
		public static IEnumerator WaitForRealTime(float delay){
			while(true){
				float pauseEndTime = Time.realtimeSinceStartup + delay;
				while (Time.realtimeSinceStartup < pauseEndTime){
					yield return 0;
				}
				break;
			}
		}
	}

*/

}
