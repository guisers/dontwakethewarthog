using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class PlayerScript : MonoBehaviour {
	
	public Vector2 speed = new Vector2(50,50);
	private List<PlayerAction> actions = new List<PlayerAction> (); 
	private GameObject collided;
	private Vector2 movement;
	private float distanceFromWarthog;


	void Start () {

	}

	void Update () {
		distanceFromWarthog = Vector3.Distance (transform.position, GameObject.Find ("warthog").transform.position);

		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");

		movement = new Vector2(
			speed.x * inputX,
			speed.y * inputY);

		foreach (PlayerAction action in actions) {
			if (action.id == "hold") {
				if (Input.GetKey (action.key)) {
					collided.transform.position = transform.Find ("holdslot").transform.position;
				}
			} else {
				if (Input.GetKeyDown(action.key)) {
					double add_noise = action.noise;
					double distanceFactor = Convert.ToDouble (distanceFromWarthog) / 60;
					add_noise *= 1 - distanceFactor;
					GameObject.Find ("warthog").GetComponent<SleepScript> ().incNoise (add_noise);
					action.keys_to_finish--;
					if (action.keys_to_finish <= 0) {
						GameObject.Find ("task panel").GetComponent<TaskManager> ().finishTask ();
						resetActions ();
					}
				}
			}

		}


	}

	void FixedUpdate() {
		GetComponent<Rigidbody2D>().velocity = movement;
	}

	public void resetActions() {
		actions = new List<PlayerAction> ();
	}
	public void setActions(List<PlayerAction> new_actions) {
		actions = new_actions;
	}
	public void setCollided(GameObject obj) {
		collided = obj;
	}

}
