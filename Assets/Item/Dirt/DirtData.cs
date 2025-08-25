using UnityEngine;

public class DirtData : MonoBehaviour
{
    [SerializeField] int POINT = 10;
   
    public void TakeDamege(int amount)
    {
        POINT -= amount;
        if (POINT < 0)
        {
            POINT = 0;
            Destroy(gameObject);
        }
    }

}
