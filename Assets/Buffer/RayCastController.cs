using UnityEngine;

public class RayCastController : MonoBehaviour
{
    [SerializeField] private CamSwitcher _camSwitcher;
    [SerializeField] private float _rayDistance = 100f;
    [SerializeField] private Transform _holdPoint;

    private GameObject _currentItem; // 現在持っているアイテム

    public void RaycastAndPickup()
    {
        if (_currentItem != null)
        {
            DropItem(); // 既に持っていたら落とす
            return;
        }

        Camera cam = _camSwitcher.CurrentCamera;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, _rayDistance))
        {
            if (hit.collider.CompareTag("Item"))
            {
                PickupItem(hit.collider.gameObject, _holdPoint);
                Debug.Log($"アイテム取得: {hit.collider.gameObject.name}");
            }
        }
    }

    private void PickupItem(GameObject item, Transform holdPoint)
    {
        // Rigidbody 無効化
        Rigidbody rb = item.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        // コライダー無効化
        Collider itemCollider = item.GetComponent<Collider>();
        if (itemCollider != null)
        {
            itemCollider.enabled = false;
        }

        // 親子化して位置・回転をリセット
        item.transform.SetParent(holdPoint);
        item.transform.localPosition = Vector3.zero;
        item.transform.localRotation = Quaternion.identity;

        _currentItem = item;
    }

    private void DropItem()
    {
        if (_currentItem == null) return;

        // Rigidbody を元に戻す
        Rigidbody rb = _currentItem.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = false;
        }

        // コライダーを元に戻す
        Collider itemCollider = _currentItem.GetComponent<Collider>();
        if (itemCollider != null)
        {
            itemCollider.enabled = true;
        }

        // 親子関係解除
        _currentItem.transform.SetParent(null);

        _currentItem = null;
    }
}
