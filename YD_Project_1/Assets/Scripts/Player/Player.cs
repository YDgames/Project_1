using UnityEngine;
using System.Collections;
using System.Threading;
using System.Collections.Generic;

public class Player : MonoBehaviour {

    public VirtualJoystick joystick;
    public float speed;

    private Vector3 MoveVector;
    private Rigidbody rb;
    List<GameObject> feed;

    MeshCollider meshcollider;
    Collider otherplayer = null;  //나중에 쓰레드 처리해야함

    float pickups_lerp_speed = 0.01f;  // 먹이 먹었을때 구체 중심쪽으로 들어가는 속도
    private float pickups_disappearance_point = 0.7f;

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody>();
        meshcollider = GetComponent<MeshCollider>();
        feed = new List<GameObject>();
    }

    // Update is called once per frame
    void Update() {
        MoveVector = new Vector3(joystick.Horizontal(), 0, joystick.Vertical());
        Move();

        //먹이 먹었을때 빨려들어가는 이벤트
        if (feed.Count != 0) {
            for (int i = 0; i < feed.Count; i++) {
                feed[i].transform.position = Vector3.Lerp(feed[i].transform.position, transform.position, pickups_lerp_speed);
                var distance = Vector3.Distance(transform.position, feed[i].transform.position); //위치 구하기.
                if (distance < 2) {
                    feed[i].SetActive(false);
                    float size = (float)(transform.localScale.x + 0.05);
                    transform.localScale = new Vector3(size, size, size);
                    feed.RemoveAt(i);
                }
            }
        }


        if (otherplayer != null) {
            var distance = Vector3.Distance(rb.transform.position, otherplayer.transform.position); //위치 구하기.
            if (distance <= rb.transform.lossyScale.x - otherplayer.transform.lossyScale.x * 0.2) {
                otherplayer.transform.position = Vector3.Lerp(otherplayer.transform.position, rb.transform.position, pickups_disappearance_point);
                otherplayer.gameObject.SetActive(false);
                float size = (float)(transform.localScale.x + otherplayer.transform.lossyScale.x * 0.3);
                transform.localScale = new Vector3(size, size, size);
                otherplayer = null;
            }
        }
    }

    public void Move() {
        rb.AddForce(MoveVector * speed * Time.deltaTime);
    }

    public void SetLocation(Vector3 location) {
        transform.position = location;
    }

    public float SetSpeed() { return speed; }


    //먹이 먹었을때 구체에 붙는 이벤트
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("pickup_square_1")) {
            other.transform.parent = transform;
            feed.Add(other.gameObject);
        }

        if (other.gameObject.CompareTag("collisionignore")) {  //같은 플레이어 끼리 충돌 무시
            Physics.IgnoreCollision(meshcollider, other);
            if (rb.transform.lossyScale.x > other.transform.lossyScale.x) {
                otherplayer = other;
            }
        }
    }

}
