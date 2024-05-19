using UnityEngine;
using Zenject;

public class PlayerLook : MonoBehaviour
{
    private GameConfigInstaller.PlayerSettings.CameraSettings _cameraSettings;
    private Transform _fpsRig;
    private float _xRotate;
    
    public void Initialize(Transform fpsRig, GameConfigInstaller.PlayerSettings.CameraSettings cameraSettings)
    {
        _fpsRig = fpsRig;
        _cameraSettings = cameraSettings;
    }

    public void RotateCamera(Vector2 mousePosition)
    {
        transform.Rotate(Vector3.up * mousePosition.x * Time.deltaTime * _cameraSettings.sens);
        _xRotate -= mousePosition.y * Time.deltaTime * _cameraSettings.sens;
        Quaternion fpsRigRotation = Quaternion.Euler(Mathf.Clamp(_xRotate, -80f, 80f), 0, 0);
        _fpsRig.localRotation = fpsRigRotation;
    }
}
