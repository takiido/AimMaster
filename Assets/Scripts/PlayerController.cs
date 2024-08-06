// Copyright takiido. All Rights Reserved

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // References
    public Transform pitchTarget;
    public Transform yawTarget;
    
    // Settings
    public float sens;
    public float conversion;
    
    // Input
    private Vector2 _lookInput;
    
    private void Update()
    {
        // Preventing player to break the clamping bounds
        float epsilon = 0.01f;
        
        _lookInput.x %= 360.0f;
        _lookInput.y = Mathf.Clamp(_lookInput.y, -90.0f + epsilon, 90.0f - epsilon);
        
        pitchTarget.localRotation =
            Quaternion.Euler(-_lookInput.y, pitchTarget.localEulerAngles.y, pitchTarget.localEulerAngles.z);
        yawTarget.localRotation =
            Quaternion.Euler(yawTarget.localEulerAngles.x, _lookInput.x, yawTarget.localEulerAngles.z);
    }

    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    private void Shoot()
    {
        Debug.Log("Shot!");
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        _lookInput += context.performed ? context.ReadValue<Vector2>() * sens * conversion : Vector2.zero;
    }
    
    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed) Shoot();
    }
}
