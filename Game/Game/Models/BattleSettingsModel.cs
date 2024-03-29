﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Models
{
    /// <summary>
    /// Example of Battle Settings Control
    /// </summary>
    public class BattleSettingsModel
    {
        // The Battle Model (Simple, Map, etc.)
        public BattleModeEnum BattleModeEnum = BattleModeEnum.MapNext;

        // Monster always Hit or Miss or Default
        public HitStatusEnum MonsterHitEnum = HitStatusEnum.Default;

        // Characters always Hit or Miss or Default
        public HitStatusEnum CharacterHitEnum = HitStatusEnum.Default;

        // Are Critical Hits Allowed?
        public bool AllowCriticalHit = false;

        // Are Critical Misses Allowed?
        public bool AllowCriticalMiss = false;

        // Can monsters have Items and weapons?
        public bool AllowMonsterItems = false;

        // Enable Seattle Winter?
        public bool EnableSeattleWinter = false;

        public int SeattleWinterSlippingPercent = 50;

        // Enable Sleepless Zombies in Seattle?
        public bool EnableSleeplessZombie = false;

        // Set Sleepless Zombie Percentage
        public int SleeplessZombiePercent = 50;
    }
}