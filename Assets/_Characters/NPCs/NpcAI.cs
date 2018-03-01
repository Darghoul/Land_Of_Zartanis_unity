using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Characters
{
    
    [RequireComponent(typeof(Character))]
    public class NpcAI : MonoBehaviour
    {
        [SerializeField] WaypointContainer patrolPath;
        [SerializeField] float waypointTolerance = 2.0f;
        [SerializeField] float waypointDwellTime = 2.0f;
        [SerializeField] float chaseRadius = 2f;

        PlayerControl player = null;
        Character character;
        int nextWaypointIndex;
        float currentWeaponRange;
        float distanceToPlayer;

        enum State { idle, patrolling}
        State state = State.idle;

        void Start()
        {
            character = GetComponent<Character>();
            player = FindObjectOfType<PlayerControl>();
        }

        void Update()
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
            if (distanceToPlayer <= chaseRadius)
            {
                StopAllCoroutines();
                state = State.idle;
                //RequestPlayAudioClip();
            }
            else
            {
                state = State.patrolling;
            }
            if (state == State.patrolling)
            {
                StopAllCoroutines();
                StartCoroutine(Patrol());
            }
        }

        public void SetChaseRadius(float newChaseRadius)
        {
            chaseRadius = newChaseRadius;
        }

        IEnumerator Patrol()
        {
            state = State.patrolling;

            while (patrolPath != null)
            {
                Vector3 nextWaypointPos = patrolPath.transform.GetChild(nextWaypointIndex).position;
                character.SetDestination(nextWaypointPos);
                CycleWaypointWhenClose(nextWaypointPos);
                yield return new WaitForSeconds(waypointDwellTime);
            }
        }

        private void CycleWaypointWhenClose(Vector3 nextWaypointPos)
        {
            if (Vector3.Distance(transform.position, nextWaypointPos) <= waypointTolerance)
            {
                nextWaypointIndex = (nextWaypointIndex + 1) % patrolPath.transform.childCount;
            }
        }

    }
}