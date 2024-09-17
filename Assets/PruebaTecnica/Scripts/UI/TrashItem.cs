using UnityEngine;

public class TrashItem : MonoBehaviour, IInventoryItem
{
    [SerializeField] private Sprite trashSprite;
    [SerializeField] private AudioClip trashSFX;

    private AudioSource audioSource;
    public Sprite ItemSprite => trashSprite;
    public AudioClip ItemSFX => trashSFX;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = trashSFX;
    }
    public void UseItem()
    {
        Debug.Log("Cannot use trash.");
    }

    public void RemoveItem()
    {
        Debug.Log("Trash removed.");
        audioSource.Play();
        Destroy(gameObject, 2f);
    }
}
