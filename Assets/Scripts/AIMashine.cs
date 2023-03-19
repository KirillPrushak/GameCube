using System;
using UnityEngine;

namespace DefaultNamespace
{
    [RequireComponent(typeof(Move))]
    public class AIMashine : MonoBehaviour
    {
        private IAiState _currentState;
        private Move _cubeController;

        private void Start()
        {
            _currentState = new WanderState();
            _cubeController = GetComponent<Move>();
        }

        private void Update()
        {
            var direction = _currentState.GetDirection(transform.position);
            
            _cubeController.Moves(direction);

            var newState = _currentState.GetNextState();
            if (newState != null)
            {
                _currentState = newState;
            }
        }
    }
    public interface IAiState
    {
        public Vector3 GetDirection(Vector3 transformPosition);

        public IAiState GetNextState();
    }
    public class WanderState : IAiState
    {
        private IAiState _nextState;

        public Vector3 GetDirection(Vector3 transformPosition)
        {
            if (BlockChecker.HasBlocknInDerection(transformPosition, Vector3.forward))
            {
                return Vector3.forward;
            }
            else
            {
                _nextState = new WaitState();
                return Vector3.zero;
            }
            //if(BlockChecker.HasWallInDerection())
        }

        public IAiState GetNextState()
        {
            return _nextState;
        }
    }

    public class WaitState : IAiState
    {
        public Vector3 GetDirection(Vector3 transformPosition)
        {
            return Vector3.zero;
        }

        public IAiState GetNextState()
        {
            throw new NotImplementedException();
        }
    }
}