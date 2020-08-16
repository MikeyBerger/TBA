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
    private bool IsMoving = false;
    public Transform Particles;
    public Transform JetPoint;





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

        if (Movement.x != 0 || Movement.y != 0)
        {
            IsMoving = true;
        }

        if (IsDashing)
        {
            RB.AddForce(new Vector2(Movement.x, Movement.y) * DashPower * Time.deltaTime);
            Instantiate(Particles, JetPoint.position, JetPoint.rotation);
            RB.velocity = Vector2.zero;

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
            //FacingRight = true;
        }
        else if (Movement.x < 0)
        {
            //Flip();
            //transform.localScale = Scale * -1;
            Scale.x = -1;
            //FacingRight = false;
        }
        transform.localScale = Scale;

    }





}

