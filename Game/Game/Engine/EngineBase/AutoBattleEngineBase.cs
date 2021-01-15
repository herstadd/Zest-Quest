using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Game.Engine.EngineInterfaces;
using Game.Engine.EngineModels;
using Game.GameRules;
using Game.Models;
using Game.ViewModels;

namespace Game.Engine.EngineBase
{
    /// <summary>
    /// AutoBattle Engine
    /// 
    /// Runs the engine simulation with no user interaction
    /// 
    /// </summary>
    public class AutoBattleEngineBase : IAutoBattleInterface
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

        // The Battle Engine
        public IBattleEngineInterface Battle { get; set; } = null;

        /// <summary>
        /// Run Auto Battle
        /// </summary>
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public virtual async Task<bool> RunAutoBattle()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            RoundEnum RoundCondition;

            Debug.WriteLine("Auto Battle Starting");

            // Auto Battle, does all the steps that a human would do.

            // Prepare for Battle

            CreateCharacterParty();

            // Start Battle in AutoBattle mode
            Battle.StartBattle(true);

            // Fight Loop. Continue until Game is Over...
            do
            {
                // Check for excessive duration.
                if (DetectInfinateLoop())
                {
                    Debug.WriteLine("Aborting, More than Max Rounds");
                    Battle.EndBattle();
                    return false;
                }

                Debug.WriteLine("Next Turn");

                // Do the turn...
                // If the round is over start a new one...
                RoundCondition = Battle.Round.RoundNextTurn();

                if (RoundCondition == RoundEnum.NewRound)
                {
                    Battle.Round.NewRound();
                    Debug.WriteLine("New Round");
                }

            } while (RoundCondition != RoundEnum.GameOver);

            Debug.WriteLine("Game Over");

            // Wrap up
            Battle.EndBattle();

            return true;
        }

        /// <summary>
        /// Check if the Engine is not ending
        /// 
        /// Too many Rounds
        /// Too many Turns in a round
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual bool DetectInfinateLoop()
        {
            if (Battle.EngineSettings.BattleScore.RoundCount > Battle.EngineSettings.MaxRoundCount)
            {
                return true;
            }

            if (Battle.EngineSettings.BattleScore.TurnCount > Battle.EngineSettings.MaxTurnCount)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Create Characters for Party
        /// </summary>
        public virtual bool CreateCharacterParty()
        {
            // Picks 6 Characters

            // To use your own characters, populate the List before calling RunAutoBattle

            //// Will first pull from existing characters
            //foreach (var data in CharacterIndexViewModel.Instance.Dataset)
            //{
            //    if (Battle.EngineSettings.CharacterList.Count() >= Battle.EngineSettings.MaxNumberPartyCharacters)
            //    {
            //        break;
            //    }

            //    // Start off with max health if adding a character in
            //    data.CurrentHealth = data.GetMaxHealthTotal;
            //    Battle.PopulateCharacterList(data);
            //}

            //If there are not enough will add random ones
            for (int i = Battle.EngineSettings.CharacterList.Count(); i < Battle.EngineSettings.MaxNumberPartyCharacters; i++)
            {
                Battle.PopulateCharacterList(RandomPlayerHelper.GetRandomCharacter(1));
            }

            return true;
        }
    }
}