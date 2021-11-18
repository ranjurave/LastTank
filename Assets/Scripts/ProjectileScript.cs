using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    float shootForce = 10f;
    Rigidbody rigidbodyMissile;
    Vector3 direction;

    private void Start() {
        rigidbodyMissile = GetComponent<Rigidbody>();
        rigidbodyMissile.AddForce(transform.forward * shootForce, ForceMode.Impulse);
    }
    void Update() {
        //TODO rotate shell in moving direction
        //direction = rigidbodyMissile.velocity;
        //float angleZ = Mathf.Atan2(direction.z, direction.y) * Mathf.Rad2Deg;
        //float angleY = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(angleZ+90, angleY, transform.rotation.z);
    }
    private void OnTriggerEnter(Collider other) {
        Destroy(gameObject);
    }
}
