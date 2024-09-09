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
        Debug.Log(inten);

        if (inten > 2) inten = 2;
        else if (inten < 0) inten = 0;
        // Debug.Log(inten);
        _mainDirectionLight.intensity = inten;
    }
}
