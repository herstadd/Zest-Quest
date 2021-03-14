namespace Game.Models
{
    /// <summary>
    /// The Types of s a Action can have
    /// Used in Action Crudi, and in Battles.
    /// </summary>
    public enum ActionEnum
    {
        // Not specified
        Unknown = 0,

        // Attack
        Attack = 1,

        // Move
        Move = 10,

        // Ability
        Ability = 20
    }

    /// <summary>
    /// Friendly strings for the Enum Class
    /// </summary>
    public static class ActionEnumExtensions
    {
        /// <summary>
        /// Display a String for the Enums
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToMessage(this ActionEnum value)
        {
            // Default String
            var Message = "None";

            switch (value)
            {
                case ActionEnum.Attack:
                    Message = " Attacks ";
                    break;

                case ActionEnum.Move:
                    Message = " Moves ";
                    break;

                case ActionEnum.Ability:
                    Message = " Uses Ability ";
                    break;

                case ActionEnum.Unknown:
                default:
                    break;
            }

            return Message;
        }

        /// <summary>
        /// Display a String for the Enums
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToImageURI(this ActionEnum value)
        {
            // Default String
            var Message = "zest_quest_icon2.png";

            switch (value)
            {
                case ActionEnum.Attack:
                    Message = "sword_attack.png";
                    break;

                case ActionEnum.Move:
                    Message = "boot_walking.png";
                    break;

                case ActionEnum.Ability:
                    Message = "mushroom.png";
                    break;

                case ActionEnum.Unknown:
                default:
                    break;
            }

            return Message;
        }
    }
}