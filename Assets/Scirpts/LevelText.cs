using UnityEngine;
using TMPro; // TextMeshPro‚ğg‚¤ê‡

public class LevelText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI levelText;

    private void Update()
    {
        // PlayerData ‚©‚çŒ»İ‚ÌƒŒƒxƒ‹‚ğæ“¾‚µ‚Ä•\¦
        levelText.text = $"Lv {PlayerData.GetLevel()}";
    }
}
