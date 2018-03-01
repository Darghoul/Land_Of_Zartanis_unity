using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace RPG.Characters
{
    public class SelfAbilitiesBehavior : AbilityBehaviour
    {
        PlayerControl player;
 
        // Use this for initialization
        void Start()
        {
            player = GetComponent<PlayerControl>();
        }

        public override void Use(GameObject target)
        {
            HealingDamage();
            PlayParticleEffect();
            PlayAbilitySound();
            PlayAbilityAnimation();
        }

        private void HealingDamage()
        {
            var playerHealth = player.GetComponent<HealthSystem>();
            playerHealth.Heal((config as SelfAbilitiesConfig).GetHealing());
        }
    }
}