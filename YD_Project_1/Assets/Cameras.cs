using UnityEngine;
using System.Collections;
using System.Timers;

public class Cameras : MonoBehaviour {

	float speed;

	// Use this for initialization
	void Start () {
		speed = 2f;
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKey(KeyCode.W)) transform.Translate (transform.forward * Time.deltaTime * speed);
		else if(Input.GetKey(KeyCode.S)) transform.Translate (-transform.forward * Time.deltaTime * speed);
		else if(Input.GetKey(KeyCode.A)) transform.Translate (-transform.right * Time.deltaTime * speed);
		else if(Input.GetKey(KeyCode.D)) transform.Translate (transform.right * Time.deltaTime * speed); 

	}
}
