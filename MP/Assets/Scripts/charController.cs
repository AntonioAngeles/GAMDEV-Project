using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charController : MonoBehaviour {

	public float speed = 10.0F;

	// Use this for initialization
	void Start () {
		Cursor.lockState = CursorLockMode.Locked;
		
	}
	
	// Update is called once per frame
	void Update () {

		//float translation = Input.GetAxis ("Vertical") * speed;
		//float straffe = Input.GetAxis ("Horizontal") * speed;

		float translation = Input.GetAxis ("Horizontal") * speed;
		float straffe = Input.GetAxis ("Vertical") * speed;

		translation *= Time.deltaTime;
		straffe *= Time.deltaTime;

		transform.Translate (straffe, 0, translation);

		if (Input.GetKeyDown ("escape"))
			Cursor.lockState = CursorLockMode.None;
	}

//	void OnCollisionEnter (Collision collision) {
//		Debug.Log ("Enter..");
//
//	}
//
//	void OnCollisionStay(Collision collision) {
//		Debug.Log ("Stay..");
//
//	}
//
//	void OnCollisionExit(Collision collision) {
//		Debug.Log ("Exit..");
//
//	}

}
