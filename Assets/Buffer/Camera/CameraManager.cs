using UnityEngine;

public enum CameraViewMode
{
    TopView,     // è„Ç©ÇÁ
    SideView     // â°Ç©ÇÁ
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
        topViewCamera.enabled = (CurrentViewMode == CameraViewMode.TopView);
        sideViewCamera.enabled = (CurrentViewMode == CameraViewMode.SideView);
    }
}
