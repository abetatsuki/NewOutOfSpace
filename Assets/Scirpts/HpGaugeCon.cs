using UnityEngine;
using UnityEngine.UI;

public class HpGaugeCon : MonoBehaviour
{
    Image image;
    float displayedFill = 1f; // 表示用のゲージ割合
    float targetFill = 1f;    // 本来のゲージ割合

    [SerializeField] float duration = 2f; // 変化にかける秒数
    float changeSpeed; // 秒間に変化するスピード

    private void Start()
    {
        image = GetComponent<Image>();

        int hp = PlayerData.GetHp();
        int maxHp = PlayerData.GetMaxHp();

        displayedFill = targetFill = (float)hp / maxHp;
        image.fillAmount = displayedFill;
    }

    private void Update()
    {
        int currentHp = PlayerData.GetHp();
        int maxHp = PlayerData.GetMaxHp();

        // 本来のHP割合
        float newTarget = (float)currentHp / maxHp;

        // HPが変わったら新しい目標値に更新
        if (Mathf.Abs(newTarget - targetFill) > 0.001f)
        {
            targetFill = newTarget;
            changeSpeed = Mathf.Abs(targetFill - displayedFill) / duration;
        }

        // だんだん近づける（常に2秒で到達）
        displayedFill = Mathf.MoveTowards(displayedFill, targetFill, changeSpeed * Time.deltaTime);

        image.fillAmount = displayedFill;
    }
}
