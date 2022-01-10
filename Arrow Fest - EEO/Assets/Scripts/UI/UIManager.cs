using TMPro;
using UnityEngine;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text arrowCounterText;
        
        [SerializeField]
        private TMP_Text finalGoldText;
        
        [SerializeField]
        private GameObject endGameScreen;

        /// <summary>
        /// finalGold float is actually the reward of 10 gold with multiplication of platform that arrows went to. SetFinalGoldText makes the TMP be written with a line of string with rewarded gold.
        /// </summary>
        /// <param name="finalGold"></param>
        public void SetFinalGoldText(float finalGold)
        {
            finalGoldText.text = $"Congratulations!\nYou have rewarded {finalGold} gold.";
        }

        /// <summary>
        /// SetArrowCountText method makes a text to show the player how many arrows it has.
        /// </summary>
        /// <param name="count"></param>
        public void SetArrowCountText(int count)
        {
            arrowCounterText.text = count.ToString();
        }
        
        /// <summary>
        /// ShowEndGameScreen sets active the panel that has final texts in it while fading the screen.
        /// </summary>
        public void ShowEndGameScreen()
        {
            endGameScreen.SetActive(true);
        }
    }
}
