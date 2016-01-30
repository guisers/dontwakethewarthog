using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ObjectScript : MonoBehaviour {

	public string type;
	public bool holdable = false;
	private List<PlayerAction> actions = new List<PlayerAction>();

	// Use this for initialization
	void Start () {
		if (holdable) {
			gameObject.AddComponent<PlayerAction> ().setValues("hold", "h", -1, -1, "Hold h to pick up");
		}
		actions = GetComponents<PlayerAction> ().ToList<PlayerAction> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "player") {
			coll.gameObject.GetComponent<PlayerScript> ().setActions (actions);
			coll.gameObject.GetComponent<PlayerScript> ().setCollided (this.gameObject);
//			foreach (PlayerAction action in actions) {
//				gameObject.AddComponent<Text> ().text = action.instruction;
//			}

		}


	}
	void OnCollisionExit2D(Collision2D coll) {
		if (coll.gameObject.tag == "player") {
			coll.gameObject.GetComponent<PlayerScript> ().resetActions ();
		}
	}

}
