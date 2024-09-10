using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class LighController : MonoBehaviour
{
    public static LighController Instance;
    private Light _mainDirectionLight;

    private void Awake() {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        _mainDirectionLight = GameObject.FindWithTag("MainLight").GetComponent<Light>();
    }

    public void SetLight(float intensity){
        float inten;
        if(intensity <= 0.5f){
            inten = intensity * 4;
        } else {
            inten = (1 - intensity)*4;
        }

        inten = Mathf.Clamp(inten, 0, 2);

        float targetRotationX = Mathf.Lerp(0, 180, intensity / 2);
        Vector3 currentEulerAngles = _mainDirectionLight.transform.eulerAngles;
        Quaternion targetRotation = Quaternion.Euler(targetRotationX, currentEulerAngles.y, currentEulerAngles.z);
        _mainDirectionLight.transform.rotation = Quaternion.Lerp(
            _mainDirectionLight.transform.rotation, 
            targetRotation, 
            Time.deltaTime * 2
        );

        _mainDirectionLight.intensity = inten;
    }
}
