using Game.Engine.EngineBase;
using Game.Engine.EngineInterfaces;
using Game.Engine.EngineModels;
using Game.Models;

namespace Game.Engine.EngineGame
{
    /// <summary>
    /// Battle Engine for the Game
    /// </summary>
    public class BattleEngine : BattleEngineBase, IBattleEngineInterface
    {

        // The BaseEngine
        public new EngineSettingsModel EngineSettings { get; } = EngineSettingsModel.Instance;

        /// <summary>
        /// Default Construtor
        /// </summary>
        public BattleEngine()
        {
            Round = new RoundEngine();
        }

        /// <summary>
        /// Add the charcter to the character list
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public override bool PopulateCharacterList(CharacterModel data)
        {
            // INFO: Teams, work out your turn logic
            return base.PopulateCharacterList(data);
        }

        /// <summary>
        /// Start the Battle
        /// </summary>
        /// <param name="isAutoBattle"></param>
        /// <returns></returns>
        public override bool StartBattle(bool isAutoBattle)
        {
            return base.StartBattle(isAutoBattle);
        }

        /// <summary>
        /// End the Battle
        /// </summary>
        /// <returns></returns>
        public override bool EndBattle()
        {
            return base.EndBattle();
        }
    }
}