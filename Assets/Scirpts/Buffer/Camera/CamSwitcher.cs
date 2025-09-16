using UnityEngine;
using UnityEngine.Scripting;

public enum CameraViewMode
{
    FirstPerson,     // ã‚©‚ç
    ThirdPerson     // ‰¡‚©‚ç
}

public class CamSwitcher : MonoBehaviour
{
    [SerializeField] private Camera _firstPersonCamera;
    [SerializeField] private Camera _thirdPersonCamera;

    public CameraViewMode CurrentViewMode { get; private set; } = CameraViewMode.FirstPerson;

    private void Start()
    {
        UpdateCameraView();
    }

    public void ToggleView()
    {
        if (CurrentViewMode == CameraViewMode.FirstPerson)
            CurrentViewMode = CameraViewMode.ThirdPerson;
        else
            CurrentViewMode = CameraViewMode.FirstPerson;

        UpdateCameraView();
    }

    private void UpdateCameraView()
    {
        bool isTop = (CurrentViewMode == CameraViewMode.FirstPerson);

        // ƒJƒƒ‰‚Ì—LŒø/–³ŒøØ‚è‘Ö‚¦
        _firstPersonCamera.enabled = isTop;
        _thirdPersonCamera.enabled = !isTop;

        // AudioListener ‚Ì—LŒø/–³ŒøØ‚è‘Ö‚¦
        var topListener = _firstPersonCamera.GetComponent<AudioListener>();
        var sideListener = _thirdPersonCamera.GetComponent<AudioListener>();

        if (topListener != null) topListener.enabled = isTop;
        if (sideListener != null) sideListener.enabled = !isTop;
    }
    public CameraViewMode GetCameraStatus()
    {
        return CurrentViewMode;
    }
    public Camera CurrentCamera
    {
        get
        {
            return CurrentViewMode == CameraViewMode.FirstPerson
                ? _firstPersonCamera
                : _thirdPersonCamera;
        }
    }
   




}
