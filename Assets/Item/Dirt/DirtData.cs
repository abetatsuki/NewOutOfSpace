using UnityEngine;

public class DirtData : MonoBehaviour
{
    public int POINT = 100;
    public void TakeDamege(int amount)
    {
        POINT -= amount;
        if (POINT < 0) POINT = 0;
    }
}
