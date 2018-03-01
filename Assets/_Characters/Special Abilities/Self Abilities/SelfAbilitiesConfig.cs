using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Characters
{
    [CreateAssetMenu(menuName = ("RPG/Special Ability/Self Abilities"))]
    public class SelfAbilitiesConfig : AbilityConfig
    {
        [Header("Self Ability Specific")]
        [SerializeField] float healing = 50f;

        public override AbilityBehaviour GetBehaviourComponent(GameObject objectToAttactTo)
        {
            return objectToAttactTo.AddComponent<SelfAbilitiesBehavior>();
        }

        public float GetHealing()
        {
            return healing;
        }
    }

}
