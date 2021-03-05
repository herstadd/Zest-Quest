using System.Collections.Generic;

using Game.Models;

namespace Game.Engine.EngineInterfaces
{
    /// <summary>
    /// Turn Engine Interface
    /// </summary>
    public interface ITurnEngineInterface
    {
        /// <summary>
        /// Player takes their turn
        /// </summary>
        /// <param name="Attacker"></param>
        /// <returns></returns>
        bool TakeTurn(PlayerInfoModel Attacker);

        /// <summary>
        /// What action is the player taking
        /// </summary>
        /// <param name="Attacker"></param>
        /// <returns></returns>
        ActionEnum DetermineActionChoice(PlayerInfoModel Attacker);

        /// <summary>
        /// Is the Player moving for their turn
        /// </summary>
        /// <param name="Attacker"></param>
        /// <returns></returns>
        bool MoveAsTurn(PlayerInfoModel Attacker);

        /// <summary>
        /// Player is using their ability
        /// </summary>
        /// <param name="Attacker"></param>
        /// <returns></returns>
        bool ChooseToUseAbility(PlayerInfoModel Attacker);

        /// <summary>
        /// Player chooses the ability they are using
        /// </summary>
        /// <param name="Attacker"></param>
        /// <returns></returns>
        bool UseAbility(PlayerInfoModel Attacker);

        /// <summary>
        /// Player is attacking
        /// </summary>
        /// <param name="Attacker"></param>
        /// <returns></returns>
        bool Attack(PlayerInfoModel Attacker);

        /// <summary>
        /// Player chooses attack
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        PlayerInfoModel AttackChoice(PlayerInfoModel data);

        /// <summary>
        /// Choose which character to attack
        /// </summary>
        /// <returns></returns>
        PlayerInfoModel SelectCharacterToAttack();

        /// <summary>
        /// Choose which monster to attack
        /// </summary>
        /// <returns></returns>
        PlayerInfoModel SelectMonsterToAttack();

        /// <summary>
        /// Which player is attacking which player?
        /// </summary>
        /// <param name="Attacker"></param>
        /// <param name="Target"></param>
        /// <returns></returns>
        bool TurnAsAttack(PlayerInfoModel Attacker, PlayerInfoModel Target);

        /// <summary>
        /// See if the Battle Settings will Override the Hit
        /// </summary>
        /// <param name="Attacker"></param>
        /// <returns></returns>
        HitStatusEnum BattleSettingsOverride(PlayerInfoModel Attacker);

        /// <summary>
        /// Return the Override for the HitStatus
        /// </summary>
        /// <param name="myEnum"></param>
        /// <returns></returns>
        HitStatusEnum BattleSettingsOverrideHitStatusEnum(HitStatusEnum myEnum);

        /// <summary>
        /// Add the Damage from the hit to target
        /// </summary>
        /// <param name="Target"></param>
        int ApplyDamage(PlayerInfoModel Target);

        /// <summary>
        /// Calculate the Attack, return if it hit or missed.
        /// </summary>
        /// <param name="Attacker"></param>
        /// <param name="Target"></param>
        /// <returns></returns>
        HitStatusEnum CalculateAttackStatus(PlayerInfoModel Attacker, PlayerInfoModel Target);

        /// <summary>
        /// Calculate Experience, even level up player
        /// </summary>
        /// <param name="Attacker"></param>
        /// <param name="Target"></param>
        /// <returns></returns>
        bool CalculateExperience(PlayerInfoModel Attacker, PlayerInfoModel Target);

        /// <summary>
        /// If Dead process Target Died
        /// </summary>
        /// <param name="Target"></param>
        /// <returns></returns>
        bool RemoveIfDead(PlayerInfoModel Target);

        /// <summary>
        /// Process the death, and any items dropped
        /// </summary>
        /// <param name="Target"></param>
        /// <returns></returns>
        bool TargetDied(PlayerInfoModel Target);

        /// <summary>
        /// Items that were dropped
        /// </summary>
        /// <param name="Target"></param>
        /// <returns></returns>
        int DropItems(PlayerInfoModel Target);

        /// <summary>
        /// Roll To Hit
        /// </summary>
        /// <param name="AttackScore"></param>
        /// <param name="DefenseScore"></param>
        /// <returns></returns>
        HitStatusEnum RollToHitTarget(int AttackScore, int DefenseScore);

        /// <summary>
        /// Get the droped item randomly
        /// </summary>
        /// <param name="round"></param>
        /// <returns></returns>
        List<ItemModel> GetRandomMonsterItemDrops(int round);

        /// <summary>
        /// Critical Miss Problem
        /// </summary>
        /// <param name="attacker"></param>
        /// <returns></returns>
        bool DetermineCriticalMissProblem(PlayerInfoModel attacker);
    }
}
