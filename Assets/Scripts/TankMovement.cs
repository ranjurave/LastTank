using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class TankMovement : MonoBehaviour {
    public float speed = 8;
    public float turnSpeed = 0.5f;
    private Rigidbody rigidbody;
    private TankControls tankControls;
    private InputAction movement;

    private void Awake() {
        tankControls = new TankControls();
    }
    private void OnEnable() {
        movement = tankControls.Player.Move;
        movement.Enable();
    }
    private void OnDisable() {
        movement.Disable();
    }
    private void Start() {
        rigidbody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate() {
        //Debug.Log("movement value" + movement.ReadValue<Vector2>());
        Vector2 movementDirection = movement.ReadValue<Vector2>();
        rigidbody.AddRelativeForce(new Vector3( Vector3.forward.x, 0, Vector3.forward.z) * movementDirection.y * speed) ;

        Vector3 localVelocity = transform.InverseTransformDirection(rigidbody.velocity);
        localVelocity.x = 0;
        rigidbody.velocity = transform.TransformDirection(localVelocity);

        //rigidbody.AddTorque(Vector3.up * movementDirection.x * turnSpeed);
        Quaternion currentRotation = transform.rotation;
        Vector3 rot = currentRotation.eulerAngles;
        Quaternion tankRot = Quaternion.Euler(new Vector3(rot.x, rot.y + turnSpeed * movementDirection.x, rot.z));
        rigidbody.MoveRotation(tankRot);

    }


}
