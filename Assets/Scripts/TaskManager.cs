using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class TaskManager : MonoBehaviour {

	private GameObject title;
	private GameObject description;
	private bool gameEnded;

	private int stage;

	void Start () {
		stage = GameObject.Find ("game settings").GetComponent<GameSettings> ().getStage ();
		gameEnded = false;
		title = GameObject.Find ("task title");
		description = GameObject.Find ("task description");
		setStage ();
	}

	void Update () {
		if (Input.GetKeyDown ("t")) {
			if (title.GetComponent<Text> ().enabled) {
				setTaskVisibility (false);
			} else {
				setTaskVisibility (true);
			}
		}
		if (stage ==0) {
			if (Input.GetKeyDown ("n")) {
				var start_screen = GameObject.Find ("start_screen").GetComponent<Image> ();
				start_screen.enabled = false;
				stage++;
				setStage ();
			}
		} else if (gameEnded) {
			if (Input.GetKeyDown ("n")) {
				var game_over = GameObject.Find ("game_over").GetComponent<Image> ();
				game_over.enabled = false;
				gameEnded = false;
				Application.LoadLevel("1");
			}
		}
	}

	public void setTaskVisibility(bool visible) {
//		GameObject.Find ("top-left ui").GetComponent<Image> ().enabled = visible;
		title.GetComponent<Text> ().enabled = visible;
		description.GetComponent<Text> ().enabled = visible;
		GameObject.Find ("frame").GetComponent<Image> ().enabled = visible;
	}

	public void nextStage() {
		stage++;
		setStage ();
	}

	public void gameOver() {
		var game_over = GameObject.Find ("game_over").GetComponent<Image> ();
		game_over.enabled = true;
		gameEnded = true;
	}

//	public void getStage() {
//		return stage;
//	}
	public void setStage() {
		GameObject.Find ("game settings").GetComponent<GameSettings> ().setStage (stage);
		List<string> enableItemIds = new List<string> ();
		List<string> disableItemIds = new List<string> ();
		switch (stage) {
		case 0:
			var start_screen = GameObject.Find ("start_screen").GetComponent<Image> ();
			start_screen.enabled = true;
			break;
		case 1:
			title.GetComponent<Text> ().text = "eat the chips";
			description.GetComponent<Text> ().text = "press z to zoom"+Environment.NewLine+"press t to close this box";
			enableItemIds.Add ("chips");
			break;
		case 2:
			title.GetComponent<Text> ().text = "build a birdhouse";
			description.GetComponent<Text> ().text = "press z to zoom"+Environment.NewLine+"press t to close this box";
			disableItemIds.Add ("chips");
			enableItemIds.Add ("wood");
			enableItemIds.Add ("hammer");
			break;
		case 3:
			title.GetComponent<Text> ().text = "make a smoothie";
			description.GetComponent<Text> ().text = "press z to zoom"+Environment.NewLine+"press t to close this box";
			enableItemIds.Add ("birdhouse");
			disableItemIds.Add ("wood");
			GameObject.Find ("birdhouse").GetComponent<stickyUntilAppear> ().setActive (false);
			break;
		default:
			break;
		}

		foreach (string id in enableItemIds) {
			GameObject item = GameObject.Find (id);
			item.GetComponent<SpriteRenderer> ().enabled = true;
			item.GetComponent<Collider2D> ().enabled = true;
		}
		foreach (string id in disableItemIds) {
			GameObject item = GameObject.Find (id);
			item.GetComponent<SpriteRenderer> ().enabled = false;
			item.GetComponent<Collider2D> ().enabled = false;
		}

		GameObject.Find ("warthog").GetComponent<SleepScript> ().resetNoise ();
		setTaskVisibility (true);
		gameEnded = false;
	}
}
