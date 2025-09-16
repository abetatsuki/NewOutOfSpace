using UnityEngine;

public class Itemp : MonoBehaviour
{
    [SerializeField] private Transform heldItemParent; // アイテムを持つ位置（手のTransformなど）
    [SerializeField] private float throwForce = 10f;

    // プレイヤーがアイテムを持っているかどうか
    public bool HasItem()
    {
        return heldItemParent.childCount > 0;
    }

    // アイテムを投げる処理
    public void ThrowItem()
    {
        if (!HasItem())
        {
            Debug.Log("アイテムを持っていないので投げられません");
            return;
        }

        // 1. 最初の子オブジェクトを取得
        Transform child = heldItemParent.GetChild(0);

        // 2. 親から切り離す
        child.SetParent(null);

        // 3. Rigidbodyを取得（無ければ追加）
        Rigidbody rb = child.GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = child.gameObject.AddComponent<Rigidbody>();
        }
       rb.isKinematic = false;
        // 4. 前方向に力を加える
        rb.AddForce(transform.forward * throwForce, ForceMode.Impulse);

        Debug.Log("アイテムを投げた！");
    }
}
