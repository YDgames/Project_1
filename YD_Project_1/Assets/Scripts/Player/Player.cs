using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public VirtualJoystick joystick;
	public float speed;

	private Vector3 MoveVector;
	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void Update () {
		MoveVector = new Vector3 (joystick.Horizontal (), 0, joystick.Vertical ());
		Move ();
	}

	public void Move(){
		rb.AddForce (MoveVector * speed * Time.deltaTime);
	}

	public void SetLocation(Vector3 location){
		transform.position = location;
	}

	public float SetSpeed(){ return speed; }
}
