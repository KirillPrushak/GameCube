using DefaultNamespace.UI;
using UnityEngine;

namespace DefaultNamespace
{
    public class PickupManager : SingletonMonoBehaviour<PickupManager>
    {
        [SerializeField] private int _currentPlayerAmount;
        [SerializeField] private AnimatedScoreDisplay _scoreDisplay;
        public void AddMoney(int amount)
        {
            _scoreDisplay.Animate(_currentPlayerAmount, _currentPlayerAmount);
            
            _currentPlayerAmount += amount;
        }
    }
}