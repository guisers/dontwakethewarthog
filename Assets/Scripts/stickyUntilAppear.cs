using UnityEngine;
using System.Collections;

public class stickyUntilAppear : MonoBehaviour {

	public string destination;
	private bool active;
	// Use this for initialization
	void Start () {
		active = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (active) {
			gameObject.transform.position = GameObject.Find (destination).transform.position;
		}
	}

	public void setActive(bool activity) {
		active = activity;
	}
}
