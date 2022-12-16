using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMouse : MonoBehaviour
{
    public enum RotationAxes{
        MouseXandY = 0
    }
    public RotationAxes axes = RotationAxes.MouseXandY;

    public float sensitivityHor = 9.0f;
    public float sensitivityVert = 9.0f;

    public float minimumVert = -45.0f;
    public float maximumVert = 45.0f;

    private float _rotationX = 0;




    void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        if(body != null)
        body.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
        _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);

        float delta = Input.GetAxis("Mouse X") * sensitivityHor;
        float rotationY = transform.localEulerAngles.y + delta;

        transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
