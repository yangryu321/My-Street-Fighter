﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed_horizontal = 5.0f;
	public float speed_vertical=50.0f;

	private bool grounded=true;

	private Rigidbody2D rb2d;
	private Animator animator;


	//public GameObject ObjectRuler;
	public float CanJumpheight;
	public float hopHeight = 10.0f;
	private bool hopping = false;
	public GameObject Sonicboom;
	public bool ShootNext=true;
	private bool CanWalk=true;
	private bool CanJump=true;

	void Start()
	{
		rb2d = gameObject.GetComponent<Rigidbody2D>();
		animator = gameObject.GetComponent<Animator> ();

	}


	void FixedUpdate()
	{

		if (animator.GetBool ("Grounded")) 
		{
			Move ();
			JumpAction ();

			AttackAction ();

		}
	
	}

	void Move()
	{
		float x = Input.GetAxis ("Horizontal");
		animator.SetFloat ("speed", Mathf.Abs (x));
		//float y = Input.GetAxis ("Vertical");
		float y=0;


		if (Input.GetKey("s") && animator.GetBool ("Grounded")) { //if [W] is pressed and is grounded
			animator.SetBool ("Crouch", true); //Crounch
			x = 0;

		} else {
			animator.SetBool ("Crouch", false);

		}

		if (!animator.GetBool ("Grounded")) {
			//x = 0;
		}

	
		if(CanWalk)
			//rb2d.velocity = new Vector2 (x * speed_horizontal, 0);
			transform.Translate(new Vector2 (x * speed_horizontal*Time.deltaTime, 0));


	}
		


	void JumpAction()
	{
		if(CanJump)
		{
			/*
			if (Input.GetKeyDown ("w") && Input.GetKey ("a") && Input.GetKey ("d")) {
				Jumpforward ();
				animator.SetBool ("Grounded", false);
				
			}
				
			else */
			if (Input.GetButton ("d") && Input.GetButtonDown ("w")) {
				Jumpforward ();
				animator.SetBool ("Grounded", false);
				ShootNext = false;
			}
			else if (Input.GetButton ("a") && Input.GetButtonDown ("w") ) {
				Jumpbackward();
				animator.SetBool ("Grounded", false);
				ShootNext = false;
			}
			else if (Input.GetButtonDown ("Jump")) {

				Jump (); //jump straight;
				animator.SetBool ("Grounded", false);
				ShootNext = false;
			} 
			
		}
			

	}


	void Jump()
	{
	//	animator.SetBool("JumpStraight",true);
		animator.SetBool("JumpForwad",false);
		Vector2 pos = new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y+3);
		StartCoroutine(Hop(pos, 0.5f));
		//rb2d.velocity = new Vector2 (0, 15);


	}

	void Jumpforward()//forward
	{
		animator.SetBool("JumpForwad",true);
		//animator.SetBool("JumpStraight",false);
		Vector2 pos = new Vector2 (gameObject.transform.position.x+2, gameObject.transform.position.y+3);
		StartCoroutine(Hop(pos, 1.0f));

		//rb2d.velocity = new Vector2 (5, 15);


	}

	void Jumpbackward() //backward
	{
		Vector2 pos = new Vector2 (gameObject.transform.position.x-2, gameObject.transform.position.y+3);
		StartCoroutine(Hop(pos, 1.0f));
	}



	/*
	IEnumerator CheckShoot()
	{
		if (ShootNext == false) {
			yield return new WaitForSeconds (2.0f);
			ShootNext = true;
		}
	}
*/


	void AttackAction ()
	{

		if (ShootNext && Input.GetKeyDown ("j") && Input.GetKey ("a") && Input.GetKey ("d")&&animator.GetBool ("Grounded")) {
			ShootNext = false;
			SonicBoom ();
			print (ShootNext);
			//	
		} else if (Input.GetKeyDown ("j"))
			StartCoroutine(Jab ());

	}


	void SonicBoom()
	{
		

			StartCoroutine (TriggerSonic ());
			StartCoroutine (Shoot ());
	}

	void SonicBoomStart()
	{
		animator.SetBool ("SonicBooM", true);

	}

	void SonicBoomOver()
	{
		animator.SetBool ("SonicBooM", false);
	}



	IEnumerator Jab()
	{


		CanWalk = false;
		animator.SetBool ("CanWalk", false);
		animator.SetBool ("CanJump", false);
		animator.SetBool ("Jab", true);
		yield return new WaitForSeconds (0.3f);
		animator.SetBool ("Jab", false);


		yield return new WaitForSeconds (0.3f);
		CanWalk = true;
		animator.SetBool ("CanWalk", true);
		animator.SetBool ("CanJump", true);



	}


	IEnumerator TriggerSonic()
	{
		CanJump = false;
		SonicBoomStart ();
		yield return new WaitForSeconds (0.05f);
		SonicBoomOver ();
		//CanJump = true;
	}
		


	IEnumerator Hop(Vector3 dest, float time) {
		if (hopping) 
			yield break;

		hopping = true;
		var startPos = transform.position;
		var timer = 0.0f;

		while (timer <= 1.0f) {
			var height = Mathf.Sin(Mathf.PI * timer) * hopHeight;
			transform.position = Vector3.Lerp(startPos, dest, timer) + Vector3.up * height; 

			timer += Time.deltaTime / time;
			yield return null;
		}
		hopping = false;
	}


	void OnTriggerStay2D(Collider2D other)
	{
		if (other.tag == "Ground") {
			animator.SetBool ("Grounded", true);
			animator.SetBool("JumpForwad",false);
			animator.SetBool("JumpStraight",false);
			animator.SetBool("IsInAir",false);
		}



	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Ground") {
			animator.SetBool ("Grounded", false);
			animator.SetBool ("Crouch", false);
			animator.SetBool("IsInAir",true);
			ShootNext = true;
		}
	}


	IEnumerator Shoot()
	{
		yield return new WaitForSeconds (0.3f);
		GameObject gameObjectt;
		CanJump = true;

		gameObjectt = Instantiate (Sonicboom, new Vector3 (transform.position.x + 1.9f, transform.position.y + 0.5f), Quaternion.identity);
		yield return new WaitForSeconds (1.0f);
		ShootNext = true;
		DestroyObject (gameObjectt);
		//ShootNext = true;

	}

}
