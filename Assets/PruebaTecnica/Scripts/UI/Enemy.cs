using UnityEngine;
using DG.Tweening;

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
            Jump();
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

    private void Jump()
    {
        var randomJumpValue = new Vector3(Random.Range(-5,5),0,Random.Range(-5,5));
        transform.DOJump(transform.position + randomJumpValue, 3f, 1 , 1f).SetEase(Ease.OutQuad);
    }
}
