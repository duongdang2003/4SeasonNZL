using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class CameraPosMenu : MonoBehaviour
{
    public GameObject defaultButton;
    public GameObject customButton;
    public GameObject defaultTab;
    public GameObject customTab;
    public GameObject cameraAnchor;
    public Camera mainCamera;
    public Camera captureCamera;
    public GameObject content;
    public GameObject CAMERA_VIEW_IMAGE;
    public struct CameraInfor {
        public Vector3 cameraZPos;
        public Vector3 anchorPos;
        public Quaternion rotation;
        public Vector2 imagePos;
    }
    public struct CameraInforDefault {
        public Vector3 cameraZPos;
        public Vector3 anchorPos;
        public Quaternion rotation;
    }
    private CameraInforDefault _cameraInfor;
    private Dictionary<int, CameraInfor> _cameraPos = new();
    private Dictionary<int, CameraInforDefault> _cameraDefaultPos = new();
    private int FileCounter = 0;
    private void Start() {
        _cameraInfor.anchorPos = new Vector3(0, 1.7f, 20.22f);
        _cameraInfor.cameraZPos = new Vector3(0, 0, -2f);
        _cameraInfor.rotation = Quaternion.Euler(0, 181, 0);
        _cameraDefaultPos.Add(0, _cameraInfor);
    }
    public void OpenDefaultTab(){
        defaultTab.SetActive(true);
        customTab.SetActive(false);
        defaultButton.GetComponent<Image>().color = UIConstants.SELECTED_COLOR;
        customButton.GetComponent<Image>().color = UIConstants.DEFAULT_COLOR;
    }
    public void OpenCustomTab(){
        defaultTab.SetActive(false);
        customTab.SetActive(true);
        defaultButton.GetComponent<Image>().color = UIConstants.DEFAULT_COLOR;
        customButton.GetComponent<Image>().color = UIConstants.SELECTED_COLOR;
    }
    public void SaveCameraPos(){
        CameraInfor captureInfor;
        captureInfor.anchorPos = cameraAnchor.transform.position;
        captureInfor.cameraZPos = new Vector3(0, 0, mainCamera.transform.position.z);
        captureInfor.rotation = cameraAnchor.transform.rotation;

        GameObject cameraViewPic = Instantiate(CAMERA_VIEW_IMAGE);
        cameraViewPic.transform.SetParent(content.transform);
        if (_cameraPos.Count == 0)
            captureInfor.imagePos = new Vector2(150, -54);
        else
            captureInfor.imagePos = _cameraPos[_cameraPos.Count-1].imagePos + new Vector2(0, -122);

        cameraViewPic.GetComponent<RectTransform>().anchoredPosition = captureInfor.imagePos;
        cameraViewPic.GetComponent<CameraPositionInfor>().anchorPos = mainCamera.transform.position;
        cameraViewPic.GetComponent<CameraPositionInfor>().cameraZPos = new Vector3(0, 0, 0);
        cameraViewPic.GetComponent<CameraPositionInfor>().SetRotation(cameraAnchor.transform.rotation.eulerAngles);
        _cameraPos.Add(_cameraPos.Count, captureInfor);
        StartCoroutine(CaptureImage(cameraViewPic.GetComponent<Image>()));
    }
    IEnumerator CaptureImage(Image pic)
    {
        yield return new WaitForEndOfFrame();
        RenderTexture currentRT = RenderTexture.active;
        RenderTexture.active = captureCamera.targetTexture;

        captureCamera.Render();

        Texture2D Image = new (captureCamera.targetTexture.width, captureCamera.targetTexture.height);
        Image.ReadPixels(new Rect(0, 0, captureCamera.targetTexture.width, captureCamera.targetTexture.height), 0, 0);
        Image.Apply();
        RenderTexture.active = currentRT;
        
        var Bytes = Image.EncodeToPNG();
        Destroy(Image);

        File.WriteAllBytes(Application.dataPath + "/Sprites/Backgrounds/" + FileCounter + ".png", Bytes);
        FileCounter++;

        Sprite capturedSprite = Sprite.Create(Image, new Rect(0, 0, Image.width, Image.height), new Vector2(0.5f, 0.5f));
        pic.sprite = capturedSprite;
    }
}
