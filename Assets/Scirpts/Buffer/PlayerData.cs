
using UnityEngine;
public static class PlayerData
{
    static int Level = 1;
    static int LevelCount = 0;
    static int PlayerHp = 3;
    static int MaxHp = 3; // ‰ŠúÅ‘åHP‚àŠÇ—

    public static void PlusCount()
    {
        LevelCount++;
        PlayerHp = Mathf.Max(PlayerHp - 1, 0);
        if (LevelCount >= 10)
        {
            LevelUp();
            LevelCount = 0;
        }
    }

    static void LevelUp()
    {
        Level++;

        int hpIncrease = 0;
        switch (Level)
        {
            case 2: hpIncrease = 1; break;
            case 3: hpIncrease = 2; break;
            case 4: hpIncrease = 3; break;
            default: hpIncrease = 1; break;
        }

        MaxHp += hpIncrease;
        PlayerHp += hpIncrease;

        // ‚à‚µãŒÀ‚ð’´‚¦‚½‚çÅ‘å’l‚É—}‚¦‚é
        if (PlayerHp > MaxHp) PlayerHp = MaxHp;

        Debug.Log($"Level {Level} ‚Éã‚ª‚Á‚½I HP:{PlayerHp}/{MaxHp}");
    }


    public static int GetLevel() => Level;
    public static int GetHp() => PlayerHp;
    public static int GetMaxHp() => MaxHp;
    public static int GetCount() => LevelCount;
}
