using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public UnityEngine.Rigidbody rb;

    public float forwardForce = 2000f;
    public float sidewardForce = 300f;
    public float jumpImpulse = 10f;
    private float distToGround;
    public float offsetGrounded = 0.1f;

    public bool useBoost = false;
    public bool boostActive = false;
    public float boostAcivationThreshold = 10f;
    public float boostRecharge = 1.5f;
    public float boostConsume = 7.5f;
    public float boostForce = 20f;
    public float boostReserve = 0f;
    public float boostReserveMax = 100f;

    void Start() {
        distToGround = GetComponent<Collider>().bounds.extents.y;
    }

    void FixedUpdate()
    {
        // Forward
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        // Steer left
        if ( Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(-sidewardForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        // Steer right
        if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(sidewardForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        // Boost
        if (useBoost && boostReserve > 0f && (Input.GetKey ("w") || Input.GetKey (KeyCode.UpArrow)) && (boostReserve > boostAcivationThreshold || boostActive)) {
            boostActive = true;
            rb.AddForce (0, 0, boostForce * Time.deltaTime, ForceMode.VelocityChange);

            // Reduce boost on usage
            boostReserve -= boostConsume * Time.deltaTime;

            // Make sure boost reserve is never negative
            if (boostReserve <= 0f) {
                boostReserve = 0f;
                boostActive = false;
            }            
        } else {
            boostActive = false;
        }

        // Recharge boost
        if (boostReserve <= boostReserveMax) {
            boostReserve += boostRecharge * Time.deltaTime;
        }

        // Jump
        if (Input.GetKey (KeyCode.Space)) {
            if ( IsGrounded() ) {
                rb.AddForce(0, jumpImpulse, 0, ForceMode.Impulse);
            }
        }

        // "Die"
        if ( rb.position.y < -3f ) {
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    bool IsGrounded() {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + offsetGrounded);
    }
}
