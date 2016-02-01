using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class RandomMovement : MonoBehaviour {

	public Vector2 speed = new Vector2(50,50);
	private Vector2 movement;
	private float inputX;
	private float inputY;
	private int counter;
	private bool active;

	void Start () {
		counter = 0;
		active = false;
		generateRandoms ();
	}

	void Update () {
//		if (active) {
//			
//		}
	}

	private void generateRandoms() {
		inputX = UnityEngine.Random.value * 2 - 1;
		inputY = UnityEngine.Random.value * 2 - 1;
	}

	void FixedUpdate() {
//		active = GetComponent<SpriteRenderer> ().enabled && 
//			!GetComponent<Collider2D> ().IsTouching(GameObject.FindGameObjectWithTag("player").GetComponent<Collider2D> ());
		active = GetComponent<SpriteRenderer> ().enabled && !Input.GetKeyDown ("f");
		if (active){
			counter++;
			if (counter % 300 == 0) {
				generateRandoms ();
//				GameObject.Find ("warthog").GetComponent<SleepScript> ().incNoise (2);
//				if (!gameObject.GetComponent<AudioSource> ().isPlaying) {
//					gameObject.GetComponent<AudioSource> ().Play ();
//				}
			} else if (counter % 100 == 0) {
				GameObject.Find ("warthog").GetComponent<SleepScript> ().incNoise (2);
				if (!gameObject.GetComponent<AudioSource> ().isPlaying) {
					gameObject.GetComponent<AudioSource> ().Play ();
				}
			}

			movement = new Vector2 (
				speed.x * inputX,
				speed.y * inputY);
			GetComponent<Rigidbody2D> ().velocity = movement;
		}
	}

//	void OnCollisionStay2D(Collision2D coll) {
//		if (coll.gameObject.tag == "player") {
//			if (Input.GetKey ("f")) {
//				Debug.Log ("ENTER player");
//				active = false;
//			}
//		} else {
//			generateRandoms ();
//		}
//	}
	void OnCollisionEnter2D(Collision2D coll) {
		if (active && coll.gameObject.tag != "player") {
			generateRandoms ();
		}
	}

	void OnCollisionStay2D(Collision2D coll) {
//		if (coll.gameObject.tag == "player") {
//			if (Input.GetKeyDown ("f")) {
//				active = false;
//			}
//		} else {
//			generateRandoms ();
//		}
	}
	void OnCollisionExit2D(Collision2D coll) {
//		if (coll.gameObject.tag == "player") {
//			if (!Input.GetKey ("f")) {
//				Debug.Log ("LEAVE player");
////				active = true;
//			}
//		}
	}

}
