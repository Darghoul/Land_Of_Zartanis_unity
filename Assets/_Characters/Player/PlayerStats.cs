using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Characters
{
    public class PlayerStats : MonoBehaviour
    {

        int level = 0;
        int xp = 0;
        int nextLevel = 2000;



        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (xp >= nextLevel)
            {
                level += 1;
                nextLevel += nextLevel;

            }
        }

        public void SetXP(int xp)
        {
            this.xp += xp;
        }
    }
}

