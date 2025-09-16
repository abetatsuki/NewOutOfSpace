using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneController
{
    static int mainScene = 0;

    // メインシーンをロード
    public static void LoadMainScene()
    {
        SceneManager.LoadScene(mainScene);
    }

    // 次のシーンをロード
    public static void LoadNextScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;

        if (currentScene < SceneManager.sceneCountInBuildSettings - 1)
            SceneManager.LoadScene(currentScene + 1);
        else
            Debug.Log("これ以上次のシーンはありません。");
    }

    // 前のシーンをロード
    public static void LoadPreviousScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;

        if (currentScene > 0)
            SceneManager.LoadScene(currentScene - 1);
        else
            Debug.Log("これ以上前のシーンはありません。");
    }

    // 任意のシーンをロード
    public static void LoadScene(int index)
    {
        if (index >= 0 && index < SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(index);
        else
            Debug.LogError("シーン番号が範囲外です: " + index);
    }
}
