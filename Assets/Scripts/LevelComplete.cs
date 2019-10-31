using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    public void LoadNextLevel () {
        // Check if current scene is the last one -> Navigate back to menu
        int nextLevelBuildIndex = SceneManager.GetActiveScene ().buildIndex + 1;
        if (nextLevelBuildIndex >= SceneManager.sceneCountInBuildSettings) {
            SceneManager.LoadScene (0);
            return;
        }

        // Get name of current scene and next scene
        string sceneName = SceneManager.GetActiveScene ().name;
        string nextSceneName = SceneManager.GetSceneByBuildIndex (nextLevelBuildIndex).name;

        if (sceneName.Length > 7 && nextSceneName.Length > 7) {
            // Check if name tag of scenes is equal
            if (sceneName[5] == nextSceneName[5] || sceneName[6] == nextSceneName[6]) {
                // Progress to next level
                SceneManager.LoadScene (nextLevelBuildIndex);
            }
        }

        // Go back to menu
        SceneManager.LoadScene (0);
    }
}
