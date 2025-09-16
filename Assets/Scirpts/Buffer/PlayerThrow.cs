using UnityEngine;

public class PlayerThrow : MonoBehaviour
{
    [SerializeField]PlayerInputNotifier notifier;
    [SerializeField] Itemp itemp;
    private void OnEnable()
    {
        notifier.OnThrow += Test1;
    }
    private void OnDisable()
    {
        notifier.OnThrow -= Test1;
    }
    private void Test1()
    {
       
        itemp.ThrowItem();
    }

}
