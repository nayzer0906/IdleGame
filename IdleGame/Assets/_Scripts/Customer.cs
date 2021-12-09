using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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
        Move(destination.position);
    }

    public void Move(Vector3 dest)
    {
        navMeshAgent.SetDestination(dest);
    }

    public void Buy()
    {
        CoinsManager.Instance.OnCoinsChanged?.Invoke(50);
        isOnWayBack = true;
        Move(spawnPoint.position);
    }

    private void Unload()
    {
        gameObject.SetActive(false);
        CustomerManager.Instance.SetCustomersAmount(-1);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Building")
            Buy();

        if (other.gameObject.tag == "SpawnPoint" && isOnWayBack)
            Unload();

    }
}