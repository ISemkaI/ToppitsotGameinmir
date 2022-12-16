using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.WebCam;

public class RotateMouse : MonoBehaviour
{
    public float SensitivityHor = 9.0f;
    public float SensitivityVert = 9.0f;

    public float MinimumVert = -45.0f;
    public float MaximumVert = 45.0f;

    private float _rotationX = 0;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        _rotationX -= Input.GetAxis("Mouse Y") * SensitivityVert;
        _rotationX = Mathf.Clamp(_rotationX, MinimumVert, MaximumVert);

        float delta = Input.GetAxis("Mouse X") * SensitivityHor;
        float rotationY = transform.localEulerAngles.y + delta;

        transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
    }
}
