using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour
{
   enum TargetShopScene
    {
        ShopOpen,
        ShopBuy,
        ShopSell,


    }
    [SerializeField] TargetShopScene targetShopScene;
    Button Button;

    private void Start()
    {
        Button = GetComponent<Button>();
        Button.onClick.RemoveAllListeners();
        switch (targetShopScene)
        {
            case TargetShopScene.ShopOpen:
                Button.onClick.AddListener(() => Debug.Log("Open"));
                break;
                case TargetShopScene.ShopBuy:
                Button.onClick.AddListener(() => Debug.Log("Buy"));
                break;
                case TargetShopScene.ShopSell:
                Button.onClick.AddListener(() => Debug.Log("Sell"));
                break;
        }
    }
}
