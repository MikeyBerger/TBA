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
    public float RotZ;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //RB.AddForce(new Vector2(RotationVector.x, RotationVector.y) * DashSpeed * Time.deltaTime);

        RotZ = RotationVector.x * TurnSpeed * Time.deltaTime;
        transform.Rotate(Vector3.forward * RotZ);
        //RotationVector = new Vector3(0, 0, 0);
        //RB.MoveRotation(new Vector3(RotationVector.x, 0, RotationVector.y));
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
