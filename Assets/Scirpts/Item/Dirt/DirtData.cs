using UnityEngine;

public class DirtData : MonoBehaviour,IDamageble
{
    public int POINT = 10;
   
    public void TakeDamage(int amount)
    {
        POINT -= amount;
        if (POINT < 0)
        {
            POINT = 0;
            Destroy(gameObject);
        }
    }

}
