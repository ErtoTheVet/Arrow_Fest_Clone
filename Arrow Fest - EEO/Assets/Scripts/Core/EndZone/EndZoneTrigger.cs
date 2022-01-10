using UnityEngine;

namespace Core.EndZone
{
    public class EndZoneTrigger : MonoBehaviour
    {
        /// <summary>
        /// This method starts after arrows went through all of the point gates to start the killing phase
        /// </summary>
        /// <param name="other"></param>
        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag("Player")) return;
            GameManager gameManager = FindObjectOfType<GameManager>();
            gameManager.HandleLastPhase();
        }
    }
}