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
    public IEnumerator CaptureImage(Image pic)
    {
        // Ensure the RenderTexture is assigned and active
        if (captureCamera == null || captureCamera.targetTexture == null)
        {
            Debug.LogError("Capture Camera or its targetTexture is not assigned.");
            yield break;
        }

        yield return new WaitForEndOfFrame();

        RenderTexture currentRT = RenderTexture.active;

        RenderTexture.active = captureCamera.targetTexture;

        captureCamera.Render();

        Texture2D capturedTexture = new Texture2D(captureCamera.targetTexture.width, captureCamera.targetTexture.height, TextureFormat.RGB24, false);

        capturedTexture.ReadPixels(new Rect(0, 0, captureCamera.targetTexture.width, captureCamera.targetTexture.height), 0, 0);
        capturedTexture.Apply();

        RenderTexture.active = currentRT;

        Sprite capturedSprite = Sprite.Create(capturedTexture, new Rect(0, 0, capturedTexture.width, capturedTexture.height), new Vector2(0.5f, 0.5f), 100.0f);

        if (pic != null)
        {
            pic.sprite = capturedSprite;
        }
        else
        {
            Debug.LogError("UI Image component is not assigned.");
        }

        SaveSpriteAsPNG(capturedSprite, Application.dataPath + "/Sprites/Backgrounds/" + FileCounter + ".png");
        FileCounter++;
    }

    private void SaveSpriteAsPNG(Sprite sprite, string filePath)
    {
        if (sprite == null)
        {
            Debug.LogError("Sprite is null, cannot save.");
            return;
        }

        Texture2D texture = sprite.texture;

        byte[] bytes = texture.EncodeToPNG();

        string directoryPath = Path.GetDirectoryName(filePath);
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        File.WriteAllBytes(filePath, bytes);
        Debug.Log($"Sprite's texture saved as PNG to: {filePath}");
    }
}
