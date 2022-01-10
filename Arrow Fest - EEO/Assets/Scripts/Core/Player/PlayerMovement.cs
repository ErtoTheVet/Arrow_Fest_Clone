using Unity.VisualScripting.YamlDotNet.Core.Tokens;
using UnityEngine;

namespace Core.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField]
        private GameManager gameManager;

        [SerializeField]
        private ArrowManager arrowManager;
        
        [SerializeField]
        private float screenBoundLimit;
        
        [SerializeField]
        private float horizontalMovementSpeed;
        
        public float playerMovementSpeed;

        /// <summary>
        /// This method includes all the components that allow the player to move in the game.
        /// </summary>
        /// <param name="horizontalInput"></param>
        public void Movement(float horizontalInput)
        {
            if (gameManager.isFinalScreenActive) return;
            transform.Translate(playerMovementSpeed * Time.deltaTime, 0, 0);
            if (gameManager.isLastPhaseStarted)
            {
                if (arrowManager.addedArrows.Count != 1) return;
                
                gameManager.isFinalScreenActive = true;
                gameManager.GameEnd();
                arrowManager.addedArrows.Clear();
                return;
            }

            float fpsFixedMovementSpeed = Time.deltaTime * horizontalMovementSpeed;
            Vector3 leftRightMove = Vector3.forward * (horizontalInput * fpsFixedMovementSpeed);
            transform.Translate(leftRightMove);
            KeepPlayerInBounds();
        }

        /// <summary>
        /// With KeepPlayerInBounds method we do not allow the arrows go beyond the width of the platform.
        /// </summary>
        private void KeepPlayerInBounds()
        {
            Vector3 position = transform.position;
            if (position.z >= screenBoundLimit)
            {
                position = new Vector3(position.x, position.y, screenBoundLimit);
                transform.position = position;
            }

            if (position.z <= -screenBoundLimit)
            {
                position = new Vector3(position.x, position.y, -screenBoundLimit);
                transform.position = position;
            }
        }
    }
}