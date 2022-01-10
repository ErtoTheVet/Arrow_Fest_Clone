using UnityEngine;

namespace Core.Player
{
    [RequireComponent(typeof(PlayerMovement), typeof(PlayerCollision))]
    public class PlayerController : MonoBehaviour
    {
        private PlayerMovement _playerMovement;

        private void Start()
        {
            _playerMovement = GetComponent<PlayerMovement>();
        }

        private void Update()
        {
            _playerMovement.Movement(Input.GetAxis("Horizontal"));
        }
    }
}