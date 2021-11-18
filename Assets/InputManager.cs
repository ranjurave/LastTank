using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    [SerializeField] Slider turretSlider;
    [SerializeField] Slider barrelSlider;
    [SerializeField]ShootControls shootControls;
    private void Awake() {
        
    }
    private void Start() {
        turretSlider.onValueChanged.AddListener(delegate {
            shootControls.RotateTurret(turretSlider.value);
        });
        barrelSlider.onValueChanged.AddListener(delegate {
            shootControls.RotateBarrel(barrelSlider.value);
        });

    }
    public void QuitGame() {
        Application.Quit();
    }
}
