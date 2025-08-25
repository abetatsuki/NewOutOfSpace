using UnityEngine;

public class ItemReal : MonoBehaviour
{
    [SerializeField]ItemData item;

    

    public void OnTriggerEnter(Collider other)
    {
        DirtData targetData = other.GetComponent<DirtData>();
        if (targetData == null )return;

        targetData.TakeDamege(item.value);
        Debug.Log($"{other.name}‚Ì‰˜‚ê‚ğ{item.value}Œ¸‚ç‚µ‚½I");
    }
    public void Test()
    {

    }
   

}

