using UnityEngine;
using System;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerAction : MonoBehaviour {

	public string id;
	public string key;
	public double noise;
	public int keys_to_finish;
	public string instruction;
	public List<string> requirements;
//	public Dictionary<string,string> details;

	private bool active;

	public void setValues(string new_id, string new_key, double new_noise, int new_keys_to_finish, string new_ins, List<string> new_req) {
		id = new_id;
		key = new_key;
		noise = new_noise;
		keys_to_finish = new_keys_to_finish;
		instruction = new_ins;
		requirements = new_req;
	}

	void Start () {
		setActive(false);
	}
		
	void Update () {
		if (!active)
			return;

		if (!gameObject.GetComponent<SpriteRenderer> ().enabled) {
			setActive(false);
			return;
		}
		
		if (id == "hold") {
			if (Input.GetKey (key)) {
				var player = GameObject.FindGameObjectWithTag ("player");
				gameObject.transform.position = player.transform.Find ("holdslot").transform.position; 
			}
			return;
		}

		if (requirements.Count > 0) {
			var valid = true;
			foreach (var req in requirements) {
				if (!GetComponent<Collider2D> ().IsTouching (GameObject.Find (req).GetComponent<Collider2D> ()))
					valid = false;
			}
			if (!valid)
				return;
		}

		if (Input.GetKeyDown (key)) {
			addNoise ();
			keys_to_finish--;
			if (keys_to_finish <= 0) {
//				if (details.ContainsKey("finish_image_switch")) {
//					switchImage (details.TryGetValue("finish_image_switch"));
//				}
				var taskManager = GameObject.Find ("top-left ui").GetComponent<TaskManager> ();
				taskManager.nextStage ();
			}
		}
	}

//	private void switchImage(string name) {
//		gameObject.GetComponent<SpriteRenderer>().sprite = 
//	}

	private void addNoise() {
		double add_noise = noise;
		float distanceFromWarthog = Vector3.Distance (transform.position, GameObject.Find ("warthog").transform.position);
		double distanceFactor = Convert.ToDouble (distanceFromWarthog) / 60;
		add_noise *= 1 - distanceFactor;
		GameObject.Find ("warthog").GetComponent<SleepScript> ().incNoise (add_noise);
	}

	public void setActive(bool activeness) {
		active = activeness;
		var item_helper = GameObject.Find ("item helper");
		var textComponent = GameObject.Find ("item helper text").GetComponent<Text> ();
		if (active) {
			item_helper.GetComponent<Image> ().enabled = true;
			textComponent.text = textComponent.text.Insert(0, instruction+Environment.NewLine);
//			item_helper.transform.position = GameObject.Find ("Camera").GetComponent<Camera> ().WorldToScreenPoint (gameObject.transform.position);
		} else {
			item_helper.GetComponent<Image> ().enabled = false;
			textComponent.text = "";
		}
	}
	public bool getActive() {
		return active;
	}

}
