using UnityEngine;
using UnityEngine.InputSystem;

public class InputServiceStandalone : IInputService
{
    private Vector3 _inputVector = Vector3.zero;
    private Vector3 _mouseMovement = Vector3.zero;

    public Vector3 MousePosition => Input.mousePosition;

    public IInputActionCollection2 InputActionsBase
    {
        get => _inputActions;
        set
        {
            _inputActions = value as StandaloneInput;
        }
    }

    private StandaloneInput _inputActions;

    public InputServiceStandalone()
    {
        _inputActions = new StandaloneInput();
    }

    public Vector3 GetInputVector()
    {
        _inputVector.x = Input.GetAxis("Horizontal");  // _inputActions.Standalone.MouseHorizontal.ReadValue<float>();// Input.GetAxis("Horizontal");
        _inputVector.z = Input.GetAxis("Vertical");  //_inputActions.Standalone.MouseVertical.ReadValue<float>(); //Input.GetAxis("Vertical");

        return _inputVector.normalized;
    }

    public bool GetLeftShootButton()
        => Input.GetMouseButtonDown(0);

    public bool GetRightShootButton()
        => Input.GetMouseButtonDown(1);

    public bool GetJumpButton()
        => true;//Input.GetKeyDown(KeyCode.Space);

    public Vector3 GetMouseMovement()
    {
        _mouseMovement.x = Input.GetAxis("Mouse Y");  //_inputActions.Standalone.MouseHorizontal.ReadValue<float>();// Input.GetAxis("Horizontal");
        _mouseMovement.z = Input.GetAxis("Mouse X");  //_inputActions.Standalone.MouseVertical.ReadValue<float>(); //Input.GetAxis("Vertical");

        return _mouseMovement;
    }
}
