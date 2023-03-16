using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class KillPlain : MonoBehaviour
    {
        [SerializeField] private string _player;
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag(_player))
            {
                GameStateManager.Instance.Die();
                Destroy(collision.gameObject);
            }
        }
    }
}