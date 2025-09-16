using UnityEngine;

public class DustCount : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        PlayerData.PlusCount();
        Destroy(gameObject);
    }
    
}
