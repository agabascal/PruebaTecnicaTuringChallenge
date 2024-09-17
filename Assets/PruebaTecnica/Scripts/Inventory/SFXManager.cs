using UnityEngine;

public class SFXManager : MonoBehaviour
{
    private AudioSource audioSource;

    public static SFXManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayClip(AudioClip sfx)
    {
        audioSource.clip = sfx;
        audioSource.Play();
    }
}
