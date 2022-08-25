using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactive : MonoBehaviour
{
    [SerializeField] private Camera _fpcCamera;
    [SerializeField] private float _maxDistanceRay;

    private Ray _ray;
    private RaycastHit _hit;

    private void Update()
    {
        CreateRay();
        DrawRay();
        Interact();
    }

    private void CreateRay()
    {
        _ray = _fpcCamera.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
    }

    private void DrawRay()
    {
        if (Physics.Raycast(_ray, out _hit, _maxDistanceRay))
        {
            Debug.DrawRay(_ray.origin, _ray.direction * _maxDistanceRay, Color.blue);
        }
        if (_hit.transform == null)
        {
            Debug.DrawRay(_ray.origin, _ray.direction * _maxDistanceRay, Color.red);
        }
    }

    private void Interact()
    {
        if (_hit.transform != null && _hit.transform.TryGetComponent(out Door door))
        {
            Debug.DrawRay(_ray.origin, _ray.direction * _maxDistanceRay, Color.green);
            if (Input.GetKeyDown(KeyCode.E))
            {
                door.ChangeState();
            }
        }
    }
}
