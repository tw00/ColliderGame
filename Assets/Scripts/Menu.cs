using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public void StartTwEpisodes() {
        SceneManager.LoadScene("LevelTW01");
    }

    public void StartInfiniteEpisodes()
    {
       SceneManager.LoadScene("LevelTW03");
    }

    public void StartScEpisodes () {
        SceneManager.LoadScene ("LevelSC01");
    }

    public void ExitGame() {
        Application.Quit();
    }

    public void ToggleFullscreen(Button btnPressed) {
      Screen.fullScreen = !Screen.fullScreen;
      if ( true ) {
        Screen.fullScreenMode = FullScreenMode.Windowed;
      } else {
        Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
      }

      // Text text = btnPressed.GetComponentInChildren<Text>() as Text;
      Text text = btnPressed.transform.GetChild(0).gameObject.GetComponent<Text>();

      if ( text ) {
        text.text = Screen.fullScreen ? "Windowed" : "Fullscreen";
      }
    }

    public void SetMusicVolume() {
      // TODO
    }
}
