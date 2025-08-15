using UnityEngine;

public class RaycastHandler : MonoBehaviour
{
    [SerializeField]private RayCastController _rayCastCon;
    [SerializeField]private PlayerInputNotifier _playerInputNotifier;
    private void OnEnable()
    {
        _playerInputNotifier.OnCarry += HandleRaycast;
    }
    private void OnDisable()
    {
      _playerInputNotifier.OnCarry -= HandleRaycast;
    }
    private void HandleRaycast()
    {
       // _rayCastCon.raycastCon();
    }
}
