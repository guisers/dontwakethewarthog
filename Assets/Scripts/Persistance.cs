using UnityEngine;
using System.Collections;

public class Persistance : MonoBehaviour {
	void Awake() {
		DontDestroyOnLoad(gameObject);
	}
}