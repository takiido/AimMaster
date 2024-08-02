// Copyright takiido. All Rights Reserved

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Camera _cam;
    private Vector2 _lookInput;

    private void Start()
    {
        _cam = GetComponentInChildren<Camera>();
    }
    
    private void Update()
    {
        _lookInput.y = Mathf.Clamp(_lookInput.y, -90.0f, 90.0f);
        Quaternion xQuat = Quaternion.AngleAxis(_lookInput.x, Vector3.up);
        Quaternion yQuat = Quaternion.AngleAxis(_lookInput.y, Vector3.left);

        _cam.transform.localRotation = xQuat * yQuat;
    }
    
    private void Shoot()
    {
        Debug.Log("Shot!");
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        _lookInput += context.performed ? context.ReadValue<Vector2>() : Vector2.zero;
    }
    
    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed) Shoot();
    }
}
