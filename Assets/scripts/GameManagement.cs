using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using UnityEngine.UI;
using Assets.scripts.States;
public class GameManagement : MonoBehaviour
{

    public GameObject pickableObjectMarker;
    public GameObject dale;
    public Vector3 minDistanceToPick = new Vector3(0.1f, 0.1f, 0.1f);
    public Vector3 destination;
    public Animator animationController;
    public GameObject carryingPosition;
    private Collider objectReadyToPick;
    private bool isCarryingObject;
    private ThirdPersonMovement thirdPersonMovement;
    private bool isPushing;
    public const int force = 3000;

    private const int HP_DECREASE_VALUE = 20;
    public int hpMaxValue = 100;
    private DaleHealth daleHealth;
    public Slider daleHPSlider;

    private bool timeOffsetPassedBetweenDrainingHP = true;
    private const int SECONDS_BETWEEN_DRAINING_HP = 2;
    public GameObject objectsMarker;
    private DaleStateHandler daleStateHandler;

    public static GameManagement instance;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        thirdPersonMovement = FindObjectOfType<ThirdPersonMovement>();
        daleHealth = GetPlayer.instance.player.GetComponent<DaleHealth>();
        daleHealth.health = hpMaxValue;
        daleHPSlider.maxValue = hpMaxValue;
        daleHPSlider.value = hpMaxValue;
        daleStateHandler = FindObjectOfType<DaleStateHandler>();
    }

    void Update()
    {


    }

    public void HandleShowingPickableObjectMarker(Collider other)
    {
        if (other.attachedRigidbody != null && other.attachedRigidbody.mass < 20)
        {
            daleStateHandler.ObjectToPickup = other.gameObject;
            objectsMarker.SetActive(true);
            Vector3 positionForMarker = other.transform.position;
            positionForMarker.y += other.bounds.size.y / 2 + objectsMarker.GetComponent<MeshRenderer>().bounds.size.y / 2;
            objectsMarker.transform.position = positionForMarker;
        }
    }

    public void HidePickableObjectMarker()
    {
        objectsMarker.SetActive(false);
    }

    public void DecreasePlayerHP()
    {
        if (timeOffsetPassedBetweenDrainingHP)
        {
            StartCoroutine(DrainHpFromPlayer());
        }
    }

    IEnumerator DrainHpFromPlayer()
    {
        timeOffsetPassedBetweenDrainingHP = false;
        daleHealth.health = daleHealth.health - HP_DECREASE_VALUE;
        daleHPSlider.value = daleHealth.health;
        yield return new WaitForSeconds(SECONDS_BETWEEN_DRAINING_HP);
        timeOffsetPassedBetweenDrainingHP = true;


    }

    void notImplementedYet()
    {
        Collider colliderComponent = dale.GetComponent<Collider>();
        Collider[] colliders = Physics.OverlapBox(dale.transform.position, colliderComponent.bounds.extents + minDistanceToPick);
        IEnumerable<Collider> pickableObjects = colliders.Where(collider => collider.GetComponent<Rigidbody>() != null && collider.GetComponent<Rigidbody>().mass < 10);
        foreach (Collider objectNextToMe in pickableObjects)
        {
            if (!isCarryingObject)
            {
                pickableObjectMarker.transform.position = objectNextToMe.transform.position;
                pickableObjectMarker.SetActive(true);
                objectReadyToPick = objectNextToMe;
            }

            if (Input.GetKeyDown(KeyCode.B))
            {
                animationController.SetBool("isCrouching", true);
                pickableObjectMarker.SetActive(false);
                isCarryingObject = true;
            }
            if (Input.GetKey(KeyCode.P))
            {
                objectNextToMe.transform.parent = carryingPosition.transform;
                thirdPersonMovement.enabled = false;
                isPushing = true;
            }
            else if (isPushing)
            {
                objectNextToMe.transform.parent = null;
                thirdPersonMovement.enabled = true;
                isPushing = false;
            }

        }
        if (!pickableObjects.Any())
        {
            pickableObjectMarker.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Space) && isCarryingObject)
        {
            animationController.SetBool("isThrowing", true);
        }
    }

    public void SetIdle()
    {
        isCarryingObject = false;
    }

    public Collider PickupObject()
    {
        Rigidbody rigidBody = objectReadyToPick.GetComponent<Rigidbody>();
        rigidBody.useGravity = false;
        rigidBody.velocity = Vector3.zero;
        rigidBody.angularVelocity = Vector3.zero;
        objectReadyToPick.transform.parent = carryingPosition.transform;
        objectReadyToPick.transform.position = carryingPosition.transform.position;
        return objectReadyToPick;
    }

    public void Throw()
    {
        Rigidbody rigidBody = objectReadyToPick.GetComponent<Rigidbody>();
        rigidBody.useGravity = true;
        Vector3 daleForward = dale.transform.forward;
        rigidBody.AddForce((daleForward + Vector3.up * 0.27f * daleForward.x) * force);
        objectReadyToPick.transform.parent = null;
        animationController.SetBool("isThrowing", false);
        animationController.SetBool("isCrouching", false);

    }




}
