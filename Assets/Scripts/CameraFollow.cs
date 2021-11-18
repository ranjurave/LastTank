using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Vector3 cameraPosition;
    Quaternion cameraRotation;
    public Transform player;
    float cameraDelay = 0.05f;
    private void Awake() {
        PlayerTank player = FindObjectOfType<PlayerTank>();
        transform.position = player.transform.position;
        cameraPosition = new Vector3(0.0f, 3.2f, -5.9f);
        cameraRotation = Quaternion.Euler(new Vector3(11.751f, 0.0f, 0.0f));
    }
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position , player.position, cameraDelay);
        transform.rotation = Quaternion.Slerp(transform.rotation , player.rotation, cameraDelay);
        transform.rotation = Quaternion.Euler(new Vector3(0, transform.rotation.eulerAngles.y, 0));
    }
}
