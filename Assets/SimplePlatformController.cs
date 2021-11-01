using UnityEngine;
using System.Collections;
using System;

public class SimplePlatformController : MonoBehaviour {


    public int direction;
    public int Speed;
    private float horizontalInput;
    private float verticalInput;
    public float sizeMove;
    GameObject player;
    int Status = 0;
    bool playerIsOn = false;

    void Start() {
        player = GameObject.Find ("Player");

        horizontalInput = transform.position.x;
        verticalInput = transform.position.y;
    }
    void Update()   
    {
        if (direction == 0) {
            HorizontalMove();
        } else {
            VerticaleMove();
        }
    }
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            playerIsOn = true;
            Debug.Log("Collision Detected SimplePlatformController");
        } else {
            playerIsOn = false;
        }
    }
    void HorizontalMove() {
        float x = transform.position.x;

        if (x > horizontalInput + sizeMove && Status == 0) {
            Status = 1;
        } else if (x < horizontalInput  && Status == 1) {
            Status = 0;
        }
        if (Status == 0) {
            transform.Translate(Vector3.right * Speed / 50, Space.World);
            if (playerIsOn) {
                Debug.Log("is on player is on");
                //player.transform.position = new Vector3(transform.position.x, player.transform.position.y, 0); 

            }
        } else {
            transform.Translate(Vector3.left * Speed / 50, Space.World);
            if (playerIsOn) {
                //player.transform.position = new Vector3(transform.position.x, player.transform.position.y, 0); 




            }
        }
    }
    void VerticaleMove() {
        float y = transform.position.y;

        if (y > verticalInput + sizeMove && Status == 0) {
            Status = 1;
        } else if (y < verticalInput  && Status == 1) {
            Status = 0;
        }
        if (Status == 0) {
            transform.Translate(Vector3.up * Speed / 50, Space.World);
        } else {
            transform.Translate(Vector3.down * Speed / 50, Space.World);
        }
    }
}