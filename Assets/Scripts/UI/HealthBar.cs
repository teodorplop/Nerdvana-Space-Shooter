using TMPro;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Health health;
    public Transform healthImage;
    public TMP_Text healthText;

    private void Update()
    {
        Vector3 scale = healthImage.localScale;
        scale.x = (float)health.CurrentHealth / health.health;
        healthImage.localScale = scale;

        healthText.text = $"{health.CurrentHealth} / {health.health}";
    }
}
