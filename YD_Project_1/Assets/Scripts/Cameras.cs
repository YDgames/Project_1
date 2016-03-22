using UnityEngine;
using System.Collections;
using System.Timers;

public class Cameras : MonoBehaviour {
    
	GameObject player = null;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 v3 = player 	.transform.position;
		transform.position = new Vector3 (v3.x, v3.y + 70, v3.z - 50);
	}
}
