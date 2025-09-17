using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour
{
    private bool _isVisible = true;
    private Renderer _renderer;
    private Collider _collider;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _collider = GetComponent<Collider>();
    }

    public void ToggleDoor()
    {
        if (_isVisible)
        {
            StartCoroutine(HideDoorTemporarily(3f));
        }
    }

    private IEnumerator HideDoorTemporarily(float duration)
    {
        // ドアを非表示＆当たり判定を消す
        _renderer.enabled = false;
        _collider.enabled = false;
        _isVisible = false;

        Debug.Log($"{name} を非表示にしました");

        // 指定時間待機
        yield return new WaitForSeconds(duration);

        // ドアを再表示
        _renderer.enabled = true;
        _collider.enabled = true;
        _isVisible = true;

        Debug.Log($"{name} が戻ってきました");
    }
}
