using UnityEngine;

public class ItemCon : MonoBehaviour
{
    [SerializeField]PlayerInputNotifier InputNotifier;
    private void OnEnable()
    {
        InputNotifier.OnCarry += Test1;
    }

    private void Test1()
    {

    }
}
