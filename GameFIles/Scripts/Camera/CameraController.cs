using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _cinemachine;

    private void OnEnable()
    {
        GlobalEventManager.MainPlayerIsDead += StopMoveCamera;
    }
    private void OnDisable()
    {
        GlobalEventManager.MainPlayerIsDead -= StopMoveCamera;
    }
        
    private void StopMoveCamera()
    {
        _cinemachine.Follow = null; 
    }
}
