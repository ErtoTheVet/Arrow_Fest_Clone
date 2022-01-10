using System;
using PointSystem;
using UnityEngine;

namespace Core.Player
{
    [RequireComponent(typeof(CapsuleCollider))]
    public class PlayerCollision : MonoBehaviour
    {
        [SerializeField]
        private ArrowManager arrowManager;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag("Operation")) return;
            int arrowCount = arrowManager.addedArrows.Count;
            PointsManager pointsManager = other.GetComponent<PointsManager>();
            switch (pointsManager.operation)
            {
                case PointsManager.Operation.Multiplication:
                    arrowManager.AddArrow((pointsManager.value - 1) * arrowCount);
                    break;
                case PointsManager.Operation.Division:
                    arrowManager.RemoveArrow( arrowCount- (arrowCount / pointsManager.value));
                    break;
                case PointsManager.Operation.Addition:
                    arrowManager.AddArrow(pointsManager.value);
                    break;
                case PointsManager.Operation.Subtraction:
                    arrowManager.RemoveArrow(pointsManager.value);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
