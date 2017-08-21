using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Movement : MonoBehaviour {


	Rigidbody2D rb2d;
	public Animator animator;
	public float speed_horizontal = 5.0f;
	private float height = 15.0f;
	// Use this for initialization
	void Start () {

		rb2d = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		Move ();

		Jump ();
	}

	void Move ()
	{
		float x = Input.GetAxis ("ARROW_HORIZONTAL");
		//float y = Input.GetAxis ("Vertical");
		animator.SetFloat ("speed", Mathf.Abs (x));
		gameObject.transform.Translate(new Vector2 (x * speed_horizontal*Time.deltaTime, 0));
		
		
	}

	void Jump()
	{
		if(Input.GetKeyDown("up")&&animator.GetBool("Ground"))
			rb2d.velocity= new Vector2(0, height);
	}


	void OnTriggerStay2D(Collider2D other)
	{
		if(other.tag=="Ground")
			animator.SetBool ("Grounded", true);

	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Ground") {
			animator.SetBool ("Grounded", false);
			animator.SetBool ("Crouch", false);
		}
	}

}
