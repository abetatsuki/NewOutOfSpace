using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    // スタートボタンから呼ばれる
    public void OnStartButton()
    {
        SceneManager.LoadScene("mainScene"); // ゲーム本編のシーン名に変更
    }

    // 遊び方ボタンから呼ばれる
    public void OnHowToPlayButton()
    {
        SceneManager.LoadScene("HowToPlayScene"); // 説明用シーン
    }

    // 終了ボタンから呼ばれる
    public void OnExitButton()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // エディタで実行中なら停止
#endif
    }
}
