using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    private Camera _mainCamera;

    private void Start()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        this.gameObject.transform.LookAt(_mainCamera.transform);
    }
}