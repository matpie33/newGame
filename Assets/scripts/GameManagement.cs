﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using UnityEngine.UI;
using UnityEngine.Animations.Rigging;
public class GameManagement : MonoBehaviour
{
    public const int force = 3000;

    private const int HP_DECREASE_VALUE = 20;
    public int hpMaxValue = 100;
    private DaleHealth daleHealth;
    public Slider daleHPSlider;

    private bool timeOffsetPassedBetweenDrainingHP = true;
    private const int SECONDS_BETWEEN_DRAINING_HP = 2;
    public GameObject objectsMarker;
    private PickingUpObjectsController pickingUpObjectsHandler;

    public static GameManagement instance;
    private Animator daleAnimator;
    private GameObject dale;
    private bool isDaleDead;
    private DaleMovementController daleMovementController;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        daleHealth = GetPlayer.instance.player.GetComponent<DaleHealth>();
        daleHealth.Health = hpMaxValue;
        daleHPSlider.maxValue = hpMaxValue;
        daleHPSlider.value = hpMaxValue;
        pickingUpObjectsHandler = FindObjectOfType<PickingUpObjectsController>();
        dale = GameObject.FindGameObjectWithTag(TagsManager.PLAYER);
        daleAnimator = dale.GetComponentInChildren<Animator>();
        daleMovementController = FindObjectOfType<DaleMovementController>();
    }

    public bool HandleShowingPickableObjectMarker(Collider other)
    {
        if (other.attachedRigidbody != null && other.gameObject.CompareTag(TagsManager.PICKABLE))
        {
            objectsMarker.SetActive(true);
            Vector3 positionForMarker = other.transform.position;
            positionForMarker.y += other.bounds.size.y / 2 + objectsMarker.GetComponentInChildren<MeshRenderer>().bounds.size.y / 2;
            objectsMarker.transform.position = positionForMarker;
            return true;
        }
        return false;
    }

    public void SetObjectToPickup(GameObject objectToPickup)
    {
        pickingUpObjectsHandler.objectToPickup = objectToPickup;

    }

    public void HandleHidingPickableObjectMarker()
    {
        objectsMarker.SetActive(false);

    }

    public void DecreasePlayerHP()
    {
        if (!isDaleDead && daleHealth.Health <= 0)
        {
            daleAnimator.SetBool("isDead", true);
            isDaleDead = true;
            daleMovementController.enabled = false;
            return;
        }
        if (timeOffsetPassedBetweenDrainingHP)
        {
            StartCoroutine(DrainHpFromPlayer());
        }
    }

    IEnumerator DrainHpFromPlayer()
    {
        timeOffsetPassedBetweenDrainingHP = false;
        daleHealth.Health = daleHealth.Health - HP_DECREASE_VALUE;
        daleHPSlider.value = daleHealth.Health;
        yield return new WaitForSeconds(SECONDS_BETWEEN_DRAINING_HP);
        timeOffsetPassedBetweenDrainingHP = true;



    }





}
