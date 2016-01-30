using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TaskManager : MonoBehaviour {

	private GameObject title;
	private GameObject description;

	public int stage;
	// Use this for initialization
	void Start () {
		stage = 0;
		title = GameObject.Find ("task title");
		description = GameObject.Find ("task description");

		finishTask ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void finishTask() {
		stage++;
		switch (stage) {
		case 1:
			title.GetComponent<Text> ().text = "YOUR FIRST TASK";
			description.GetComponent<Text> ().text = "eat the chips";
			break;
		case 2:
			title.GetComponent<Text> ().text = "Task 2";
			description.GetComponent<Text> ().text = "build a birdhouse";
			break;
		default:
			break;
		}
	}
}
