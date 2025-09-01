using UnityEngine;

public class ShopController :Moneysum
{
  


    void Start()
    {
        
    }

    public void ShopBuy(Item item)
    {
       
        PlayerMoneyData.Money -= item.ItemData.buymoney;
    }
    public void AddMoney()
    {

    }
    public void RemoveMoney()
    {

    }
}
