using UnityEngine;

public class PlayerMove : MonoBehaviour {
    public float speed = 10;
    private Rigidbody2D m_RigidBody2D;

    internal void Awake() {
        m_RigidBody2D = GetComponent<Rigidbody2D>();
    }

    public void FixedUpdate() {
        float xMove = Input.GetAxis("Horizontal");
        float yMove = Input.GetAxis("Vertical");
        float xSpeed = xMove * speed;
        float ySpeed = yMove * speed;
        Vector2 newVelocity = new Vector2(xSpeed, ySpeed);

        m_RigidBody2D.velocity = newVelocity;
    }
}
