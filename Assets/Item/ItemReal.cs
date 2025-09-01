using UnityEngine;

public class ItemReal : MonoBehaviour
{
    [SerializeField]ItemData item;

    

    public void OnTriggerEnter(Collider other)
    {
        DirtData targetData = other.GetComponent<DirtData>();
        if (targetData == null )return;

        targetData.TakeDamage(item.Damage);
        Debug.Log($"{other.name}のクリーン{item.Damage}ダメージ与えた！");
    }
    public void Test()
    {

    }
   

}

