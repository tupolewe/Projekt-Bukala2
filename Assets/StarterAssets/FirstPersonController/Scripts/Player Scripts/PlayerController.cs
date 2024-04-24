using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class PlayerController : MonoBehaviour
{

    [SerializeField] private Rigidbody _rb;
    public float speed;
    public float turnSpeed = 120;
    private Vector3 _input;


    //public float horizontalInput = Input.GetAxis("Horizontal");
    //public float verticalInput = Input.GetAxis("Vertical");
    //public Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);


    public animationStateController animationStateController;

    private void Start()
    {

    }

    private void Update()
    {
        GatherInput();
        Look();


    }

    private void FixedUpdate()
    {
        Move();
    }

    private void GatherInput()
    {
        if (animationStateController.isTimerRunning == false)
        {
            _input = new Vector3(Input.GetAxisRaw("Vertical") * (-1), 0, Input.GetAxisRaw("Horizontal"));
        }

    }

    private void Look()
    {
        Vector3 movementDirection = new Vector3(Input.GetAxisRaw("Vertical") * (-1), 0, Input.GetAxisRaw("Horizontal"));
        movementDirection.Normalize();

        transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);

        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, turnSpeed * Time.deltaTime);
        }

    }

    private void Move()
    {
        if (animationStateController.isTimerRunning == false && animationStateController.isHandlingRunning == false)
        {
            _rb.MovePosition(transform.position + transform.forward * _input.normalized.magnitude * speed * Time.deltaTime);
        }

    }



}



public static class Helpers
{
    private static Matrix4x4 _isoMatrix = Matrix4x4.Rotate(Quaternion.Euler(0, 0, 0));
    public static Vector3 ToIso(this Vector3 input) => _isoMatrix.MultiplyPoint3x4(input);


}




