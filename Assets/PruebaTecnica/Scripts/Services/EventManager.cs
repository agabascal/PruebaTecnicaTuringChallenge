using System;

/// <summary>
/// Event bus that triggers the events following an observer pattern
/// </summary>
public static class EventManager
{
    public static Action<float> OnDamageTaken;
    public static Action<float> OnHealed;
    public static Action<int> OnAmmoChanged;

    public static void DealDamage(float amount)
    {
        OnDamageTaken?.Invoke(amount);
    }

    public static void Heal(float amount)
    {
        OnHealed?.Invoke(amount);
    }

    public static void IncreaseAmmo(int amount)
    {
        OnAmmoChanged?.Invoke(amount);
    }
}