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

        /// <summary>
        /// Define the Battle variable 
        /// </summary>
        //public new IBattleEngineInterface Battle
        //{
        //    get
        //    {
        //        if (base.Battle == null)
        //        {
        //            base.Battle = new BattleEngine
        //            {
        //                Round = new RoundEngine()
        //                {
        //                    Turn = new TurnEngine()
        //                }
        //            };
        //        }
        //        return base.Battle;
        //    }
        //    set { base.Battle = Battle; }
        //}

        public AutoBattleEngine()
        {
            Battle = new BattleEngine();
        }


        /// <summary>
        /// Create character list and monster list
        /// </summary>
        /// <returns></returns>
        public override bool CreateCharacterParty()
        {
            return base.CreateCharacterParty();
            ////throw new System.NotImplementedException();
        }

        /// <summary>
        /// detect if there's infinite rounds (no game end)
        /// </summary>
        /// <returns></returns>
        public override bool DetectInfinateLoop()
        {
            return base.DetectInfinateLoop();
            ////throw new System.NotImplementedException();
        }

        /// <summary>
        /// Start the automatic battle
        /// </summary>
        /// <returns></returns>
        public override Task<bool> RunAutoBattle()
        {
            return base.RunAutoBattle();
            //throw new System.NotImplementedException();
        }
    }
}