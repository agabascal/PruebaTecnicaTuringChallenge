using UnityEngine;

public class Potion : MonoBehaviour
{
    [SerializeField] private float healAmount = 15;
    [SerializeField] private AudioClip sfx;

    public void OnPotionUsed()
    {
        EventManager.OnHealed(healAmount);
        SFXManager.Instance.PlayClip(sfx);
    }
}
