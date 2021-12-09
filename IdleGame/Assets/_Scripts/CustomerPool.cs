using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerPool : Singleton<CustomerPool>
{
    private List<Customer> pooledCustomers = new List<Customer>();
    private int customerAmount = 9;
    [SerializeField] private GameObject customerPrefab;

    public Action onPoolCreated;

    private void Start()
    {
        for (int i = 0; i < customerAmount; i++)
        {
            var customerObj = Instantiate(customerPrefab);
            customerObj.SetActive(false);
            var customer = customerObj.GetComponent<Customer>();
            pooledCustomers.Add(customer);
        }

        onPoolCreated?.Invoke();
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