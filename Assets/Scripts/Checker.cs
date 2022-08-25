using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checker : MonoBehaviour
{
    [SerializeField] private Door _door;
    [SerializeField] private Signalization _signalization;

    private bool isEntered;
    private bool isDoorOpened;

    private void OnTriggerEnter()
    {
        isEntered = true;
        _signalization.SignalizationOn(isEntered, isDoorOpened);
    }

    private void OnTriggerExit()
    {
        isEntered = false;
        _signalization.SignalizationOn(isEntered, isDoorOpened);
    }

    private void OnEnable()
    {
        _door.DoorOpened += DoorOpening;
    }

    private void OnDisable()
    {
        _door.DoorOpened -= DoorOpening;
    }

    private void DoorOpening(bool isOpened)
    {
        isDoorOpened = isOpened;
        _signalization.SignalizationOn(isEntered, isDoorOpened);
    }
}
