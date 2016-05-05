using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour {

	public GameObject panel_main;
	public GameObject panel_playing;
	public GameObject player;
	public Cameras camera;
	public Terrain map;

	void Start(){
		Init ();
	}

	// 초기화
	void Init ()
	{
		panel_main.SetActive (true);
		panel_playing.SetActive(false);
	}

	// 게임 시작
	public void GameStart(){
		player = Instantiate<GameObject>(GameObject.Find("Player")); // 플레이어 오브젝트 생성
		player.GetComponent<Rigidbody> ().isKinematic = false;

		player.GetComponent<Player>().SetLocation (GetRandomLocation());
		camera.SetPlayer (player);

		panel_main.SetActive (false);
		panel_playing.SetActive(true);
	}

	// 게임 종료
	public void GameEnd(){
		GameObject.Destroy(player.gameObject);	// 플레이어 오브젝트 삭제
		panel_main.SetActive (true);
		panel_playing.SetActive(false);
	}

	// 맵 안에 랜덤으로 위치 지정
	public Vector3 GetRandomLocation(){
		int X = Mathf.RoundToInt(Random.Range (0f, map.terrainData.size.x));
		int Z = Mathf.RoundToInt(Random.Range (0f, map.terrainData.size.z));
		float Y = map.terrainData.GetHeight(X, Z) + player.transform.localScale.x*2;
		return new Vector3 (X, Y, Z);
	}
}