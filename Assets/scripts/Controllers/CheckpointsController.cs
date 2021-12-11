using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class CheckpointsController : MonoBehaviour
{
    private DaleState daleState;
    private PickingUpObjectsController pickingUpObjectsHandler;
    private DaleMovementController daleMovementController;
    private BossHpController bossHpController;
    private DaleHpController playerHpController;
    private GameObject dale;

    void Start()
    {
        playerHpController = FindObjectOfType<DaleHpController>();
        daleState = FindObjectOfType<DaleState>();
        pickingUpObjectsHandler = FindObjectOfType<PickingUpObjectsController>();
        dale = GameObject.FindGameObjectWithTag(TagsManager.PLAYER);
        daleMovementController = FindObjectOfType<DaleMovementController>();
        bossHpController = FindObjectOfType<BossHpController>();
        SavingAndLoadingController.Save(dale);
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
