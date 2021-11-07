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
    private PickingUpObjectsHandler PickingUpObjectsHandler;

    public static GameManagement instance;

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
        PickingUpObjectsHandler = FindObjectOfType<PickingUpObjectsHandler>();
    }

    public void HandleShowingPickableObjectMarker(Collider other)
    {
        if (PickingUpObjectsHandler.objectToPickup == null && other.attachedRigidbody != null && other.gameObject.CompareTag("pickable"))
        {
            PickingUpObjectsHandler.objectToPickup = other.gameObject;
            objectsMarker.SetActive(true);
            Vector3 positionForMarker = other.transform.position;
            positionForMarker.y += other.bounds.size.y / 2 + objectsMarker.GetComponentInChildren<MeshRenderer>().bounds.size.y / 2;
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
        daleHealth.Health = daleHealth.Health - HP_DECREASE_VALUE;
        daleHPSlider.value = daleHealth.Health;
        yield return new WaitForSeconds(SECONDS_BETWEEN_DRAINING_HP);
        timeOffsetPassedBetweenDrainingHP = true;


    }





}
