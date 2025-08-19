using UnityEngine;

public class ItemReal : MonoBehaviour
{

    public int cleanpoint = 1;

    public void OnTriggerEnter(Collider other)
    {
        DirtData targetData = other.GetComponent<DirtData>();
        if (targetData == null )return;

        targetData.TakeDamege(cleanpoint);
        Debug.Log($"{other.name}‚Ì‰˜‚ê‚ğ{cleanpoint}Œ¸‚ç‚µ‚½I");
    }
    public void Test()
    {

    }
   

}

