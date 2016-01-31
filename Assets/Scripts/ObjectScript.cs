using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ObjectScript : MonoBehaviour {

	public string type;
	public bool holdable = false;
	private List<PlayerAction> actions = new List<PlayerAction>();

	void Start () {
		if (holdable) {
			gameObject.AddComponent<PlayerAction> ().setValues("hold", "f", -1, -1, "Hold f to pick up", new List<string> ());
		}
		actions = GetComponents<PlayerAction> ().ToList<PlayerAction> ();
	}

	void Update () {
		
	}


	void OnCollisionStay2D(Collision2D coll) {
		if (coll.gameObject.tag == "player") {
			foreach (var action in gameObject.GetComponents<PlayerAction> ()) {
				action.setActive (true);
			}
		}
	}

	void OnCollisionExit2D(Collision2D coll) {
		if (coll.gameObject.tag == "player") {
			foreach (var action in gameObject.GetComponents<PlayerAction> ()) {
				action.setActive (false);
			} 
		}
	}

}
