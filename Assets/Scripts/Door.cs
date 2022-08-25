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

    private void Start()
    {
        _doorAnimation = GetComponent<DoorAnimation>();
    }

    public void ChangeState()
    {
        _isOpened = !_isOpened;
        DoorOpened?.Invoke(_isOpened);
        _doorAnimation.ChangeAnimation(_isOpened);
    }  
}
