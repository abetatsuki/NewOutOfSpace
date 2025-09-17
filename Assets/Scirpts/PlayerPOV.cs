using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPOV : MonoBehaviour
{
    public Transform neck;          // カメラを持つ首のTransform
    public float sensitivity = 0.1f;
    public float minVertical = -90f;
    public float maxVertical = 90f;

    private float rotationX = 0f;   // 縦方向の回転

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (Mouse.current == null)
        {
            Debug.LogWarning("Mouse.current が null です。Input System が有効か確認してください。");
            return;
        }

        // マウスの移動量を取得
        Vector2 mouseDelta = Mouse.current.delta.ReadValue();

        float mouseX = mouseDelta.x * sensitivity;
        float mouseY = mouseDelta.y * sensitivity;

        // デバッグログ出力
        Debug.Log($"mouseDelta = {mouseDelta}, mouseX = {mouseX}, mouseY = {mouseY}");

        // --- 横回転（Player本体） ---
        if (Mathf.Abs(mouseX) > 0.0001f)
        {
            Debug.Log($"横回転: {mouseX}");
            transform.Rotate(Vector3.up * mouseX);
        }

        // --- 縦回転（首） ---
        if (Mathf.Abs(mouseY) > 0.0001f)
        {
            Debug.Log($"縦回転: {mouseY}");
        }

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, minVertical, maxVertical);
        neck.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
    }
}
