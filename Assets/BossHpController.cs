using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHpController : MonoBehaviour
{
    [SerializeField]
    private int hpAmount = 10;
    [SerializeField]
    private GameObject objectToSpawn;

    private bool isWaiting;

    [SerializeField]
    private Transform positionToSpawnObject;

    private GameObject player;

    public void OnCollisionEnter(Collision collision)
    {
        Rigidbody rigidBody = collision.collider.GetComponent<Rigidbody>();
        if (rigidBody != null && collision.relativeVelocity.magnitude > 10)
        {
            hpAmount--;
            Destroy(collision.collider.gameObject);
            Debug.Log("hp: " + hpAmount);
        }

    }

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Update()
    {
        if (hpAmount == 0)
        {
            Debug.Log("killed");
        }
        if (!isWaiting)
        {
            StartCoroutine(attack());

        }

    }

    private IEnumerator attack()
    {
        isWaiting = true;
        yield return new WaitForSeconds(5);
        GameObject spawnedObject = Instantiate(objectToSpawn, positionToSpawnObject.position, Quaternion.identity);
        Rigidbody rigidBody
            = spawnedObject.GetComponentInChildren<Rigidbody>();
        rigidBody.AddForce(player.transform.position - spawnedObject.transform.position, ForceMode.VelocityChange);
        Debug.Log("attack");
        isWaiting = false;
    }

}
