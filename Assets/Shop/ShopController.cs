using UnityEngine;

public class ShopController :Moneysum
{
     
        
    public string[]stringname;
   // [SerializeField]Item item;
  


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
