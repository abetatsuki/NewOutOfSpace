using UnityEngine;

public class RayCastController : MonoBehaviour
{
    [SerializeField] private CamSwitcher _camSwitcher;
    [SerializeField] private float _rayDistance = 100f;
    [SerializeField] private float _pickupRange = 5f;
    [SerializeField] private Transform _player;

    public GameObject GetItemUnderMouse()
    {

        Camera cam = _camSwitcher.CurrentCamera;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, _rayDistance))
        {
            Item itemData = hit.collider.GetComponent<Item>();
            if (hit.collider.CompareTag("Item"))
            {
                // プレイヤーとアイテムの距離を測る
                float distanceToPlayer = Vector3.Distance(_player.position, hit.collider.transform.position);

                if (distanceToPlayer <= _pickupRange)
                {
                    return hit.collider.gameObject; // プレイヤーが近いならOK
                }
            }
        }
    
        return null;
    }
    public GameObject GetDoorUnderMouse()
    {
        Camera cam = _camSwitcher.CurrentCamera;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, _rayDistance))
        {
            if (hit.collider.CompareTag("Door"))
            {
                float distanceToPlayer = Vector3.Distance(_player.position, hit.collider.transform.position);

                if (distanceToPlayer <= _pickupRange)
                {
                    return hit.collider.gameObject;
                }
            }
        }

        return null;
    }


}
