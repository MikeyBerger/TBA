using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Vector2 RotationVector;
    private Rigidbody2D RB;
    public float TurnSpeed;
    public float DashSpeed;
    private bool IsDashing;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
    }

    public void OnRotation(InputAction.CallbackContext ctx)
    {
        RotationVector = ctx.ReadValue<Vector2>();
    }

    public void OnDash(InputAction.CallbackContext ctx)
    {
        if(ctx.phase == InputActionPhase.Performed)
        {
            RB.AddForce(RotationVector * DashSpeed * Time.deltaTime);
        }
    }
}
