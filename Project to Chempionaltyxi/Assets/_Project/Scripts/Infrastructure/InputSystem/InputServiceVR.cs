using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputServiceVR : IInputService
{
    public IInputActionCollection2 InputActionsBase { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public Vector3 GetInputVector()
    {
        throw new NotImplementedException();
    }

    public bool GetJumpButton()
    {
        throw new NotImplementedException();
    }

    public Vector3 GetMouseMovement()
    {
        throw new NotImplementedException();
    }

    public bool GetLeftShootButton()
    {
        throw new NotImplementedException();
    }

    public bool GetRightShootButton()
    {
        throw new NotImplementedException();
    }
}