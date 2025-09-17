using UnityEngine;
using UnityEngine.UI;

public class ExpGaugeCon : MonoBehaviour
{
    [SerializeField] private Image fillImage;
    [SerializeField] private float duration = 1f; // âΩïbÇ≈í«è]Ç∑ÇÈÇ©

    private float displayedFill = 0f;
    private float targetFill = 0f;
    private float changeSpeed = 0f;

    private void Start()
    {
        displayedFill = targetFill = PlayerData.GetCount() / 10f;
        fillImage.fillAmount = displayedFill;
    }

    private void Update()
    {
        int count = PlayerData.GetCount();
        float newTarget = Mathf.Clamp01(count / 10f);

        if (Mathf.Abs(newTarget - targetFill) > 0.001f)
        {
            targetFill = newTarget;
            changeSpeed = Mathf.Abs(targetFill - displayedFill) / duration;
        }

        // ääÇÁÇ©Ç…í«è]
        displayedFill = Mathf.MoveTowards(displayedFill, targetFill, changeSpeed * Time.deltaTime);
        fillImage.fillAmount = displayedFill;
    }
}
