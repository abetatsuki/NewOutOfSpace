using UnityEngine;

public class ItemHolder : MonoBehaviour
{
    [SerializeField] private Transform _holdPoint;
    private GameObject _currentItem;

  
    public void HandlePickupInput(RayCastController raycastController)
    {
       
        if (_currentItem != null)
        {
            DropCurrentItem();
            return;
        }

       
        GameObject item = raycastController.GetItemUnderMouse();
        if (item != null)
        {
            PickupItem(item);
        }
    }

    private void PickupItem(GameObject item)
    {
        Debug.Log("pickup");

        Rigidbody rb = item.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        Collider col = item.GetComponent<Collider>();
        if (col != null) col.enabled = false;

        item.transform.SetParent(_holdPoint);
        item.transform.localPosition = Vector3.zero;
        item.transform.localRotation = Quaternion.identity;

        _currentItem = item;
    }

    public void DropCurrentItem()
    {
        if (_currentItem == null) return;

        Rigidbody rb = _currentItem.GetComponent<Rigidbody>();
        if (rb != null) rb.isKinematic = false;

        Collider col = _currentItem.GetComponent<Collider>();
        if (col != null) col.enabled = true;

        _currentItem.transform.SetParent(null, true);

        _currentItem = null;
    }

    public bool HasItem() => _currentItem != null;
}
