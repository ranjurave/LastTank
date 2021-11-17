using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootControls : MonoBehaviour {
    [SerializeField] GameObject turret;
    [SerializeField] GameObject barrel;
    [SerializeField] GameObject shootpoint;
    [SerializeField] GameObject missile;
    [SerializeField] Slider turretSlider;
    [SerializeField] Slider barrelSlider;

    [SerializeField] float turretRotateLimit = 90;
    [SerializeField] float barrelRotateLimit = 45;
    void Start() {
        turretSlider.onValueChanged.AddListener(delegate {
            RotateTurret();
        });
        barrelSlider.onValueChanged.AddListener(delegate {
            RotateBarrel();
        });
    }

    void RotateTurret() {
        turret.transform.localEulerAngles = new Vector3(0, turretSlider.value * turretRotateLimit, 0);
    }
    void RotateBarrel() {
        barrel.transform.localEulerAngles = new Vector3(barrelSlider.value * -barrelRotateLimit, 0, 0);
    }

    public void Shoot() {
        Instantiate(missile, shootpoint.transform.position, shootpoint.transform.rotation);
    }
}
