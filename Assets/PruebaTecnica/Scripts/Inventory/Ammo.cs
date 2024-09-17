using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] private int ammoAmount = 2;

    public void OnAmmoObtained()
    {
        EventManager.OnAmmoChanged(ammoAmount);
    }
}
