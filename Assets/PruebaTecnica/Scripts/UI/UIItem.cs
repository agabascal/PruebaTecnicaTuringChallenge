using UnityEngine;

public class UIItem : MonoBehaviour
{
    [SerializeField] private GameObject optionsPanel;

    private void Awake()
    {
        optionsPanel.SetActive(false);
    }
}
