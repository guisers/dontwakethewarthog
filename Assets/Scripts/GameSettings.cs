using UnityEngine;
using System.Collections;

public class GameSettings : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	// CLASS VARIABLES
	static GameSettings instance;
	private int stage;

	// EVENTS
	void Awake ()
	{
		if (instance)
		{
			Destroy (gameObject);
		}
		else
		{
			instance = this;
			stage = 0;
			DontDestroyOnLoad (gameObject);
		}
	}

	public void setStage(int new_stage) {
		stage = new_stage;
	}
	public int getStage() {
		return stage;
	}
}


