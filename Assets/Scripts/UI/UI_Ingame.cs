using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Ingame : MonoBehaviour
{
    private UI ui;

    [Header("Health Bar")]
    [SerializeField] private float baseWidth = 300f;
    [SerializeField] private RectTransform healthRect;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private TextMeshProUGUI healthText;

    private void Awake()
    {
        ui = GetComponentInParent<UI>();
    }

    private void Start()
    {
        ui.player.health.OnHealthChanged += UpdateHealthBar;
        UpdateHealthBar();
    }

    public void UpdateHealthBar()
    {
        int currentHealth = ui.player.health.GetCurrentHealth();
        float maxHealth = ui.player.entityStats.GetMaxHealth();
        float targetWidth = baseWidth * (maxHealth / currentHealth);
        float currentWidth = healthRect.sizeDelta.x;

        Debug.Log("Max Health: " + maxHealth);

        if (Mathf.Abs(targetWidth - currentWidth) > .1f)
            healthRect.sizeDelta = new Vector2(
                Mathf.Lerp(currentWidth, targetWidth, Time.deltaTime * 5f),
                healthRect.sizeDelta.y
            );

        healthText.text = $"{currentHealth}/{maxHealth}";
        healthSlider.value = ui.player.health.GetHealthPercent();
    }
}
