using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private ParticleSystem healPSystem;
    [SerializeField] private ParticleSystem damagePSystem;

    private void OnEnable()
    {
        EventManager.OnDamageTaken += OnDamaged;
        EventManager.OnHealed += OnHealed;
    }

    private void OnDisable()
    {
        EventManager.OnDamageTaken -= OnDamaged;
        EventManager.OnHealed -= OnHealed;
    }

    private void OnDamaged(float _)
    {
        if (damagePSystem)
        {
            damagePSystem?.gameObject.SetActive(true);
            damagePSystem?.Play();
        }
    }

    private void OnHealed(float _)
    {
        if (healPSystem != null)
        {
            healPSystem.gameObject.SetActive(true);
            healPSystem.Play();
        }
    }
}
