using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class damageBox : MonoBehaviour {

	private static float health=100;// Character has 100 health;
	public Scrollbar scrollbar;

	void Start()
	{
		scrollbar.size = 0;
	}
	void OnTriggerEnter2D(Collider2D collier)
	{
		if (collier.tag == "Guile_Fist" && GetComponent<Collider2D> ().tag == "Ryu_Head") {
			print ("Head hit  by Guile Fist");
			health -= 10;
			scrollbar.size += 10f / 100f;
		} else if (collier.tag == "Guile_Fist" && GetComponent<Collider2D> ().tag == "Ryu_Body") {
			print ("Body hit  by Guile Fist");

		} else if (collier.tag == "SonicBoom" && GetComponent<Collider2D> ().tag == "Ryu_Body") {
			print ("Body hit  by Sonic_boom");
			health -= 15;
			scrollbar.size +=15f/100f ;
		}
		else if(collier.tag == "SonicBoom"&&GetComponent<Collider2D>().tag=="Ryu_Head")
			print ("Body hit  by Sonic_boom");

		print("HEALTH: "+ health);
	}





}
