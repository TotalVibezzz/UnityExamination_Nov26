using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToGame : MonoBehaviour
{
    public string gameSceneName = "GameScene";

    public void GoBack()
    {
        SceneManager.LoadScene(gameSceneName);
    }
}