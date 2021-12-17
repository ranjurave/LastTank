using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    //PlayerTank playerTank;
    //EnemyTank enemyTank;
    //Vector3 direction;
    [SerializeField] GameObject tankExplosion;
    [SerializeField] GameObject mudExplosion;
    float shootForce = 50f;
    Rigidbody rigidbodyMissile;


    private void Start() {
        rigidbodyMissile = GetComponent<Rigidbody>();
        rigidbodyMissile.AddForce(transform.forward * shootForce, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other) {

        Debug.Log(other.gameObject.tag);
        if (other.gameObject.CompareTag("Ground")) {
        GameObject explosionMud =  Instantiate(mudExplosion, transform.position, transform.rotation);
        Destroy(explosionMud, 3);
        }
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Player")) {
        GameObject explosionBig = Instantiate(tankExplosion, transform.position, transform.rotation);
            Destroy(explosionBig, 2);
        }
        Destroy(gameObject);
        //mudExplosion.Play();
        //Invoke("DestroyMissile", 1f);
    }

    void DestroyMissile() {
        Destroy(gameObject);
    }
}