using DefaultNamespace.UI;
using DG.Tweening;
using UnityEngine;

namespace DefaultNamespace
{
    public class CoinAnimationManager : SingletonMonoBehaviour<CoinAnimationManager>
    {
        [SerializeField] private GameObject _cointPrefab;
        [SerializeField] private Canvas _canvas;
        [SerializeField] private AnimatedScoreDisplay _scoreDisplay;
        [SerializeField] private float _animationDuration = 1f;
        [SerializeField] private float _spread = 50f;

        public void Animate(int amount, Vector3 startposition)
        {
            var coinAmount = amount / 10;
            for (int i = 0; i < coinAmount; i++)
            {
                CreateCoinAtrandomPosition(startposition);
            }
        }

        private void CreateCoinAtrandomPosition(Vector3 startposition)
        {
            var coin = Instantiate(_cointPrefab, _canvas.transform);

            var startScreenPosition = Camera.main.WorldToScreenPoint(startposition);
            var targetPosition = _scoreDisplay.transform.position;

            startScreenPosition += new Vector3(
                Random.Range(-_spread, _spread),
                Random.Range(-_spread, _spread)
            );
            
            coin.transform.position = startScreenPosition;

            coin.transform.localScale = Vector3.zero;
            coin.transform.DOScale(Vector3.one, _animationDuration).OnComplete(
                () =>
                    coin.transform.DOMove(targetPosition, _animationDuration).OnComplete(() => Destroy(coin.gameObject)));
        }

        // private async void AnimateTask(Transform animatedTransform, Vector3 startPos, Vector3 endpos)
        // {
        //     var direction = startPos - endpos;
        //     var stop = direction;
        // }
    }
}