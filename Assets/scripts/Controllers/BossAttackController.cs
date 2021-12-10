using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackController : MonoBehaviour
{
    private const int SECONDS_BETWEEN_ATTACKS = 3;
    [SerializeField]
    private GameObject objectToSpawn;

    private bool isWaitingForNextAttack;

    [SerializeField]
    private List<Transform> positionsToSpawnObject;

    private GameObject player;

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag(TagsManager.PLAYER);
    }

    void FixedUpdate()
    {
        if (!isWaitingForNextAttack)
        {
            StartCoroutine(Attack());

        }
    }

    private IEnumerator Attack()
    {
        isWaitingForNextAttack = true;
        yield return new WaitForSeconds(SECONDS_BETWEEN_ATTACKS);
        int indexOfPositionToSpawn = Random.Range(0, positionsToSpawnObject.Count - 1);
        Transform currentPositionToSpawnObject = positionsToSpawnObject[indexOfPositionToSpawn];
        GameObject spawnedObject = Instantiate(objectToSpawn, currentPositionToSpawnObject.position, Quaternion.identity);
        Rigidbody spawnedObjectRB
            = spawnedObject.GetComponentInChildren<Rigidbody>();
        spawnedObjectRB.useGravity = false;
        Vector3 direction = player.transform.position - spawnedObject.transform.position;
        spawnedObjectRB.AddForce(direction, ForceMode.VelocityChange); ;
        isWaitingForNextAttack = false;
    }
}
