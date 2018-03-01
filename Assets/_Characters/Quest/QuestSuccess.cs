using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Characters
{
    public class QuestSuccess : MonoBehaviour
    {
        int monsterKill = 0;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            
            if (monsterKill >= 14)
            {
                Destroy(gameObject);
            }
        }

        public void SetMonsterkill(int kill)
        {
            monsterKill += kill;
        }

        public int GetMonsterKill()
        {
            return monsterKill;
        }
    }
}

