using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class PlayerController : MonoBehaviour
{
   
    [SerializeField] private Rigidbody _rb;
     public float speed;
    [SerializeField] private float _turnSpeed = 180;
    private Vector3 _input;

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
        if (_input == Vector3.zero) return;

        if (animationStateController.isTimerRunning == false)
        {
            var rot = Quaternion.LookRotation(_input.ToIso(), Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, _turnSpeed * Time.deltaTime);
        }
        
    }

    private void Move()
    {
        if ( animationStateController.isTimerRunning == false)
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


