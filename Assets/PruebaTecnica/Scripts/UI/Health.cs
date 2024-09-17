using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startHealth = 50f;
    [SerializeField] private HealthUI UI;

    private float currentHealth;

    private void Awake()
    {
        currentHealth = Mathf.Clamp01(startHealth / 100f);
        UI.UpdateHealthUI(instant: true, currentHealth);
    }

    private void OnEnable()
    {
        EventManager.OnDamageTaken += OnHealthChanged;
        EventManager.OnHealed += OnHealthChanged;
    }

    private void OnDisable()
    {
        EventManager.OnDamageTaken -= OnHealthChanged;
        EventManager.OnHealed -= OnHealthChanged;
    }

    private void OnHealthChanged(float healAmount)
    {
        currentHealth = Mathf.Clamp01(currentHealth + (healAmount / 100f));
        UI.UpdateHealthUI(false, currentHealth);
    }
}
