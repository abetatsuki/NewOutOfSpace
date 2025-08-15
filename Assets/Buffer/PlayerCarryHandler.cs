using UnityEngine;

public class PlayerCarryHandler : MonoBehaviour
{
    [SerializeField] private PlayerInputNotifier _inputNotifier;
    [SerializeField] private PlayerStatusBuffer _statusBuffer;
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

        _rayCastController.RaycastAndPickup();
        // 現在 Carrying 状態なら Raycast でアイテムを取得
        //if (_statusBuffer.CurrentCarryStatus == CarryStatus.Carrying)
        //{
        //    GameObject item = _rayCastController.RaycastForItem();
            
        //    if (item != null)
        //    {
        //        // アイテムを取得した場合の処理（例: ステータスや所持フラグを更新）
        //        Debug.Log($"アイテム取得: {item.name}");
        //        //_statusBuffer.SetCarryingItem(item); // 仮メソッド：所持アイテム更新
        //        _statusBuffer.CarrySetStatus( CarryStatus.Carrying );
        //    }
        //    else
        //    {
        //        Debug.Log("アイテムは見つかりませんでした");
        //        _statusBuffer.CarrySetStatus(CarryStatus.NotCarrying);
        //    }
        //}
        //else
        //{
        //    Debug.Log("キャリー状態ではありません");
        //}
    }
}
