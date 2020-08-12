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
    public bool IsDashing = false;
    public float StopDash;

    IEnumerator StopDashing()
    {
        yield return new WaitForSeconds(StopDash);
        IsDashing = false;
    }


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
        #region Junk
        /*
        //RB.AddForce(new Vector2(RotationVector.x, RotationVector.y) * DashSpeed * Time.deltaTime);

        //RotZ = RotationVector.x * TurnSpeed * Time.deltaTime;
        //transform.Rotate(Vector3.forward * RotZ);
        //RotationVector = new Vector3(0, 0, 0);
        //RB.MoveRotation(new Vector3(RotationVector.x, 0, RotationVector.y));
#pragma warning disable format
        //transform.rotation = Quaternion.LookRotation(new Vector3(RotationVector.x, 0, RotationVector.y));
#pragma warning restore format




        //Vector2 EulerVec = new Vector2(RotZ, RotX);
        //Vector3 PlayerRot = new Vector3(RotX, 0, RotZ);
        //Quaternion Target = Quaternion.Euler(0, 0, EulerVec);

        #region Some Random Shit From the Web
        /*
        Quaternion PlayerRot = transform.rotation;
        float Z = PlayerRot.z;
        Z -= RotationVector.x * TurnSpeed * Time.deltaTime;

        PlayerRot = Quaternion.Euler(0, 0, Z);

        transform.rotation = PlayerRot;

        Vector3 PlayerPos = transform.position;

        Vector3 Velocity = new Vector3(0, RotationVector.y * TurnSpeed * Time.deltaTime, 0);

        PlayerPos += PlayerRot * Velocity;

        transform.position = PlayerPos;
        
        #endregion
        */
        #endregion

        if (RotationVector.x == 0 && RotationVector.y == 0)
        {
            RotationVector = Vector2.up;
        }

        transform.up = new Vector2(RotationVector.x, RotationVector.y);

        if (IsDashing)
        {
            RB.AddForce(RotationVector * DashSpeed * Time.deltaTime);
            //StartCoroutine(StopDashing());
            IsDashing = false;
        }

        if (!IsDashing)
        {
            transform.position = Vector2.zero;
        }

        //transform.rotation = Quaternion.Slerp(transform.rotation, PlayerRot * Angle, Time.deltaTime * TurnSpeed);
    }

    public void OnRotation(InputAction.CallbackContext ctx)
    {
        RotationVector = ctx.ReadValue<Vector2>();
    }

    public void OnDash(InputAction.CallbackContext ctx)
    {
        if (ctx.phase == InputActionPhase.Performed)
        {
            IsDashing = true;
        }
    }
}
