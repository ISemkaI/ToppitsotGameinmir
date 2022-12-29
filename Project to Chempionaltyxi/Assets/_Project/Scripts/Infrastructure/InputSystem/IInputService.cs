using UnityEngine;
using UnityEngine.InputSystem;

public interface IInputService : IService
{
    public IInputActionCollection2 InputActionsBase { get; set; }

    Vector3 GetInputVector();
    bool GetLeftShootButton();
    bool GetRightShootButton();
    bool GetJumpButton();
    Vector3 GetMouseMovement();
}