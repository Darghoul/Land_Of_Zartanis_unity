using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Characters
{
    public class PowerAttackBehaviour : AbilityBehaviour
    {
        public override void Use(GameObject target)
        {
            Dealdamage(target);
            PlayParticleEffect();
            PlayAbilitySound();
            PlayAbilityAnimation();
        }

        private void Dealdamage(GameObject target)
        {
            float damageToDeal = (config as PowerAttackConfig).GetExtraDamage();
            target.GetComponent<HealthSystem>().TakeDamage(damageToDeal);
        }
    }
}

