using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class LevelComplete : MonoBehaviour
{
    public void LoadNextLevel () {
        Debug.Log("LoadNextLevel");

        // Check if current scene is the last one -> Navigate back to menu
        int nextLevelBuildIndex = SceneManager.GetActiveScene ().buildIndex + 1;
        if (nextLevelBuildIndex >= SceneManager.sceneCountInBuildSettings) {
            SceneManager.LoadScene (0);
            return;
        }

        // Get name of current scene and next scene
        string sceneName = SceneManager.GetActiveScene ().name;

        // See bug: https://issuetracker.unity3d.com/issues/scenemanager-dot-getscenebybuildindex-dot-name-returns-an-empty-string-if-scene-is-not-loaded
        // string nextSceneName = SceneManager.GetSceneByBuildIndex (nextLevelBuildIndex).name;
        string nextScenePath = SceneUtility.GetScenePathByBuildIndex( nextLevelBuildIndex );
        string nextSceneName = Path.GetFileNameWithoutExtension(nextScenePath);

        Debug.Log("sceneName: " + sceneName);
        Debug.Log("nextSceneName: " + nextSceneName);

        if (sceneName.Length > 7 && nextSceneName.Length > 7) {
            // Check if name tag of scenes is equal
            if (sceneName[5] == nextSceneName[5]
             || sceneName[6] == nextSceneName[6]) {
                // Progress to next level
                SceneManager.LoadScene (nextLevelBuildIndex);
                return;
            }
        }

        // Go back to menu
        SceneManager.LoadScene (0);
    }
}
