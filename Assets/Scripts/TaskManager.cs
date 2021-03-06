﻿using UnityEngine;
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

	private List<AudioSource> narrations;

	void Start () {
		stage = GameObject.Find ("game settings").GetComponent<GameSettings> ().getStage ();
		narrations =  GetComponents<AudioSource> ().ToList();
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
				nextStage ();
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
		narrations [stage].Stop ();
		stage++;
		GameObject.Find ("game settings").GetComponent<GameSettings> ().setStage (stage);
		setStage ();
	}

	public void gameOver() {
		narrations [stage].Stop ();
		var warthog_sounds = GameObject.Find ("warthog").GetComponents<AudioSource> ().ToList ();
		warthog_sounds[0].Stop ();
		if (!warthog_sounds [1].isPlaying) {
			warthog_sounds [1].Play ();
		}
		var game_over = GameObject.Find ("game_over").GetComponent<Image> ();
		game_over.enabled = true;
		gameEnded = true;
	}

//	public void getStage() {
//		return stage;
//	}
	public void setStage() {
		List<string> enableItemIds = new List<string> ();
		List<string> disableItemIds = new List<string> ();
		if (stage < narrations.Count) {
			narrations[stage].Play ();
		}
		var warthog_sounds = GameObject.Find ("warthog").GetComponents<AudioSource> ().ToList ();
		if (!warthog_sounds[0].isPlaying) {
			warthog_sounds[0].Play ();
		}
		switch (stage) {
		case 0:
			var start_screen = GameObject.Find ("start_screen").GetComponent<Image> ();
			start_screen.enabled = true;
			break;
		case 1:
			title.GetComponent<Text> ().text = "eat the chips";
			description.GetComponent<Text> ().text = "press i for instructions" + Environment.NewLine + "press t to close this box";
			enableItemIds.Add ("chips");
			break;
		case 2:
			title.GetComponent<Text> ().text = "build a birdhouse";
			description.GetComponent<Text> ().text = "press i for instructions"+Environment.NewLine+"press t to close this box";
			disableItemIds.Add ("chips");
			enableItemIds.Add ("wood");
			enableItemIds.Add ("hammer");
			break;
		case 3:
			title.GetComponent<Text> ().text = "shit, birds singing";
			description.GetComponent<Text> ().text = "press i for instructions"+Environment.NewLine+"press t to close this box";
			enableItemIds.Add ("birdhouse");
			disableItemIds.Add ("wood");
			disableItemIds.Add ("hammer");
			GameObject.Find ("birdhouse").GetComponent<stickyUntilAppear> ().setActive (false);
			enableItemIds.Add ("bird");
//			enableItemIds.Add ("bird (1)");
//			enableItemIds.Add ("bird (2)");
			break;
		case 4:
			title.GetComponent<Text> ().text = "you're done the game";
			description.GetComponent<Text> ().text = "more levels to come soon!";
			disableItemIds.Add ("bird");
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
