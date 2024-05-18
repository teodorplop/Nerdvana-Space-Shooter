using TMPro;
using UnityEngine;

/// <summary>
/// Simple health bar component
/// </summary>
public class HealthBar : MonoBehaviour
{
	public Health health;
	public Transform healthImage;
	public TMP_Text healthText;

	private void Update()
	{
		// Updates scale per frame
		Vector3 scale = healthImage.localScale;
		scale.x = (float)health.CurrentHealth / health.health;
		healthImage.localScale = scale;

		healthText.text = $"{health.CurrentHealth} / {health.health}";
	}
}
