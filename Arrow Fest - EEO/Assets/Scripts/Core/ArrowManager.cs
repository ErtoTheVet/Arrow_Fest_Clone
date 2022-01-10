using System.Collections.Generic;
using System.Linq;
using UI;
using UnityEngine;

namespace Core
{
    public class ArrowManager : MonoBehaviour
    {
        private const float DefaultRate = 1f;

        [SerializeField] private UIManager uiManager;

        [SerializeField] private int numberOfSpawns;

        [SerializeField] private int spawnRadiusDecreaseRate;

        [SerializeField] private float coefficient = 5.25f;

        [SerializeField] private float defaultRateDecreaseCoefficient;

        [SerializeField] private float spawnPosXOffset;

        [SerializeField] private float spawnPosYOffset;

        [SerializeField] private GameObject arrow;

        [SerializeField] private Transform playerTransform;

        [HideInInspector] public List<GameObject> addedArrows = new List<GameObject>();

        private void Start()
        {
            SpawnArrowsSpiralShape();
            uiManager.SetArrowCountText(addedArrows.Count);
        }

        /// <summary>
        /// GetSpawnRadiusDecreaseRate method reduce the radius of arrow stack after a player collected determined
        /// amount of arrow.
        /// </summary>
        /// <param name="currentSpawnIndex"></param>
        /// <returns></returns>
        private float GetSpawnRadiusDecreaseRate(int currentSpawnIndex)
        {
            int currentIteration = currentSpawnIndex / spawnRadiusDecreaseRate;
            if (currentIteration <= 0)
            {
                return DefaultRate;
            }

            float decreaseRate = DefaultRate - currentIteration * defaultRateDecreaseCoefficient;

            return decreaseRate <= 0 ? 0.1f : decreaseRate;
        }

        /// <summary>
        /// Add arrows to the stack of arrows when player hits a positive valued point gate.
        /// </summary>
        /// <param name="positiveCount"></param>
        public void AddArrow(int positiveCount)
        {
            for (int i = 0; i < positiveCount; i++)
            {
                SpawnArrow(addedArrows.Count);
            }

            uiManager.SetArrowCountText(addedArrows.Count);
        }

        /// <summary>
        /// SpawnArrow basically spawn arrows radial. I saw something called a planar module on the internet.
        /// In order to obtain the planar module, it was necessary to apply Vogel's formula.
        /// The code written in this method is based on vogel's formula, which helps to spawn the arrows in a spiral way.
        /// </summary>
        /// <param name="n"></param>
        private void SpawnArrow(int n)
        {
            float phi = coefficient * Mathf.Sqrt(n);
            float r = n * 137.5f * 0.000025f * GetSpawnRadiusDecreaseRate(n);
            Vector3 point = new Vector3(0, Mathf.Sin(phi) * r, Mathf.Cos(phi) * r);

            var position = playerTransform.position;
            GameObject obj = Instantiate(arrow, position, Quaternion.identity);
            obj.transform.localPosition = point + new Vector3(position.x - spawnPosXOffset,
                position.y - spawnPosYOffset,
                position.z);
            obj.transform.SetParent(playerTransform);
            addedArrows.Add(obj);
        }

        /// <summary>
        /// Removes arrows when player hits negative valued gate.
        /// </summary>
        /// <param name="negativeCount"></param>
        public void RemoveArrow(int negativeCount)
        {
            for (int i = 0; i < negativeCount; i++)
            {
                if (addedArrows.Count <= 1) return;

                GameObject lastElement = addedArrows.LastOrDefault();
                addedArrows.Remove(lastElement);
                Destroy(lastElement);

                uiManager.SetArrowCountText(addedArrows.Count);
            }
        }

        /// <summary>
        /// SpawnArrowsSpiralShape method is just for give spiral shape to arrows you spawn at start of the game.
        /// </summary>
        private void SpawnArrowsSpiralShape()
        {
            for (int n = 1; n <= numberOfSpawns; n++)
            {
                SpawnArrow(n);
            }
        }
    }
}