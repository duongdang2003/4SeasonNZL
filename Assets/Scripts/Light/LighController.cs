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
            // _mainDirectionLight.transform.Rotate(inten, 0, 0);
        } else {
            inten = (1 - intensity)*4;
        }
        if (inten > 2) inten = 2;
        else if (inten < 0) inten = 0;

        // _mainDirectionLight.transform.Rotate(new Vector3(inten, 0, 0));
        // Vector3 currentEulerAngles = _mainDirectionLight.transform.eulerAngles;
        // currentEulerAngles.y = 0;
        // currentEulerAngles.z = 0;
        // transform.eulerAngles = currentEulerAngles;

        _mainDirectionLight.intensity = inten;
    }
}
