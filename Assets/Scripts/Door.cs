using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(DoorAnimation))]
public class Door : MonoBehaviour
{
    private DoorAnimation _doorAnimation;
    private bool _isOpened = false;
    public event UnityAction<bool> DoorOpened;

    public void Open()
    {
        _isOpened = !_isOpened;
        DoorOpened?.Invoke(_isOpened);
        _doorAnimation.ChangeAnimation(_isOpened);
    }

    private void Start()
    {
        _doorAnimation = GetComponent<DoorAnimation>();
    }
}
