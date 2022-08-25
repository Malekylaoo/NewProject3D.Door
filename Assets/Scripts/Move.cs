using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]
public class Move : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _shiftSpeed;

    private void Update()
    {
        Mover(SelectSpeed());
    }

    private void Mover(float localSpeed)
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(localSpeed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(localSpeed * Time.deltaTime * -1, 0, 0));
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(0, 0, localSpeed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(0, 0, localSpeed * Time.deltaTime * -1));
        }
    }

    private float SelectSpeed()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            return _shiftSpeed;
        }
        else
        {
            return _speed;
        }
    }
}
