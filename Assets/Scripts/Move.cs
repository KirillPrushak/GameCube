using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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
    
    public void Moves(Vector3 direction)
    {
        if (_isMoving) return;
        var isGrounded = BlockChecker.CheckIsGrounded(transform.position);
        if (!isGrounded)
        {
            return;
        }
        
        var verticalComponent = Vector3.down;
        var hasWall = BlockChecker.HasBlocknInDerection(transform.position ,direction);
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

        BlockChecker.SnapPositionToInteger(transform);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(_vectorPoint, 0.2f);
        Gizmos.DrawRay(_vectorPoint, _axis);
    }
}
