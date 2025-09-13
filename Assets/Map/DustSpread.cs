using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DustSpread : MonoBehaviour
{
    [SerializeField] GameObject blockPrefab;
    [SerializeField] int blockCount = 30;     // 広がる数
    [SerializeField] float stepSize = 1f;     // 1ステップの大きさ
    [SerializeField] float delay = 5f;        // 生成間隔（秒）

    HashSet<Vector3> spawned = new HashSet<Vector3>();

    void Start()
    {
        StartCoroutine(SpreadFromSelf());
    }

    IEnumerator SpreadFromSelf()
    {
        Vector3 currentPos = transform.position;
        spawned.Add(currentPos);

        Debug.Log($"起点ブロック位置: {currentPos}");

        for (int i = 0; i < blockCount; i++)
        {
            // ランダムにXかZ方向へ
            Vector3 nextPos = currentPos;
            if (Random.value < 0.5f)
                nextPos += new Vector3(Random.value < 0.5f ? stepSize : -stepSize, 0, 0);
            else
                nextPos += new Vector3(0, 0, Random.value < 0.5f ? stepSize : -stepSize);

            // 生成できるか判定
            if (CanSpawnAt(nextPos))
            {
                Instantiate(blockPrefab, nextPos, Quaternion.identity);
                spawned.Add(nextPos);
                Debug.Log($"[{i}] ブロック生成: {nextPos}");
                currentPos = nextPos;
            }
            else
            {
                Debug.Log($"[{i}] 生成失敗（ブロック or 壁あり）: {nextPos}");
            }

            yield return new WaitForSeconds(delay);
        }
    }

    /// <summary>
    /// 生成予定の位置にすでにブロックや壁があるか確認
    /// </summary>
    bool CanSpawnAt(Vector3 pos)
    {
        float halfSize = 0.45f; // ブロックサイズが1なら少し小さめに
        Collider[] hits = Physics.OverlapBox(pos, Vector3.one * halfSize);

        return hits.Length == 0; // 何もなければ生成OK
    }
}
