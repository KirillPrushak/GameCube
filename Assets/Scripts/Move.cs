using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.UIElements;

public class Move : MonoBehaviour
{
    [SerializeField] private float _rollSpeed = 5f;
    private Vector3 _vectorPoint;
    private Vector3 _axis;
    private bool _isMoving;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (_isMoving) return;
        
        if (Input.GetKey(KeyCode.A))
        {
            Moves(Vector3.left);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Moves(Vector3.right);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            Moves(Vector3.forward);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Moves(Vector3.back);
        }
    }

    private void Moves(Vector3 direction)
    {
        var verticalComponent = Vector3.down;
        var hasWall = HasWallInDerection(direction);
        if (hasWall)
        {
            verticalComponent = Vector3.up;
        }
        
        _vectorPoint = (direction / 2f) + (Vector3.down / 2f) + transform.position;
        _axis = Vector3.Cross(Vector3.up, direction);//перпендикуляр к плоскости (ось объекта)
        //var position = transform.position;//текущая позиция
        //position += direction * Time.deltaTime;//текущая позиция + направление
        //transform.position = position;

        StartCoroutine(Roll(_vectorPoint, _axis));
    }

    private bool HasWallInDerection (Vector3 direction)
    {
        return Physics.Raycast(transform.position, direction, 0.51f);
    }

    private IEnumerator Roll(Vector3 pivot, Vector3 axis)
    {
        _isMoving = true;
        _rigidbody.isKinematic = true;

        for (int i = 0; i < 90 / _rollSpeed; i++)
        {
            transform.RotateAround(pivot, axis, _rollSpeed);
            yield return new WaitForSeconds(0.01f);
        }

        _rigidbody.isKinematic = false;
        _isMoving = false;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(_vectorPoint, 0.2f);
        Gizmos.DrawRay(_vectorPoint, _axis);
    }
}
