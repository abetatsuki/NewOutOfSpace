using UnityEngine;

public static class PlayerData
{
    // プレイヤーのデータ
    static int Level = 1;
    static int LevelCount = 0;
    static int PlayerHp = 3;

    /// <summary>
    /// 敵を倒したときに呼ぶ
    /// </summary>
    public static void PlusCount()
    {
        LevelCount++;
        Debug.Log("HIIIIIIT");
        if (LevelCount >= 10) // 10体倒したらレベルアップ
        {
            LevelUp();
            LevelCount = 0;
        }
    }

    /// <summary>
    /// レベルアップ時の処理
    /// </summary>
    static void LevelUp()
    {
        Level++;

        // レベルに応じて HP を増やす
        switch (Level)
        {
            case 2:
                PlayerHp += 1;
                break;
            case 3:
                PlayerHp += 2;
                break;
            case 4:
                PlayerHp += 3;
                break;
            default:
                PlayerHp += 1; // それ以降は少しずつ増やす
                break;
        }

        Debug.Log($"Level {Level} に上がった！ HP:{PlayerHp}");
    }

    // 外から現在のデータを参照できるようにするプロパティ
    public static int GetLevel() => Level;
    public static int GetHp() => PlayerHp;
    public static int GetCount() => LevelCount;
}
