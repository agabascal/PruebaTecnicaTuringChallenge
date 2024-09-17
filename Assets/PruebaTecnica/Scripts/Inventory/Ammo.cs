using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] private int ammoAmount = 2;
    [SerializeField] private AudioClip sfx;

    public void OnAmmoObtained()
    {
        EventManager.OnAmmoChanged(ammoAmount);
        SFXManager.Instance.PlayClip(sfx);
    }
}
