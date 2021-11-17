using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    float cameraDelay = 0.05f;

    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, player.position, cameraDelay);
        transform.rotation = Quaternion.Slerp(transform.rotation, player.rotation, cameraDelay);
        transform.rotation = Quaternion.Euler(new Vector3(0, transform.rotation.eulerAngles.y, 0));
    }
}
