using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameStateManager : SingletonMonoBehaviour<GameStateManager>
    {

        private bool _isDead = false;
        private GameObject _player;
        
        private void Start()
        {
            _player = FindObjectOfType<PlayerInput>().gameObject;
        }

        public void Die()
        {
            Destroy(_player);
            _isDead = true;
        }
    }
}