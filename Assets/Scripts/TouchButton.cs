using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TouchButton : XRBaseInteractable
{
    [Header("Button Data")]
    [SerializeField] private int _buttonNumber;
    [SerializeField] private Material _buttonPressedMaterial;
    private Material _originalMaterial;
    private Renderer _renderer;
    
    public delegate void EventButtonPress(int buttonNumber);
    public event EventButtonPress OnButtonPress;

    protected override void Awake()
    {
        base.Awake();
        _renderer = GetComponent<Renderer>();
        _originalMaterial = _renderer.material;
    }

    protected override void OnHoverEntered(HoverEnterEventArgs args)
    {
        base.OnHoverEntered(args);
        PressButton();
    }

    protected override void OnHoverExited(HoverExitEventArgs args)
    {
        base.OnHoverExited(args);
        ReleaseButton();
    }

    private void PressButton()
    {
        _renderer.material = _buttonPressedMaterial;
        OnButtonPress?.Invoke(_buttonNumber);
    }

    private void ReleaseButton()
    {
        _renderer.material = _originalMaterial;
    }

}
