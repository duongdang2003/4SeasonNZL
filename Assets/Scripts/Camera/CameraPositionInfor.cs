using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPositionInfor : MonoBehaviour
{
    public Vector3 cameraZPos;
    public Vector3 anchorPos;
    public Vector3 eulerRotation;
    public Quaternion rotation;
    private void Awake() {
        rotation = Quaternion.Euler(eulerRotation);
    }
}
