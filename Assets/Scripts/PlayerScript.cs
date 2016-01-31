using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class PlayerScript : MonoBehaviour {
	
	public Vector2 speed = new Vector2(50,50);
	private Vector2 movement;


	void Start () {
//		GetComponent<Rigidbody2D> ().isKinematic = true;
//		GetComponent<Rigidbody> ().detectCollisions = true;
	}

	void Update () {
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");

		movement = new Vector2(
			speed.x * inputX,
			speed.y * inputY);

		if (Input.GetKeyDown ("z")) {
			if (Camera.main.orthographicSize == 20) {
				Camera.main.orthographicSize = 8;
			} else {
				Camera.main.orthographicSize = 20;
			}
		}
		var controls = GameObject.Find ("controls_screen").GetComponent<Image> ();
		if (Input.GetKeyDown ("i")) {
			controls.enabled = true;
		}
		if (controls.enabled && Input.GetKeyDown ("n")) {
			controls.enabled = false;
		}
	}

	void FixedUpdate() {
		GetComponent<Rigidbody2D>().velocity = movement;
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "warthog") {
			var task_manager = GameObject.Find ("top-left ui").GetComponent<TaskManager> ();
			task_manager.gameOver ();
		}
	}

}
