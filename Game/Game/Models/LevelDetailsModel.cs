namespace Game.Models
{
    /// <summary>
    /// Hold the Details for each Level
    /// </summary>
    public class LevelDetailsModel
    {
        // The Level
        public int Level;
        
        // Experience points to achieve the level
        public int Experience;

        // Attack Bonus
        public int Attack;
        
        // Defense Bonus
        public int Defense;
        
        // Speed Bonus
        public int Speed;

        /// <summary>
        /// Create a new level based on values passed in
        /// </summary>
        /// <param name="level"></param>
        /// <param name="experience"></param>
        /// <param name="attack"></param>
        /// <param name="defense"></param>
        /// <param name="speed"></param>
        public LevelDetailsModel(int level, int experience, int attack, int defense, int speed)
        {
            Level = level;
            Experience = experience;
            Attack = attack;
            Defense = defense;
            Speed = speed;
        }
    }
}