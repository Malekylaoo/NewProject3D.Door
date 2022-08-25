using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class DoorAnimation : MonoBehaviour
{
    private Animator _animator;
    private const string _IsOpened = "isOpened";

    public void ChangeAnimation(bool isOpened)
    {
        _animator.SetBool(_IsOpened, isOpened);
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
}
