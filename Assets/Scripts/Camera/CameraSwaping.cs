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
        _cameraAnchor.transform.position = Vector3.Slerp(_cameraAnchor.transform.position, target, movingSpeed * Time.deltaTime);

        if (Vector3.Distance(_cameraAnchor.transform.position, target) < 0.01f)
        {
            _cameraAnchor.transform.position = target; 
        }
    }

    public void RePositioningCameraZ(Vector3 target)
    {
        _mainCamera.transform.localPosition = Vector3.Slerp(_mainCamera.transform.localPosition, target, movingSpeed * Time.deltaTime);

        if (Vector3.Distance(_mainCamera.transform.position, target) < 0.01f)
        {
            _mainCamera.transform.position = target;
            Debug.Log(target);
        }
    }

    public void ReRotationAnchor(Quaternion target)
    {
        _cameraAnchor.transform.rotation = Quaternion.Slerp(_cameraAnchor.transform.rotation, target, movingSpeed * Time.deltaTime);
        if (Quaternion.Angle(_cameraAnchor.transform.rotation, target) < 0.1f)
        {
            _cameraAnchor.transform.rotation = target;
        }
    }

    private IEnumerator StopSlerp()
    {
        yield return new WaitForSeconds(3); 
        _slerp = false;
    }
}
