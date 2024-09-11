using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMovement : MonoBehaviour
{
    public float speed;
    public Camera fpsCamera;
    public Camera tpsCamera;
    private CharacterController _characterController;
    private Animator _animator;
    public enum Mode {
        FPS,
        TPS
    }
    private Mode _currentMode = Mode.FPS;
    private void Awake() {
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();   
    }
    private void Update() {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if(_currentMode == Mode.TPS){
            Vector3 movementDirection = new Vector3(horizontal, 0, vertical).normalized;

            if (movementDirection.magnitude > 0) {
                _animator.SetBool("Idle", false);

                float targetAngle = Mathf.Atan2(movementDirection.x, movementDirection.z) * Mathf.Rad2Deg;

                Quaternion targetRotation = Quaternion.LookRotation(tpsCamera.transform.forward);
                targetRotation.x = 0;
                targetRotation.z = 0;

                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 3 * Time.deltaTime);

                Vector3 move = (tpsCamera.transform.forward * vertical + tpsCamera.transform.right * horizontal) * speed * Time.deltaTime;
                move.y = 0;
                _characterController.Move(move);
            } else {
                _animator.SetBool("Idle", true);
            }
        } else {
                Vector3 move = (fpsCamera.transform.forward * vertical + fpsCamera.transform.right * horizontal) * speed * Time.deltaTime;
                move.y = 0;
                _characterController.Move(move);
        }
        
    }
    public void ChangeMode(Mode mode){
        // if(_currentMode == Mode.FPS){
        //     _currentMode = Mode.TPS;
        //     tpsCamera.gameObject.SetActive(true);
        //     fpsCamera.gameObject.SetActive(false);
        //     Debug.Log("TPS Mode");
        // } else {
        //     _currentMode = Mode.FPS;
        //     tpsCamera.gameObject.SetActive(false);
        //     fpsCamera.gameObject.SetActive(true);
        //     Debug.Log("FPS Mode");
        // }
        _currentMode = mode;
    }
}
