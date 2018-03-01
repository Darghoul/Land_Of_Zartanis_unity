using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Characters
{
    public class QuestOne : MonoBehaviour
    {
        QuestSuccess questSuccess;
        NpcAI npcAI;
        // Use this for initialization
        void Start()
        {
            questSuccess = FindObjectOfType<QuestSuccess>();
            npcAI = FindObjectOfType<NpcAI>();
        }

        // Update is called once per frame
        void Update()
        {
            var questOne = questSuccess.GetMonsterKill();
            if (questOne >= 14)
            {
                npcAI.SetChaseRadius(2f);
            }
        }
    }
}

