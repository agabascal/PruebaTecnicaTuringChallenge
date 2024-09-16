using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Health : MonoBehaviour
{
    [SerializeField] private Image fillImage;
    [SerializeField] private float startHealth = 50f;

    private float currentHealth;

    private void Awake()
    {
        currentHealth = Mathf.Clamp01(startHealth / 100f);
        UpdateHealthUI(instant: true);
    }

    private void OnEnable()
    {
        Potion.Grabbed += OnPotionUsed;
        Grenade.GrenadeGrabbed += OnGrenadeGrabbed;
    }

    private void OnDisable()
    {
        Potion.Grabbed -= OnPotionUsed;
        Grenade.GrenadeGrabbed -= OnGrenadeGrabbed;
    }

    private void OnPotionUsed(float healAmount)
    {
        currentHealth = Mathf.Clamp01(currentHealth + (healAmount / 100f));
        UpdateHealthUI(false);
    }

    private void OnGrenadeGrabbed(float damageAmount)
    {
        currentHealth = Mathf.Clamp01(currentHealth + (damageAmount / 100f));
        UpdateHealthUI(true);
    }

    private void UpdateHealthUI(bool instant = false)
    {
        Debug.Log(currentHealth);
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
