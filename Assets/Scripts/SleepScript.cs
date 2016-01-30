using UnityEngine;
//using System.Collections;
using System;

public class SleepScript : MonoBehaviour {
	
	public double sleep;
	private double counter = 0;

	void Start () {

	}
	void Update () {
		
	}

	void FixedUpdate() {
		counter++;
		sleep = 2 * Math.Sin(0.001 * counter) + 2;
	}
}
