using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Image fillImage;
    [SerializeField] private float startHealth = 50;

    private void Awake()
    {
        fillImage.fillAmount = startHealth / 100;
    }

    private void Update()
    {
        
    }
}
