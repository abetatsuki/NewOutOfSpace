using UnityEngine;

public class ItemCon : MonoBehaviour
{
    [SerializeField]private ItemData _item;
    [SerializeField]private PlayerInputNotifier _playerInputNotifier;
    [SerializeField]private PlayerStatusBuffer _playerStatusBuffer;
    

    private void OnEnable()
    {
     
        _playerStatusBuffer.OnCarryStatusChanged += OnCarryStatusChanged;
    }
    private void OnDisable()
    {

        _playerStatusBuffer.OnCarryStatusChanged -= OnCarryStatusChanged;
    }
    
    public void OnCarryStatusChanged(CarryStatus carrystatus)
    {
        if (CarryStatus.NotCarrying == carrystatus) return;
        if (CarryStatus.Carrying == carrystatus) 
        {
            
        }
    }

}
