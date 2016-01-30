using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerAction : MonoBehaviour {

	public string id;
	public string key;
	public double noise;
	public int keys_to_finish;
	public string instruction;
	private ObjectScript parent;

	public void setValues(string new_id, string new_key, double new_noise, int new_keys_to_finish, string new_ins) {
		id = new_id;
		key = new_key;
		noise = new_noise;
		keys_to_finish = new_keys_to_finish;
		instruction = new_ins;
	}
	// Use this for initialization
	void Start () {
		parent = GetComponent<ObjectScript> ();
	}

	// Update is called once per frame
	void Update () {

	}

}
