using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class CharacterController2D : MonoBehaviour {
    [SerializeField] private float jumpForce = 400f; // Amount of force added when the player jumps.

    [Range(0, 1)] [SerializeField]
    private float crouchSpeed = .36f; // Amount of maxSpeed applied to crouching movement. 1 = 100%

    [Range(0, .3f)] [SerializeField] private float movementSmoothing = .05f; // How much to smooth out the movement
    [SerializeField] private bool airControl = false; // Whether or not a player can steer while jumping;
    [SerializeField] private LayerMask whatIsGround; // A mask determining what is ground to the character

    [SerializeField] private Transform groundCheck; // A position marking where to check if the player is grounded.

    [SerializeField] private Transform ceilingCheck; // A position marking where to check for ceilings
    [SerializeField] private Collider2D crouchDisableCollider; // A collider that will be disabled when crouching

    private const float KGroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
    private bool m_Grounded; // Whether or not the player is grounded.
    private const float KCeilingRadius = .2f; // Radius of the overlap circle to determine if the player can stand up
    private Rigidbody2D m_Rigidbody2D;
    private bool m_FacingRight = true; // For determining which way the player is currently facing.
    private Vector3 m_Velocity = Vector3.zero;
    [Space] public UnityEvent onLandEvent;
    public BoolEvent onCrouchEvent;
    private bool m_WasCrouching = false;

    private float time = 0;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> {
    }

    private void Awake() {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();

        if (onLandEvent == null)
            onLandEvent = new UnityEvent();

        if (onCrouchEvent == null)
            onCrouchEvent = new BoolEvent();
    }

    private void FixedUpdate() {
        bool wasGrounded = m_Grounded;
        m_Grounded = false;

        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, KGroundedRadius, whatIsGround);
        for (int i = 0; i < colliders.Length; i++) {
            if (colliders[i].gameObject != gameObject) {
                m_Grounded = true;
                if (!wasGrounded && Time.time > time + 0.002)
                    onLandEvent.Invoke();
            }
        }
    }


    public void Move(float move, bool crouch, bool jump) {
        // If crouching, check to see if the character can stand up
        if (!crouch) {
            // If the character has a ceiling preventing them from standing up, keep them crouching
            if (Physics2D.OverlapCircle(ceilingCheck.position, KCeilingRadius, whatIsGround)) {
                crouch = true;
            }
        }

        //only control the player if grounded or airControl is turned on
        if (m_Grounded || airControl) {
            // If crouching
            if (crouch) {
                if (!m_WasCrouching) {
                    m_WasCrouching = true;
                    onCrouchEvent.Invoke(true);
                }

                // Reduce the speed by the crouchSpeed multiplier
                move *= crouchSpeed;

                // Disable one of the colliders when crouching
                if (crouchDisableCollider != null)
                    crouchDisableCollider.enabled = false;
            } else {
                // Enable the collider when not crouching
                if (crouchDisableCollider != null)
                    crouchDisableCollider.enabled = true;

                if (m_WasCrouching) {
                    m_WasCrouching = false;
                    onCrouchEvent.Invoke(false);
                }
            }

            // Move the character by finding the target velocity
            Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
            // And then smoothing it out and applying it to the character
            m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity,
                movementSmoothing);

            // If the input is moving the player right and the player is facing left...
            if (move > 0 && !m_FacingRight) {
                // ... flip the player.
                Flip();
            }
            // Otherwise if the input is moving the player left and the player is facing right...
            else if (move < 0 && m_FacingRight) {
                // ... flip the player.
                Flip();
            }
        }

        // If the player should jump...
        if (m_Grounded && jump) {
            // Add a vertical force to the player.
            m_Grounded = false;
            time = Time.time;
            m_Rigidbody2D.AddForce(new Vector2(0f, jumpForce));
        }
    }


    private void Flip() {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 cameraScale = transform.GetChild(0).GetChild(0).transform.localScale;
        cameraScale.x *= -1;
        transform.GetChild(0).GetChild(0).transform.localScale = cameraScale;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
