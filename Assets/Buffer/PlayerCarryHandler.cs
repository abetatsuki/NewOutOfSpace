using UnityEngine;

public class PlayerCarryHandler : MonoBehaviour
{
    [SerializeField] private PlayerInputNotifier inputNotifier;

    private void OnEnable()
    {
        inputNotifier.OnCarry += HandleCarry;
    }

    private void OnDisable()
    {
        inputNotifier.OnCarry -= HandleCarry;
    }

    private void HandleCarry()
    {
        Debug.Log("キャリー処理");
        // キャリーアクションの実装
    }
}
