using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private ItemData itemdata;
    public ItemData ItemData => itemdata; // 読み取り専用プロパティ
}
