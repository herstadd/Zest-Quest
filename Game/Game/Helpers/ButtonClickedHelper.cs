using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Helpers
{
    /// <summary>
    /// Gives action based on if + / - button was clicked
    /// </summary>
    public static class ButtonClickedHelper
    {

        /// <summary>
        /// Change Stat value when the picker is clicked
        /// </summary>
        /// <param name="ButtonText">Whether the + or - button was clicked</param>
        /// <param name="num">Current value being passed in to be altered</param>
        /// <param name="IsMaxHealth">Indicates if update will affect max health</param>
        /// <param name="maxHealth">Only passed in if for new max health calculation, otherwise default 0</param>
        /// <returns>The resulting value to replace stat value with</returns>
        public static int ValueChange(String ButtonText, int num, bool IsMaxHealth, int maxHealth = 0)
        {
            if (ButtonText.Equals("-"))
            {
                if (IsMaxHealth)
                {
                    num--;
                    return num < 1 ? maxHealth : DiceHelper.RollDice(num, 10);
                }
                num--;
                return num < 1 ? 1 : num;
            }
            else
            {
                if (IsMaxHealth)
                {
                    return maxHealth + DiceHelper.RollDice(1, 10);
                }
                return num + 1;
            }
        }
    }
}
