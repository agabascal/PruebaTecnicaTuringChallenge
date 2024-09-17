using UnityEngine;

public class Potion : MonoBehaviour
{
    [SerializeField] private float healAmount = 15;

    public void OnPotionUsed()
    {
        EventManager.OnHealed(healAmount);
    }
}
