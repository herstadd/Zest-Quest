
using Game.Engine.EngineInterfaces;
using Game.Engine.EngineModels;
using Game.Models;

namespace Game.Engine.EngineBase
{
    /// <summary>
    /// Battle Engine for the Game
    /// </summary>
    public class BattleEngineBase : IBattleEngineInterface
    {
        // The Round
        public IRoundEngineInterface Round { get; set; } = null;

        // Engine Sttings
        public EngineSettingsModel EngineSettings { get; } = EngineSettingsModel.Instance;

        // Track if the Battle is Running or Not
        public bool BattleRunning = false;

        /// <summary>
        /// Set the Battle State
        /// </summary>
        public virtual bool SetBattleStateEnum(BattleStateEnum data)
        {
            EngineSettings.BattleStateEnum = data;

            return true;
        }

        /// <summary>
        /// Add the charcter to the character list
        /// </summary>
        public virtual bool PopulateCharacterList(CharacterModel data)
        {
            EngineSettings.CharacterList.Add(new PlayerInfoModel(data));

            return true;
        }

        /// <summary>
        /// Start the Battle
        /// </summary>
        /// <param name="isAutoBattle"></param>
        /// <returns></returns>
        public virtual bool StartBattle(bool isAutoBattle)
        {
            // Reset the Score so it is fresh
            EngineSettings.BattleScore = new ScoreModel
            {
                AutoBattle = isAutoBattle
            };

            BattleRunning = true;

            Round.NewRound();

            return true;
        }

        /// <summary>
        /// End the Battle
        /// </summary>
        /// <returns></returns>
        public virtual bool EndBattle()
        {
            BattleRunning = false;

            EngineSettings.BattleScore.CalculateScore();

            return true;
        }
    }
}