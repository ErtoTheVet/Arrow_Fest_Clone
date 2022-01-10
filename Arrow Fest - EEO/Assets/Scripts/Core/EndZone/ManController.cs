using UnityEngine;

namespace Core.EndZone
{
    public class ManController : MonoBehaviour
    {
        [SerializeField]
        private int totalLifeOfMen;

        [SerializeField]
        private float platformMultiplier;

        private Animator _manAnimator;
        private ArrowManager _arrowManager;
        private static readonly int Dying = Animator.StringToHash("Dying");

        private void Start()
        {
            _manAnimator = GetComponent<Animator>();
            _arrowManager = FindObjectOfType<ArrowManager>();
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag("Player")) return;
            GameManager gameManager = FindObjectOfType<GameManager>();
            gameManager.awardMultiplier = platformMultiplier;
            _arrowManager.RemoveArrow(totalLifeOfMen);
            _manAnimator.SetTrigger(Dying);
            Destroy(gameObject, 3f);
        }
    }
}