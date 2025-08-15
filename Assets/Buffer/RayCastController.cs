using UnityEngine;

public class RayCastController : MonoBehaviour
{
    [SerializeField] private CamSwitcher _camSwitcher;
    [SerializeField] private float _rayDistance = 100f;

    public GameObject GetItemUnderMouse()
    {
        Camera cam = _camSwitcher.CurrentCamera;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, _rayDistance))
        {
            if (hit.collider.CompareTag("Item"))
            {
                return hit.collider.gameObject;
            }
        }
        return null;
    }
}
