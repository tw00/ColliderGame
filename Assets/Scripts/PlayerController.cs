using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public UnityEngine.Rigidbody rb;

    public float forwardForce = 2000f;
    public float sidewardForce = 300f;
    public float jumpImpulse = 10f;
    private float distToGround;

    void Start() {
      distToGround = GetComponent<Collider>().bounds.extents.y;
    }

    void FixedUpdate()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if ( Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(-sidewardForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(sidewardForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow)) {
          if ( IsGrounded() ) {
            rb.AddForce(0, jumpImpulse, 0, ForceMode.Impulse);
          }
        }

        if ( rb.position.y < -3f ) {
          FindObjectOfType<GameManager>().EndGame();
        }
    }

    bool IsGrounded() {
      return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }
}
