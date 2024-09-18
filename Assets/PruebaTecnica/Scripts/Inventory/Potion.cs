using UnityEngine;

public class Potion : MonoBehaviour
{
    [SerializeField] private float healAmount = 15;
    [SerializeField] private AudioClip sfx;

    public float HealAmount => healAmount; 
    public AudioClip Sfx => sfx; 
}

public class PotionUsageCommand : IItemUsageCommand
{
    private readonly Potion potion;

    public PotionUsageCommand(Potion potion)
    {
        this.potion = potion;
    }

    public void Execute()
    {
        EventManager.Heal(potion.HealAmount);
        SFXManager.Instance.PlayClip(potion.Sfx);
    }
}
