using UnityEngine;
using UnityEngine.UIElements;

interface IUseItem //左クリックで使用できるitem
{
    void Use();
}
interface IPutItem //置くだけで効果があるitem
{
    void Put(Vector3 point);
}
interface IDamageble
{
    void TakeDamage(int point);
}

public class IItem : IUseItem, IPutItem
{
    public void Use()
    {
        Debug.Log("UseItem");
    }
    public void Put(Vector3 point)
    {
       string message = point.ToString();
        Debug.Log(message);
    }
}
