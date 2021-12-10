using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Customer : MonoBehaviour
{
    private Transform spawnPoint;
    private Transform destination;
    private NavMeshAgent navMeshAgent;
    private bool isOnWayBack;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public void Init(Transform spawn, Transform dest)
    {
        CustomerManager.Instance.SetCustomersAmount(+1);
        spawnPoint = spawn;
        destination = dest;
        isOnWayBack = false;
        transform.position = spawnPoint.position;
        MoveTowards(destination.position);
    }

    public void MoveTowards(Vector3 dest)
    {
        navMeshAgent.SetDestination(dest);
    }

    public void MakePurchase(Building selectedBuilding)
    {
        CoinsManager.Instance.OnCoinsChanged?.Invoke(selectedBuilding.income);
        isOnWayBack = true;
        MoveTowards(spawnPoint.position);
    }

    private void Unload()
    {
        gameObject.SetActive(false);
        CustomerManager.Instance.SetCustomersAmount(-1);
    }

    private void OnTriggerEnter(Collider other)
    {
        var building = other.gameObject.GetComponent<Building>();
        if (building)
        {
            MakePurchase(building);
        }

        if (other.CompareTag("SpawnPoint") && isOnWayBack)
            Unload();
    }
}