using UnityEngine;

public enum CameraViewMode
{
    TopView,     // ã‚©‚ç
    SideView     // ‰¡‚©‚ç
}

public class CameraViewSwitcher : MonoBehaviour
{
    [SerializeField] private Camera topViewCamera;
    [SerializeField] private Camera sideViewCamera;

    public CameraViewMode CurrentViewMode { get; private set; } = CameraViewMode.TopView;

    private void Start()
    {
        UpdateCameraView();
    }

    public void ToggleView()
    {
        if (CurrentViewMode == CameraViewMode.TopView)
            CurrentViewMode = CameraViewMode.SideView;
        else
            CurrentViewMode = CameraViewMode.TopView;

        UpdateCameraView();
    }

    private void UpdateCameraView()
    {
        bool isTop = (CurrentViewMode == CameraViewMode.TopView);

        // ƒJƒƒ‰‚Ì—LŒø/–³ŒøØ‚è‘Ö‚¦
        topViewCamera.enabled = isTop;
        sideViewCamera.enabled = !isTop;

        // AudioListener ‚Ì—LŒø/–³ŒøØ‚è‘Ö‚¦
        var topListener = topViewCamera.GetComponent<AudioListener>();
        var sideListener = sideViewCamera.GetComponent<AudioListener>();

        if (topListener != null) topListener.enabled = isTop;
        if (sideListener != null) sideListener.enabled = !isTop;
    }
}
