using UnityEngine;
using System.Collections;
using System.Timers;

public class Cameras : MonoBehaviour {
    
	public GameObject player = null;
    private Vector3 offset;
	// Use this for initialization
	void Start () {
        offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = player.transform.position + offset;
	}
}
