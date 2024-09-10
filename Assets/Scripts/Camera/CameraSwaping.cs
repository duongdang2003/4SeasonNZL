using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CameraSwaping : MonoBehaviour
{
    public GraphicRaycaster _graphicRaycaster;
    public float movingSpeed;
    public EventSystem eventSystem;
    private GameObject _cameraAnchor;
    private GameObject _mainCamera;
    private CameraPositionInfor _infor;
    private bool _slerp = false;
    private void Awake() {
        _cameraAnchor = GameObject.FindWithTag("CameraAnchor");
        _mainCamera = GameObject.FindWithTag("MainCamera");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0)){
            PointerEventData pointerEventData = new PointerEventData(eventSystem)
            {
                position = Input.mousePosition
            };
            List<RaycastResult> raycastResults = new();
            _graphicRaycaster.Raycast(pointerEventData, raycastResults);
            
            if(raycastResults.Count > 0 && raycastResults[0].gameObject.CompareTag("CameraViewImage")){
                _infor = raycastResults[0].gameObject.GetComponent<CameraPositionInfor>();
                _slerp = true;
                StopCoroutine(StopSlerp());
                
                StartCoroutine(StopSlerp());
                Debug.Log("slerp");
            }
        }
        if(_slerp){
            RePositioningAnchor(_infor.anchorPos);
            RePositioningCameraZ(_infor.cameraZPos);
            ReRotationAnchor(_infor.rotation);
        }
    }
    public void RePositioningAnchor(Vector3 target)
    {
        // Correct interpolation speed factor
        _cameraAnchor.transform.position = Vector3.Slerp(_cameraAnchor.transform.position, target, movingSpeed * Time.deltaTime);

        // Optional: Check if the Slerp is done
        if (Vector3.Distance(_cameraAnchor.transform.position, target) < 0.01f)
        {
            _cameraAnchor.transform.position = target; // Snap to the target to ensure it's exactly correct
            Debug.Log("Anchor Slerp completed.");
        }
    }

    public void RePositioningCameraZ(Vector3 target)
    {
        // Correct interpolation speed factor
        _mainCamera.transform.localPosition = Vector3.Slerp(_mainCamera.transform.localPosition, target, movingSpeed * Time.deltaTime);

        // Optional: Check if the Slerp is done
        if (Vector3.Distance(_mainCamera.transform.position, target) < 0.01f)
        {
            _mainCamera.transform.position = target; // Snap to the target
            Debug.Log("Camera Z Slerp completed.");
            Debug.Log(target);
        }
    }

    public void ReRotationAnchor(Quaternion target)
    {
        // Correct interpolation speed factor
        _cameraAnchor.transform.rotation = Quaternion.Slerp(_cameraAnchor.transform.rotation, target, movingSpeed * Time.deltaTime);

        // Optional: Check if the Slerp is done
        if (Quaternion.Angle(_cameraAnchor.transform.rotation, target) < 0.1f)
        {
            _cameraAnchor.transform.rotation = target; // Snap to the target
            Debug.Log("Rotation Slerp completed.");
            Debug.Log(target);

        }
    }

    private IEnumerator StopSlerp()
    {
        yield return new WaitForSeconds(3); // Adjust as needed to ensure completion
        _slerp = false;
        Debug.Log("Slerping stopped.");
    }
}
