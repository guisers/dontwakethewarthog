using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Linq;

public class SleepScript : MonoBehaviour {
	
	private double sleep;
	private double counter;
	private double noise;
	private GameObject noise_bar;
	private GameObject sleep_bar;

	void Start () {
		counter = 0;
		sleep = 0;
		noise = 0;
		noise_bar = GameObject.Find ("noise bar");
		sleep_bar = GameObject.Find ("sleep bar");
	}
	void Update () {
		sleep_bar.transform.localScale = new Vector3 ((float)sleep, 1, 1);
		if (sleep < 8) {
			sleep_bar.GetComponent<Image> ().color = HexToColor("E8000C");
		} else if (sleep < 12) {
			sleep_bar.GetComponent<Image> ().color = HexToColor("FFCF00");
		} else {
			sleep_bar.GetComponent<Image> ().color = HexToColor("00B717");
		}
	}

	void FixedUpdate(){
		counter++;
		sleep = 6 * Math.Sin(0.008 * counter) + 10;
		noise = Math.Max (noise - 0.005, 0);
		noise_bar.transform.localScale = new Vector3 ((float)noise, 1, 1);
		sleep_bar.transform.localScale = new Vector3 ((float)sleep, 1, 1);

		if (noise > sleep) {
//			Application.LoadLevel("game_over");
			var task_manager = GameObject.Find ("top-left ui").GetComponent<TaskManager> ();
			task_manager.gameOver ();
		}
	}

	public void incNoise(double decibels) {
		noise += decibels;
	}
	public void resetNoise() {
		noise = 0;
	}

	private Color HexToColor(string hex)
	{
		byte r = byte.Parse(hex.Substring(0,2), System.Globalization.NumberStyles.HexNumber);
		byte g = byte.Parse(hex.Substring(2,2), System.Globalization.NumberStyles.HexNumber);
		byte b = byte.Parse(hex.Substring(4,2), System.Globalization.NumberStyles.HexNumber);
		return new Color32(r,g,b, 255);
	}


}
