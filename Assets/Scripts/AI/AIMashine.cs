using System;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

namespace DefaultNamespace
{
    [RequireComponent(typeof(Move))]
    public class AIMashine : MonoBehaviour
    {
        [SerializeField] private Vector3 _startdirection = Vector3.forward;
        private IAiState _currentState;
        private Move _cubeController;

        private void Start()
        {
            _currentState = new WanderState(_startdirection);
            _cubeController = GetComponent<Move>();
        }

        private void Update()
        {
            var direction = _currentState.GetDirection(transform.position);
            
            _cubeController.Moves(direction);

            _currentState.OnUpdate(Time.deltaTime);
            var newState = _currentState.GetNextState();
            if (newState != null)
            {
                _currentState = newState;
            }
        }
    }
}