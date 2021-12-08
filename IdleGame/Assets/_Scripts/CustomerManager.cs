using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class CustomerManager : MonoBehaviour
{
   [SerializeField] private Transform buildingPosition;
   [SerializeField] private Transform spawnPosition;
   private bool goToSpawn;

   private void Awake()
   {
      
   }

   void Update()
   {
      MoveCustomer();
   }

   private void OnTriggerEnter(Collider other)
   {
       if(other.gameObject.tag == "Building")
        goToSpawn = true;
   }

   private void MoveCustomer()
   {
      var customer = CustomerPool.instance.GetPooledCustomer();
      if (customer != null)
      {
         customer.transform.position = spawnPosition.position;
         customer.SetActive(true);
      }

      var customerAI = customer.GetComponent<NavMeshAgent>();
      if (!goToSpawn)
      {
         customerAI.destination = buildingPosition.position;
      }
      else
      {
         customerAI.destination = spawnPosition.position;
      }
   }
}
