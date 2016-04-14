using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour {

	GameObject MainPanel = null;

	// Use this for initialization
	void Start () {
		Debug.Log ("Start");
		MainPanel = GameObject.Find ("MainPanel");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PlayGame(){
		Debug.Log ("Play Game");
		MainPanel.SetActive (false);
	}
}
