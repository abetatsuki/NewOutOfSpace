using System.Drawing;
using UnityEngine;

public class ItemReal : MonoBehaviour
{
    [SerializeField]ItemData item;
    private int dirtpoint;
    

    public void OnTriggerEnter(Collider other)
    {
        DirtData targetData = other.GetComponent<DirtData>();
        if (targetData == null )return;
        dirtpoint = targetData.POINT;
        targetData.TakeDamage(item.Damage);
        Debug.Log($"{other.name}のクリーン{item.Damage}ダメージ与えた！");
    }
    public void Test()
    {
        Debug.Log(item.name+"をもっている");
    }
   

}

