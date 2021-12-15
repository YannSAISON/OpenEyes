using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public CharacterController2D controller;
    public RuntimeAnimatorController calmAnimator;
    public RuntimeAnimatorController ragingAnimator;
    public float runSpeed = 40f;
    public float horizontalMove = 0f;
    public bool jump = false;
    public bool crouch = false;
    public Vector3 lastPos = new Vector3();

    public Animator animator;

    private void Start()
    {
        lastPos = transform.position;
        animator.runtimeAnimatorController = calmAnimator;
        GameObject.FindObjectOfType<AngerBar>().AddAngryEvent(OnRaging);
        GameObject.FindObjectOfType<AngerBar>().AddCalmEvent(OnCalming);
    }

    // Update is called once per frame
    private void Update() {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        if (Input.GetButtonDown("Jump")) {
            jump = true;
            animator.SetBool("IsJumping", true);
        }
        if (Input.GetButtonDown("Crouch")) {
            crouch = true;
        } else if (Input.GetButtonUp("Crouch")) {
            crouch = false;
        }
        animator.SetFloat("VelocityY", transform.position.y - lastPos.y);
        if (Input.GetKeyDown(KeyCode.O))
        {
            if (GameObject.FindObjectsOfType<AngerBar>().Length > 0)
                GameObject.FindObjectsOfType<AngerBar>()[0].GetComponent<AngerBar>().ChangeStatus(10, false);
        }
        lastPos = transform.position;
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    public void OnRaging()
    {
        animator.runtimeAnimatorController = ragingAnimator;
    }

    public void OnCalming()
    {
        animator.runtimeAnimatorController = calmAnimator;
    }


    private void FixedUpdate() {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Object")
            InventoryManager.Instance.AddNewGroundItem(other);
    }
}
