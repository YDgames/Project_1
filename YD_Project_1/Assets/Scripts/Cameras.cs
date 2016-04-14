using UnityEngine;
using System.Collections;
using System.Timers;

public class Cameras : MonoBehaviour {
    
	GameObject player = null;

	void Update () {
		// 플레이어가 있으면 따라다니기
		if (player != null) {
			Vector3 v3 = player.transform.position;
			transform.position = new Vector3 (v3.x, v3.y + 15, v3.z - 20);
		}
	}

	// 플레이어 설정
	public void SetPlayer(GameObject player){
		this.player = player;
	}
}
