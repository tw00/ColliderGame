using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
  public UnityEngine.Transform playerTransform;
  public UnityEngine.Rigidbody playerRb;
  public Vector3 offset;

  void Update()
  {
    float zoom = 1 + (playerRb.velocity.magnitude / 16f);
    transform.position = playerTransform.position + offset * zoom;
    transform.RotateAround(
      Vector3.zero, Vector3.up, 20 * Time.deltaTime);
  }
}
