using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    Rigidbody rigidbodyMissile;
    Vector3 direction;

    private void OnEnable() {
        rigidbodyMissile = GetComponent<Rigidbody>();
        rigidbodyMissile.AddForce(transform.forward * 10f, ForceMode.Impulse);

        //if (dir == Vector3.zero) {
        //    transform.rotation = Quaternion.Slerp(
        //        transform.rotation,
        //        Quaternion.LookRotation(dir),
        //        Time.deltaTime * 10
        //    );
        //transform.rotation = Quaternion.LookRotation(dir);
        //}
    }
    void FixedUpdate() {
        direction = rigidbodyMissile.velocity;
        Debug.Log(direction);
        float angle = Mathf.Atan2(direction.z, direction.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.right);
    
    }
    private void OnTriggerEnter(Collider other) {
        Destroy(gameObject);
    }
}
