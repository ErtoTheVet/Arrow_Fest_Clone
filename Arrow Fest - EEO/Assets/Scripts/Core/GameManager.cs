using Core.Player;
using DG.Tweening;
using TMPro;
using UI;
using UnityEngine;

namespace Core
{
    public class GameManager : MonoBehaviour
    {
        private const int GoldCount = 10;
        
        [HideInInspector]
        public bool isLastPhaseStarted;
        
        [HideInInspector]
        public float awardMultiplier = 1f;
        
        [HideInInspector]
        public bool isFinalScreenActive;

        [SerializeField]
        private Transform cameraTransform;

        [SerializeField]
        private PlayerMovement playerMovement;
        
        [SerializeField]
        private UIManager uiManager;

        /// <summary>
        /// Last phase is actually the phase starts right after player went through all the point gates.
        /// So, HandleLastPhase method starts other methods when player finished the course.
        /// </summary>
        public void HandleLastPhase()
        {
            isLastPhaseStarted = true;
            HandlePlayerMovementSpeed();
            LastPhaseMotions();
        }
        
        /// <summary>
        /// LastPhaseMotions method brings the arrows at the middle of the platform and give main camera an angle to
        /// show the men clearly.
        /// </summary>
        private void LastPhaseMotions()
        {
            cameraTransform.DOLocalMove(new Vector3(-3f, 1.6f, 0), 1f);
            cameraTransform.DOLocalRotate(new Vector3(30, 90, 0), 1f);
            playerMovement.gameObject.transform.DOMoveZ(0, 0.5f);
        }

        /// <summary>
        /// HandlePlayerMovementSpeed slow down the arrows at the last phase.
        /// </summary>
        private void HandlePlayerMovementSpeed()
        {
            playerMovement.playerMovementSpeed = 2f;
        }
        
        /// <summary>
        /// GameEnd holds what should happen when the game is over.
        /// </summary>
        public void GameEnd()
        {
            float finalGold = awardMultiplier * GoldCount;
            uiManager.ShowEndGameScreen();
            uiManager.SetFinalGoldText(finalGold);
        }
    }
}