using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//important to include this one
using UnityEngine.SceneManagement;

public class SceneBoss : MonoBehaviour
{
    public static void GameOverScene()
{
    SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
}
    public static void TitleScene()
{
    SceneManager.LoadScene("Title", LoadSceneMode.Single);
}

    public static void NewGameScene()
{
    SceneManager.LoadScene("StoryMode", LoadSceneMode.Single);
}

}
