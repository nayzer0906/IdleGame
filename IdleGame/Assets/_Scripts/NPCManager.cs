using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

[RequireComponent(typeof(NavMeshAgent))]
public class NPCManager : MonoBehaviour
{
   [SerializeField] private Transform buildingPosition;
   [SerializeField] private Transform spawnPosition;
   private NavMeshAgent npc;

   private void Awake()
   {
      npc = GetComponent<NavMeshAgent>();
      npc.transform.position = spawnPosition.position;
   }

   private void Update()
   {
       npc.destination = buildingPosition.position;
   }
}
