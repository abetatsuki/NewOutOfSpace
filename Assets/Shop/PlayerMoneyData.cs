using UnityEngine;

interface Moneysum
{
    void AddMoney();
    void RemoveMoney();
}
public class PlayerMoneyData : MonoBehaviour, Moneysum
{
    public static int Money = 0;

    public void AddMoney()
    {
        Money += 1;
    }
    public void RemoveMoney()
    {
        Money -= 1;
    }



}
