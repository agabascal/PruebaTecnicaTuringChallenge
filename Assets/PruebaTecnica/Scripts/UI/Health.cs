using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Health : MonoBehaviour
{
    [SerializeField] private Image fillImage;
    [SerializeField] private float startHealth = 50f;
    [SerializeField] private ParticleSystem healPSystem;
    [SerializeField] private ParticleSystem damagePSystem;

    private float currentHealth;

    private void Awake()
    {
        currentHealth = Mathf.Clamp01(startHealth / 100f);
        UpdateHealthUI(instant: true);
    }

    private void OnEnable()
    {
        Potion.Grabbed += OnHealed;
        Grenade.GrenadeUsed += OnDamaged;
    }

    private void OnDisable()
    {
        Potion.Grabbed -= OnHealed;
        Grenade.GrenadeUsed -= OnDamaged;
    }

    private void OnHealed(float healAmount)
    {
        currentHealth = Mathf.Clamp01(currentHealth + (healAmount / 100f));
        healPSystem?.gameObject.SetActive(true);
        UpdateHealthUI(false);
    }

    private void OnDamaged(float damageAmount)
    {
        currentHealth = Mathf.Clamp01(currentHealth + (damageAmount / 100f));
        damagePSystem?.gameObject.SetActive(true);
        UpdateHealthUI(true);
    }

    private void UpdateHealthUI(bool instant = false)
    {
        if (instant)
        {
            fillImage.fillAmount = currentHealth;
        }
        else
        {
            fillImage.DOFillAmount(currentHealth, 0.5f).SetEase(Ease.OutQuad);
        }
    }
}
