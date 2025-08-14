using UnityEngine;

public class RayCastHandler : MonoBehaviour
{
    [SerializeField] private CamSwitcher camSwitcher;
    [SerializeField] private float rayDistance = 100f;

    private void raycast()
    {
        Camera cam = camSwitcher.CurrentCamera;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray,out RaycastHit hit, rayDistance))
        {
            Debug.Log($"Raycast hit:{hit.collider.name}");
        }
    }
}
