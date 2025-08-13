using UnityEngine;

[CreateAssetMenu(fileName ="NewItem",menuName ="Item/ItemData")]
public class ItemData : ScriptableObject
{
    public string itemName;      // 名前
    public Sprite icon;          // アイコン画像
    public string description;   // 説明文
    public int value;

    public ItemType type;        // アイテムの種類


}

public enum ItemType
{
   Block,
   Backet,

}
