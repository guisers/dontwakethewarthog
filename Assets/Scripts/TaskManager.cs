using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TaskManager : MonoBehaviour {

	public int stage = 1;
	// Use this for initialization
	void Start () {
		var title = GameObject.Find ("task title").GetComponent<Text> ();
		var description = GameObject.Find ("task description").GetComponent<Text> ();
		switch (stage) {
		case 1:
			title.text = "YOUR FIRST TASK";
			description.text = "eat the chips";
			Debug.Log (title);
			break;
		default:
			break;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
