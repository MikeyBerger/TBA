using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerV2 : MonoBehaviour
{
    private Vector2 Movement;
    private bool IsDashing = false;
    private Rigidbody2D RB;
    public float Speed;
    public float DashPower;
    public bool FacingRight;
    

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
        RB.velocity = new Vector2(Movement.x, Movement.y) * Speed * Time.deltaTime;

        if (IsDashing)
        {
            RB.AddForce(new Vector2(Movement.x, Movement.y) * DashPower * Time.deltaTime);
            IsDashing = false;
        }

        Vector3 Scale;
        Scale = transform.localScale;

        if (Movement.x > 0)
        {
            //transform.localRotation = transform.localRotation;
            //Flip();
            //transform.localScale = Scale * -1;
            Scale.x = 1;
        }
        else if (Movement.x < 0)
        {
            //Flip();
            //transform.localScale = Scale * -1;
            Scale.x = -1;
        }
        transform.localScale = Scale;
    }

    void Flip()
    {
        FacingRight = !FacingRight;
        transform.Rotate(Vector3.up * 360);
    }


    #region InputFunctions
    public void OnMove(InputAction.CallbackContext ctx)
    {
        Movement = ctx.ReadValue<Vector2>();
    }

    public void OnDash(InputAction.CallbackContext ctx)
    {
        if (ctx.phase == InputActionPhase.Performed)
        {
            IsDashing = true;
        }
    }
    #endregion
}
