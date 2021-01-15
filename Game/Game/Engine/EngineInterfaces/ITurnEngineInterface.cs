using System.Collections.Generic;

using Game.Models;

namespace Game.Engine.EngineInterfaces
{
    public interface ITurnEngineInterface
    {
        bool TakeTurn(PlayerInfoModel Attacker);
        ActionEnum DetermineActionChoice(PlayerInfoModel Attacker);
        bool MoveAsTurn(PlayerInfoModel Attacker);
        bool ChooseToUseAbility(PlayerInfoModel Attacker);
        bool UseAbility(PlayerInfoModel Attacker);
        bool Attack(PlayerInfoModel Attacker);
        PlayerInfoModel AttackChoice(PlayerInfoModel data);
        PlayerInfoModel SelectCharacterToAttack();
        PlayerInfoModel SelectMonsterToAttack();
        bool TurnAsAttack(PlayerInfoModel Attacker, PlayerInfoModel Target);
        HitStatusEnum BattleSettingsOverride(PlayerInfoModel Attacker);
        HitStatusEnum BattleSettingsOverrideHitStatusEnum(HitStatusEnum myEnum);
        void ApplyDamage(PlayerInfoModel Target);
        HitStatusEnum CalculateAttackStatus(PlayerInfoModel Attacker, PlayerInfoModel Target);
        bool CalculateExperience(PlayerInfoModel Attacker, PlayerInfoModel Target);
        bool RemoveIfDead(PlayerInfoModel Target);
        bool TargetDied(PlayerInfoModel Target);
        int DropItems(PlayerInfoModel Target);
        HitStatusEnum RollToHitTarget(int AttackScore, int DefenseScore);
        List<ItemModel> GetRandomMonsterItemDrops(int round);
        bool DetermineCriticalMissProblem(PlayerInfoModel attacker);
    }
}
