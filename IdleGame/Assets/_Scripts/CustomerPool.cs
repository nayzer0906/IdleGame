using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerPool : MonoBehaviour
{
    public static CustomerPool instance;
    private List<Customer> pooledCustomers = new List<Customer>();
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
            var customerCs = customerObj.GetComponent<Customer>();
            customerObj.SetActive(false);
            pooledCustomers.Add(customerCs);
        }
    }

    public Customer GetPooledCustomer()
    {
        for (int i = 0; i < pooledCustomers.Count; i++)
        {
            if (!pooledCustomers[i].gameObject.activeInHierarchy)
                return pooledCustomers[i];
        }

        return null;
    }
}
