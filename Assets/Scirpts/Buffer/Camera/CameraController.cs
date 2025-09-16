using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CamSwitcher _viewSwitcher;
    [SerializeField] private PlayerInputNotifier _inputNotifier;

    private void OnEnable()
    {
        _inputNotifier.OnCamera += HandleCameraToggle;
    }

    private void OnDisable()
    {
        _inputNotifier.OnCamera -= HandleCameraToggle;
    }

    private void HandleCameraToggle()
    {
        _viewSwitcher.ToggleView();
    }

}
