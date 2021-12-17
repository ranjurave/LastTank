using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRecoil : MonoBehaviour
{
    Vector3 currentRotation;
    Vector3 targetRotation;
    [SerializeField] float recoilX = -0.5f;
    [SerializeField] float recoilY = 0.5f;
    [SerializeField] float recoilZ =0.5f;

    [SerializeField] float snappiness = 30.0f;
    [SerializeField] float returnSpeed = 20.0f;

    //TODO different recoil for missile hit overload method

    // Update is called once per frame
    void Update()
    {
        targetRotation = Vector3.Lerp(targetRotation, Vector3.zero, returnSpeed * Time.deltaTime);
        currentRotation = Vector3.Slerp(currentRotation, targetRotation, snappiness * Time.deltaTime);
        transform.localRotation = Quaternion.Euler(currentRotation);
    }

    public void RecoilFire() {
        targetRotation += new Vector3(recoilX, Random.Range(-recoilY, recoilY), Random.Range(-recoilZ, recoilZ));
    }
    public void RecoilFire(float _recoilY = 1.0f, float _recoilZ = 1.0f) {
        targetRotation += new Vector3(recoilX, Random.Range(-_recoilY, _recoilY), Random.Range(-_recoilZ, _recoilZ));
    }
}
