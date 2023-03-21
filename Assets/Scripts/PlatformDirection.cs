using UnityEngine;

namespace DefaultNamespace
{
    public class PlatformDirection : MonoBehaviour
    {
        [SerializeField] private Vector3 _direction = new Vector3(1f, 0, 0);
        public void MoveDirection()
        {
            transform.position += _direction * Time.deltaTime;
        }
    }
}