using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerController controller;

    void OnCollisionEnter(Collision other) {

      if ( other.collider.tag == "Obstacle" ) {
        controller.enabled = false;
        FindObjectOfType<GameManager>().EndGame();
      }
    }
}
