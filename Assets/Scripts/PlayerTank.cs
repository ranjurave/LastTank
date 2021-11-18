using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class PlayerTank : MonoBehaviour {
    public float speed = 8;
    public float turnSpeed = 0.5f;
    private Rigidbody rigidbody;
    private TankControls tankControls;
    private InputAction movement;
    public int health = 100;

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
        rigidbody.AddRelativeForce(new Vector3(Vector3.forward.x, 0, Vector3.forward.z) * movementDirection.y * speed);

        Vector3 localVelocity = transform.InverseTransformDirection(rigidbody.velocity);
        localVelocity.x = 0;
        rigidbody.velocity = transform.TransformDirection(localVelocity);

        //rigidbody.AddTorque(Vector3.up * movementDirection.x * turnSpeed);
        Quaternion currentRotation = transform.rotation;
        Vector3 rot = currentRotation.eulerAngles;
        Quaternion tankRot = Quaternion.Euler(new Vector3(rot.x, rot.y + turnSpeed * movementDirection.x, rot.z));
        rigidbody.MoveRotation(tankRot);
    }

    public void Damage(int damage) {
        health -= damage;
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.transform.gameObject.CompareTag("Enemy")) {
            //Debug.Log("MISSILE....");
            Damage(50);
            if (health <= 0) {
                Destroy(collision.gameObject);
            }
        }
    }
    private void OnTriggerEnter(Collider other) {
        if (other.transform.gameObject.CompareTag("Missile")) {
            //Debug.Log("MISSILE....");
            Damage(10);
            if (health <= 0) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
