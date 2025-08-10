using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CameraViewSwitcher viewSwitcher;
    [SerializeField] private PlayerInputNotifier inputNotifier;

    private void OnEnable()
    {
        inputNotifier.OnCamera += HandleCameraToggle;
    }

    private void OnDisable()
    {
        inputNotifier.OnCamera -= HandleCameraToggle;
    }

    private void HandleCameraToggle()
    {
        viewSwitcher.ToggleView();
    }

}
