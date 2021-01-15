using System.Threading.Tasks;
using Game.Engine.EngineBase;
using Game.Engine.EngineInterfaces;

namespace Game.Engine.EngineGame
{
    /// <summary>
    /// AutoBattle Engine
    /// 
    /// Runs the engine simulation with no user interaction
    /// 
    /// </summary>
    public class AutoBattleEngine : AutoBattleEngineBase, IAutoBattleInterface
    {
        #region Algrorithm
        // Prepare for Battle
        // Pick 6 Characters
        // Initialize the Battle
        // Start a Round

        // Fight Loop
        // Loop in the round each turn
        // If Round is over, Start New Round
        // Check end state of round/game

        // Wrap up
        // Get Score
        // Save Score
        // Output Score
        #endregion Algrorithm

        public new IBattleEngineInterface Battle
        {
            get
            {
                if (base.Battle == null)
                {
                    base.Battle = new BattleEngine();
                }
                return base.Battle;
            }
            set { base.Battle = Battle; }
        }

        public override bool CreateCharacterParty()
        {
            throw new System.NotImplementedException();
        }

        public override bool DetectInfinateLoop()
        {
            throw new System.NotImplementedException();
        }

        public override Task<bool> RunAutoBattle()
        {
            throw new System.NotImplementedException();
        }
    }
}