using UnityEngine;

public interface IInputService : IService
{
    Vector3 GetInputVector();
    bool GetShootButton();
    bool GetJumpButton();
    Vector3 GetMouseMovement();
}