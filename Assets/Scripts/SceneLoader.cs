using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
        //SceneManager.LoadScene("CoreGame");
    }

    public void LoadGameOverScene()
    {
        SceneManager.LoadScene("Game Over");
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<GameSession>().EndGame();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
