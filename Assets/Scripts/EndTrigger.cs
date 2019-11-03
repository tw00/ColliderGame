using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public GameManager gameManager;

    private void OnTriggerEnter(Collider other) {
      if ( !gameManager ) {
        gameManager = FindObjectOfType<GameManager>() as GameManager;
      }
      gameManager.CompleteLevel();
    }
}
