using UnityEngine;
using System.Collections;
using System.Timers;

public class Cameras : MonoBehaviour {

	float speed;

	// Use this for initialization
	void Start () {
		speed = 10f;

		Terrain desert = GameObject.Find ("Desert").GetComponent<Terrain> ();

	}
	
	// Update is called once per frame
	void Update () {
		Vector3 moveVector = new Vector3();

		if(Input.GetKey(KeyCode.UpArrow)) moveVector = (Vector3.forward +  Vector3.up) * Time.deltaTime * speed;
		if(Input.GetKey(KeyCode.DownArrow)) moveVector = (Vector3.back + Vector3.down) * Time.deltaTime * speed;
		if(Input.GetKey(KeyCode.LeftArrow)) moveVector = Vector3.left * Time.deltaTime * speed * 2;	// 속도 보정위해 곱하기 2
		if(Input.GetKey(KeyCode.RightArrow)) moveVector = Vector3.right * Time.deltaTime * speed * 2; 
		if(Input.GetAxis("Mouse ScrollWheel") > 0) moveVector = Vector3.forward * Time.deltaTime * speed * 5;
		if(Input.GetAxis("Mouse ScrollWheel") < 0) moveVector = Vector3.back * Time.deltaTime * speed * 5;

		if(isMovePosition(moveVector))
			transform.Translate (moveVector);
//
//		if(Input.GetKey(KeyCode.UpArrow)) transform.Translate ((Vector3.forward +  Vector3.up) * Time.deltaTime * speed);
//		if(Input.GetKey(KeyCode.DownArrow)) transform.Translate ((Vector3.back + Vector3.down) * Time.deltaTime * speed);
//		if(Input.GetKey(KeyCode.LeftArrow)) transform.Translate (Vector3.left * Time.deltaTime * speed * 2);	// 속도 보정위해 곱하기 2
//		if(Input.GetKey(KeyCode.RightArrow)) transform.Translate (Vector3.right * Time.deltaTime * speed * 2); 
//		if(Input.GetAxis("Mouse ScrollWheel") > 0) transform.Translate (Vector3.forward * Time.deltaTime * speed * 5);
//		if(Input.GetAxis("Mouse ScrollWheel") < 0) transform.Translate (Vector3.back * Time.deltaTime * speed * 5);
	}

	bool isMovePosition(Vector3 moveVector){
		Terrain desert = GameObject.Find ("Desert").GetComponent<Terrain> ();
		if (transform.localPosition.x + moveVector.x >= desert.transform.localPosition.x
		   && transform.localPosition.x + moveVector.x < desert.transform.localPosition.x + desert.terrainData.size.x
		   && transform.localPosition.y + moveVector.y >= desert.transform.localPosition.y
		   && transform.localPosition.y + moveVector.y < desert.transform.localPosition.y + desert.terrainData.size.y)
			return true;

		return false;


	}
}
