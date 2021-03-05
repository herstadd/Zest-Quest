using System.Threading.Tasks;

namespace Game.Engine.EngineInterfaces
{
    /// <summary>
    /// Interfaces for the Auto Battle Engine
    /// </summary>
    public interface IAutoBattleInterface
    {
        // Battle Engine
        IBattleEngineInterface Battle { get;}

        /// <summary>
        /// Start the auto battle
        /// </summary>
        /// <returns></returns>
        Task<bool> RunAutoBattle();

        /// <summary>
        /// Check if there's no end to the game
        /// </summary>
        /// <returns></returns>
        bool DetectInfinateLoop();

        /// <summary>
        /// Create the character party based on selected characters
        /// </summary>
        /// <returns></returns>
        bool CreateCharacterParty();
    }
}