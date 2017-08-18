using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Movement : MonoBehaviour {


	public Rigidbody2D rb2d;
	public Animator animator;
	public float speed_horizontal = 5.0f;
	// Use this for initialization
	void Start () {

		rb2d = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		Move ();


	}

	void Move ()
	{
		float x = Input.GetAxis ("ARROW_HORIZONTAL");
		//float y = Input.GetAxis ("Vertical");
		animator.SetFloat ("speed", Mathf.Abs (x));
		gameObject.transform.Translate(new Vector2 (x * speed_horizontal*Time.deltaTime, 0));
		
		
	}



}
