using UnityEngine;

public class PlayerCarryHandler : MonoBehaviour
{
    [SerializeField] private PlayerInputNotifier _inputNotifier;
    [SerializeField] private PlayerStatusBuffer _statusBuffer;
    [SerializeField] private ItemHolder _itemHolder;
    [SerializeField] private RayCastController _rayCastController;


    private void OnEnable()
    {
        _inputNotifier.OnCarry += HandleCarry;
    }

    private void OnDisable()
    {
        _inputNotifier.OnCarry -= HandleCarry;
    }

    private void HandleCarry()
    {

                _itemHolder.HandlePickupInput(_rayCastController);
  
    }
}
