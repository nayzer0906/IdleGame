using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class CustomerManager : Singleton<CustomerManager>
{
    public List<Transform> spawnPoints = new List<Transform>();
    public List<Transform> destinations = new List<Transform>();
    private int currentCustomersAmount = 0;
    private int customersAmountLimit = 6;

    private void Awake()
    {
        CustomerPool.Instance.onPoolCreated += () =>
        {
            for (int i = 0; i < customersAmountLimit; i++)
            {
                SpawnCustomer();
            }
            StartCoroutine(Spawning());
        };
    }

    private void SpawnCustomer()
    {
        var customer = CustomerPool.Instance.GetPooledCustomer();

        if (customer != null)
        {
            var spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];
            var destination = destinations[Random.Range(0, destinations.Count)];

            customer.gameObject.SetActive(true);
            customer.Init(spawnPoint, destination);
        }
    }

    public void SetCustomersAmount(int val)
    {
        currentCustomersAmount += val;
    }

    public IEnumerator Spawning()
    {
        while (true)
        {
            var wait = new WaitForSeconds(3.0f);
            if (currentCustomersAmount >= customersAmountLimit)
            {
                yield return wait;
                continue;
            }

            SpawnCustomer();
            yield return wait;
        }
    }
}