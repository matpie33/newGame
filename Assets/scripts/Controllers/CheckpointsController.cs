using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class CheckpointsController : MonoBehaviour
{
    private DaleState daleState;
    private DaleMovementController daleMovementController;
    private BossHpController bossHpController;
    private DaleHpController playerHpController;
    private GameObject dale;

    void Awake()
    {
        playerHpController = FindObjectOfType<DaleHpController>();
        daleState = FindObjectOfType<DaleState>();
        dale = GameObject.FindGameObjectWithTag(TagsManager.PLAYER);
        daleMovementController = FindObjectOfType<DaleMovementController>();
        BossHpController[] bossHpController = Resources.FindObjectsOfTypeAll<BossHpController>();
        if (bossHpController.Length > 0)
        {
            this.bossHpController = bossHpController[0];
        }
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
