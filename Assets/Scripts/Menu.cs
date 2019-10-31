using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void StartTwEpisodes() {
        SceneManager.LoadScene("LevelTW01");
    }

    public void StartScEpisodes () {
        SceneManager.LoadScene ("LevelSC01");
    }
}
