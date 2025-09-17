using UnityEngine;
using UnityEngine.UI;

public class HpGaugeCon : MonoBehaviour
{
    Image image;
    int hp;

    private void Start()
    {
        image = GetComponent<Image>();
    }

    private void Update()
    {
        int currentHp = PlayerData.GetHp();
        int maxHp = PlayerData.GetMaxHp();

        if (hp != currentHp)
        {
            hp = currentHp;
            // float にキャストして割合を計算
            image.fillAmount = (float)hp / maxHp;
        }
    }
}
