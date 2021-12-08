using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerPool : MonoBehaviour
{
    public static CustomerPool instance;
    private List<GameObject> pooledCustomers = new List<GameObject>();
    private int customerAmount = 9;
    [SerializeField] private GameObject customerPrefab;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        for (int i = 0; i < customerAmount; i++)
        {
            var customerObj = Instantiate(customerPrefab);
            customerObj.SetActive(false);
            pooledCustomers.Add(customerObj);
        }
    }

    public GameObject GetPooledCustomer()
    {
        for (int i = 0; i < pooledCustomers.Count; i++)
        {
            if (!pooledCustomers[i].activeInHierarchy)
                return pooledCustomers[i];
        }

        return null;
    }
}
