using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Serialization;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private string _playerTag = "Player";
    [FormerlySerializedAs("_platform")] [SerializeField] private PlatformDirection platformDirection;

    private Renderer _renderer;

    private bool _isMoving;

    private void Start() {
        _renderer = gameObject.GetComponentInChildren<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_isMoving) return;
        if (other.gameObject.tag != _playerTag) return;

        SetButtonColor(Color.red);
        StartCoroutine(Moving());
    }

    private void OnTriggerExit(Collider other)
    {
        if (_isMoving) return;
        if (other.gameObject.tag != _playerTag) return;

        SetButtonColor(Color.blue);
        StartCoroutine(Moving());
    }

    IEnumerator Moving()
    {
        _isMoving = true;
        yield return new WaitForSeconds(1f);
        _isMoving = false;
    }

    private void OnTriggerStay(Collider other)
    {
        platformDirection.MoveDirection();
    }

    private void SetButtonColor(Color color)
    {
        _renderer.material.SetColor("_Color", color);
    }
}