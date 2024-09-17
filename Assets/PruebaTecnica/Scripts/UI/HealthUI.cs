using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Image fillImage;

    public void UpdateHealthUI(bool instant, float currentHealth)
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
