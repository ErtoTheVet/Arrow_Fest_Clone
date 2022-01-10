using UnityEngine;

namespace PointSystem
{
    public class PointsManager : MonoBehaviour
    {
        public enum Operation
        {
            Multiplication,
            Division,
            Addition,
            Subtraction
        }

        public Operation operation;
        public int value;
    }
}