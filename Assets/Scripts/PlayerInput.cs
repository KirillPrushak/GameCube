using UnityEngine;

[RequireComponent(typeof(Move))]
public class PlayerInput : MonoBehaviour
{
    private Move _move;

    private void Start()
    {
        _move = GetComponent<Move>();
    }

    private void Update()
    {
        ProcessInput();
    }

    private void ProcessInput()
    {

        if (Input.GetKey(KeyCode.A))
        {
            _move.Moves(Vector3.left);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _move.Moves(Vector3.right);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            _move.Moves(Vector3.forward);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            _move.Moves(Vector3.back);
        }
    }
}