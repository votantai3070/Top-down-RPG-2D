using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Ingame : MonoBehaviour
{
    private UI ui;

    [Header("Health Bar")]
    [SerializeField] private Slider healthBar;
    [SerializeField] private RectTransform healthRect;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private float baseWidth = 300f;

    [Header("Exp Bar")]
    [SerializeField] private Slider expBar;
    [SerializeField] private TextMeshProUGUI expText;
    [SerializeField] private TextMeshProUGUI levelText;

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
        if (healthBar == null) return;

        int currentHealth = ui.player.health.GetCurrentHealth();
        float maxHealth = ui.player.stats.GetMaxHealth();
        float targetWidth = baseWidth * (maxHealth / currentHealth);
        float currentWidth = healthRect.sizeDelta.x;

        if (Mathf.Abs(targetWidth - currentWidth) > .1f)
            healthRect.sizeDelta = new Vector2(
                Mathf.Lerp(currentWidth, targetWidth, Time.deltaTime * 5f),
                healthRect.sizeDelta.y
            );

        healthText.text = $"{currentHealth}/{maxHealth}";
        healthBar.value = ui.player.health.GetHealthPercent();
    }

    public void UpdateExpBar(float current, float max)
    {
        expBar.value = current / max;

        Debug.Log("exp amount: " + current);
        if (expText != null)
            expText.text = $"{Mathf.FloorToInt(current)} / {Mathf.FloorToInt(max)}";
    }

    public void UpdateLevelText(int level)
    {
        if (levelText != null)
            levelText.text = $"Lv. {level}";
    }

    public void ShowLevelUpEffect(int newLevel)
    {
        // animation || effect
        Debug.Log($"[UI] Level Up → {newLevel}!");
    }
}
