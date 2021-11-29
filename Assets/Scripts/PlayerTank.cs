using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class PlayerTank : MonoBehaviour {
    [SerializeField] GameObject turret;
    [SerializeField] GameObject barrel;
    [SerializeField] GameObject shootpoint;
    [SerializeField] GameObject missile;
    public float speed = 8;
    public float turnSpeed = 0.5f;
    public float turretSensitivity = 45f;
    public float barrelSensitivity = 35f;
    private Rigidbody rigidbody;
    private TankControls tankControls;
    private InputAction movementCtrl;
    private InputAction barrelCtrl;
    public int health = 100;
    Vector2 barrelDirection;

    public CameraRecoil recoil;
    int test;

    private void Awake() {
        tankControls = new TankControls();
    }

    private void OnEnable() {
        movementCtrl = tankControls.Tank.TankMove;
        barrelCtrl = tankControls.Tank.TankBarrel;
        movementCtrl.Enable();
        barrelCtrl.Enable();
    }
    private void OnDisable() {
        movementCtrl.Disable();
    }
    private void Start() {
        rigidbody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate() {
        ManageInput();
        TankMovement();
        BarrelRotate();
    }
    void ManageInput() {
        barrelDirection = barrelCtrl.ReadValue<Vector2>();

    }

    void BarrelRotate() {
        Debug.Log(barrelDirection);
        float turretRot = turret.transform.localRotation.y;

        float barrelRot = barrel.transform.localRotation.x;

        //turret.transform.Rotate(new Vector3(0, Mathf.Clamp( turretNewRot * turretSensitivity, -90, 90), 0));
        float turretNewRot = Mathf.Clamp((turretRot + barrelDirection.x) * turretSensitivity, -90, 90);
        turret.transform.localEulerAngles = new Vector3(0, turretNewRot, 0);
        //barrel.transform.Rotate(new Vector3(Mathf.Clamp(barrelNewRot * barrelSensitivity, -10, 45) * -1, 0, 0));
        float barrelNewRot = Mathf.Clamp( barrelRot + (barrelDirection.y)*barrelSensitivity, -10, 45);
        barrel.transform.localEulerAngles = new Vector3(barrelNewRot * -1, 0, 0);

    }

    void TankMovement() {
        Vector2 movementDirection = movementCtrl.ReadValue<Vector2>();
        rigidbody.AddRelativeForce(new Vector3(Vector3.forward.x, 0, Vector3.forward.z) * movementDirection.y * speed);

        Vector3 localVelocity = transform.InverseTransformDirection(rigidbody.velocity);
        localVelocity.x = 0;
        rigidbody.velocity = transform.TransformDirection(localVelocity);

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

    public void Shoot() {
        //rigidbody.AddForce(Vector3.up * 50f);
        Instantiate(missile, shootpoint.transform.position, shootpoint.transform.rotation);
        recoil.RecoilFire();
    }
}
