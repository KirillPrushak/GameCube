using DG.Tweening;
using UnityEngine;

namespace DefaultNamespace.EventObjects
{
    public class MovingPlatformPosition : MovingPlatform
    {
        [SerializeField] private Transform _pos1;
        [SerializeField] private Transform _pos2;
        [SerializeField] private float _doretion = 2f;
        [SerializeField] private Ease _ease = Ease.Linear;
        
        public override void Move()
        {
            transform.DOMove(_pos1.position, _doretion).SetEase(_ease);
            transform.DOMove(_pos2.position, _doretion).SetEase(_ease);
        }
    }
}