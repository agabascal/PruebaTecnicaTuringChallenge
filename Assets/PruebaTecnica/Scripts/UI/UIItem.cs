using UnityEngine;

public class UIItem : MonoBehaviour
{
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private GameObject useButton;
    [SerializeField] private GameObject discardButton;

    private bool isTrash;
    public bool IsTrash => isTrash;

    private void Awake()
    {
        optionsPanel.SetActive(false);
    }
    public void SetupItemAsTrash(bool isTrash)
    {
        this.isTrash = isTrash;
        useButton.SetActive(!isTrash);
    }
}
