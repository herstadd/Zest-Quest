namespace Game.Models
{
    /// <summary>
    /// The Types of s a Action can have
    /// Used in Action Crudi, and in Battles.
    /// </summary>
    public enum DescriptionEnum
    {
        // Not specified
        Unknown = 0,

        // HeadChef
        HeadChef = 1,

        // SousChef
        SousChef = 10,

        // SchoolChef
        SchoolChef = 20,

        // SushiChef
        SushiChef = 30,

        // CatChef
        CatChef = 40,

        // HomeCook
        HomeCook = 50
    }

    /// <summary>
    /// Friendly strings for the Enum Class
    /// </summary>
    public static class DescriptionEnumExtensions
    {
        /// <summary>
        /// Display a String for the Enums
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToMessage(this DescriptionEnum value)
        {
            // Default String
            var Message = "None";

            switch (value)
            {
                case DescriptionEnum.HeadChef:
                    Message = "Each item grants this character double the normal stat modifier";
                    break;

                case DescriptionEnum.SousChef:
                    Message = "This character's attack attribute will be 3 times stronger than usual for the first attack in every round";
                    break;

                case DescriptionEnum.SchoolChef:
                    Message = "Provide a 20% attack buff to the rest of team if the school chef dies in a battle";
                    break;

                case DescriptionEnum.SushiChef:
                    Message = "Has the ability to attack from anywhere on the map with any item";
                    break;

                case DescriptionEnum.CatChef:
                    Message = "Has nine lives (so if character dies, comes back to life 8 more times,) but cannot hold more than one item at a time";
                    break;

                case DescriptionEnum.HomeCook:
                    Message = "After winning a battle their current health will be recovered by 10% of original max health up to max health";
                    break;

                case DescriptionEnum.Unknown:
                default:
                    break;
            }

            return Message;
        }

        public static string getPicture(this DescriptionEnum value)
        {
            // Default String
            var Picture = "None";

            switch (value)
            {
                case DescriptionEnum.HeadChef:
                    Picture = "headchef.png";
                    break;

                case DescriptionEnum.SousChef:
                    Picture = "souschef.png";
                    break;

                case DescriptionEnum.SchoolChef:
                    Picture = "schoolchef.png";
                    break;

                case DescriptionEnum.SushiChef:
                    Picture = "sushichef.png";
                    break;

                case DescriptionEnum.CatChef:
                    Picture = "catchef.png";
                    break;

                case DescriptionEnum.HomeCook:
                    Picture = "homechef.png";
                    break;

                case DescriptionEnum.Unknown:
                default:
                    break;
            }
            return Picture;
        }




                    /// <summary>
                    /// Converts a string to the enum representation
                    /// </summary>
                    /// <param name="value"></param>
                    /// <returns></returns>
                    public static DescriptionEnum ToEnum(string value)
        {
            var Type = DescriptionEnum.Unknown;

            switch (value)
            {
                case "HeadChef":
                    Type = DescriptionEnum.HeadChef;
                    break;

                case "SousChef":
                    Type = DescriptionEnum.SousChef;
                    break;

                case "SchoolChef":
                    Type = DescriptionEnum.SchoolChef;
                    break;

                case "SushiChef":
                    Type = DescriptionEnum.SushiChef;
                    break;

                case "CatChef":
                    Type = DescriptionEnum.CatChef;
                    break;

                case "HomeCook":
                    Type = DescriptionEnum.HomeCook;
                    break;

                case "Unknown":
                default:
                    break;
            }

            return Type;
        }
    }
}