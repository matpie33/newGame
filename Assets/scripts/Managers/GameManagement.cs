using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using UnityEngine.UI;
using UnityEngine.Animations.Rigging;
public class GameManagement : MonoBehaviour
{
    public const int force = 3000;
    private DaleState daleState;
    public Slider daleHPSlider;
    public GameObject objectsMarker;
    private PickingUpObjectsController pickingUpObjectsHandler;
    public static GameManagement instance;
    private GameObject dale;

    private DaleMovementController daleMovementController;
    private BossHpController bossHpController;
    private DaleHpController playerHpController;

    void Awake()
    {
        instance = this;

    }

    void Start()
    {
        playerHpController = FindObjectOfType<DaleHpController>();
        daleState = GetPlayer.instance.player.GetComponent<DaleState>();
        pickingUpObjectsHandler = FindObjectOfType<PickingUpObjectsController>();
        dale = GameObject.FindGameObjectWithTag(TagsManager.PLAYER);
        daleMovementController = FindObjectOfType<DaleMovementController>();
        bossHpController = FindObjectOfType<BossHpController>();
        SavingAndLoadingController.Save(dale);
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



    public void ResetDaleToLastCheckpoint()
    {
        PlayerData playerData = SavingAndLoadingController.LoadPlayer();
        dale.transform.position = playerData.GetPosition();
        bossHpController.ResetHp();
        daleMovementController.enabled = true;
        playerHpController.SetDaleHpToMaxValue();
        daleState.IsDead = false;
    }








}
