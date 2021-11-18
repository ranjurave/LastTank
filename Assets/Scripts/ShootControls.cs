using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootControls : MonoBehaviour {
    [SerializeField] GameObject turret;
    [SerializeField] GameObject barrel;
    [SerializeField] GameObject shootpoint;
    [SerializeField] GameObject missile;
    [SerializeField] float turretRotateLimit = 90;
    [SerializeField] float barrelRotateLimit = 45;

    public void RotateTurret(float sliderValue) {
        turret.transform.localEulerAngles = new Vector3(0, sliderValue * turretRotateLimit, 0);
    }
    public void RotateBarrel(float sliderValue) {
        barrel.transform.localEulerAngles = new Vector3(sliderValue * -barrelRotateLimit, 0, 0);
    }

    public void Shoot() {
        Instantiate(missile, shootpoint.transform.position, shootpoint.transform.rotation);
    }
}
