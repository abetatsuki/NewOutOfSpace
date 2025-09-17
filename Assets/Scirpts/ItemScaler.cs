using UnityEngine;

public class ItemScaler : MonoBehaviour
{
    [SerializeField] private Vector3 baseScale = Vector3.one;  // Lv1 ‚Ì‘å‚«‚³
    [SerializeField] private float scalePerLevel = 0.2f;       // ƒŒƒxƒ‹‚²‚Æ‚Ì‘‰Á”{—¦

    private int lastLevel = 0;

    private void Start()
    {
        UpdateScale();
    }

    private void Update()
    {
        int currentLevel = PlayerData.GetLevel();
        if (currentLevel != lastLevel)
        {
            UpdateScale();
        }
    }

    private void UpdateScale()
    {
        int level = PlayerData.GetLevel();
        // Lv1‚È‚çbaseScaleALv2‚È‚çbaseScale + 1’iŠKŠg‘åc‚Æ‚¢‚¤Š´‚¶
        Vector3 newScale = baseScale * (1f + (level - 1) * scalePerLevel);
        transform.localScale = newScale;

        lastLevel = level;
    }
}
