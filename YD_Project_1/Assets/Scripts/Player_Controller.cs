using UnityEngine;
using System.Collections;

public class Player_Controller : MonoBehaviour {

	float speed;
	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		speed = 800f;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.W)) rb.AddForce (Vector3.forward * Time.deltaTime * speed);
		if(Input.GetKey(KeyCode.S)) rb.AddForce (-Vector3.forward * Time.deltaTime * speed);
		if(Input.GetKey(KeyCode.A)) rb.AddForce (-Vector3.right * Time.deltaTime * speed);
		if(Input.GetKey(KeyCode.D)) rb.AddForce (Vector3.right * Time.deltaTime * speed); 
	}
}
