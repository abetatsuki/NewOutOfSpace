using UnityEngine;

public class RayCastController : MonoBehaviour
{
    [SerializeField] private CamSwitcher _camSwitcher;
    [SerializeField] private float _rayDistance = 100f;

    public void raycastCon()
    {
        Camera cam = _camSwitcher.CurrentCamera;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray,out RaycastHit hit, _rayDistance))
        {
            Debug.Log($"Raycast hit:{hit.collider.name}");
        }
    }
}
