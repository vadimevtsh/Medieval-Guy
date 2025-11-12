using UnityEngine;

public class CameraService : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;

    public Camera MainCamera => _mainCamera;
}
