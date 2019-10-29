using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool _gameHasEnded = false;

    public float restartDelay = 2f;
    public GameObject completeLevelUI;

    public void EndGame() {
      if ( !_gameHasEnded ) {
        _gameHasEnded = true;
        Debug.Log("Game Over!");
        Invoke("Restart", restartDelay);
      }
    }

    void Restart() {
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void CompleteLevel() {
      completeLevelUI.SetActive(true);
    }
}
