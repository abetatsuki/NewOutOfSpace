using UnityEngine;
using UnityEngine.UI;

public class SceneControlButton : MonoBehaviour
{
    enum TargetScene
    {
        Next,
        Previous,
        MainMenu
    }

    [SerializeField] TargetScene targetscene;
    Button button;

    private void Start()
    {
        button = GetComponent<Button>();

        button.onClick.RemoveAllListeners();
        switch (targetscene)
        {
            case TargetScene.MainMenu:
                button.onClick.AddListener(() => SceneController.LoadMainScene()); break;

            case TargetScene.Next:
                button.onClick.AddListener(() => SceneController.LoadNextScene()); break;

            case TargetScene.Previous:
                button.onClick.AddListener(() => SceneController.LoadPreviousScene()); break;
        }

    }
}
