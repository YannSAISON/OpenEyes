using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public CharacterController2D controller;
    public float runSpeed = 40f;
    public float horizontalMove = 0f;
    public bool jump = false;
    public bool crouch = false;

    // Update is called once per frame
    private void Update() {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump")) {
            jump = true;
        }
        if (Input.GetButtonDown("Crouch")) {
            crouch = true;
        } else if (Input.GetButtonUp("Crouch")) {
            crouch = false;
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            if (GameObject.FindObjectsOfType<AngerBar>().Length > 0)
                GameObject.FindObjectsOfType<AngerBar>()[0].GetComponent<AngerBar>().ChangeStatus(10, false);
        }
    }

    private void FixedUpdate() {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
