using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checker : MonoBehaviour
{
    [SerializeField] private Door _door;
    [SerializeField] private Signalization _signalization;

    private bool _isEntered;
    private bool _isDoorOpened;

    private void OnTriggerEnter()
    {
        _isEntered = true;
        OnDoorOpened(_isDoorOpened);
    }

    private void OnTriggerExit()
    {
        _isEntered = false;
        OnDoorOpened(_isDoorOpened);
    }

    private void OnEnable()
    {
        _door.DoorOpened += OnDoorOpened;
    }

    private void OnDisable()
    {
        _door.DoorOpened -= OnDoorOpened;
    }

    private void OnDoorOpened(bool isOpened)
    {
        _isDoorOpened = isOpened;
        _signalization.SignalizationOn(_isEntered, _isDoorOpened);
    }
}
