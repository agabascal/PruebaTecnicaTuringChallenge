using DG.Tweening;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class InteractableHoverAndRotate : MonoBehaviour
{
    [SerializeField] private float yOffset = 0.75f;

    private XRGrabInteractable interactable;


    private void Awake()
    {
        interactable = GetComponent<XRGrabInteractable>();

        if (!interactable.isSelected)
        {
            StartAnimation();
        }
    }

    private void OnEnable()
    {
        interactable.selectEntered.AddListener(OnSelectEnter);
        interactable.selectExited.AddListener(OnSelectExit);
        StartAnimation();
    }

    private void OnDisable()
    {
        interactable.selectEntered.RemoveListener(OnSelectEnter);
        interactable.selectExited.RemoveListener(OnSelectExit);
    }

    private void OnSelectExit(SelectExitEventArgs _) => StartAnimation();

    private void OnSelectEnter(SelectEnterEventArgs _) => StopAnimation();

    private void StartAnimation()
    {
        transform.DOLocalRotate(new Vector3(0, 360, 0), 5f, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Incremental).SetEase(Ease.Linear);
        transform.DOMoveY(transform.position.y + yOffset, 1f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InQuad);
    }

    private void StopAnimation()
    {
        DOTween.Kill(transform);
    }

}