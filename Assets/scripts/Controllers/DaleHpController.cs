using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DaleHpController : MonoBehaviour
{

    private const int HP_DECREASE_VALUE = 20;
    private bool timeOffsetPassedBetweenDrainingHP = true;
    private const int SECONDS_BETWEEN_DRAINING_HP = 2;
    private Animator daleAnimator;
    private DaleState daleState;
    private DaleMovementController daleMovementController;
    private GameObject dale;

    [SerializeField]
    private Slider daleHPSlider;

    [SerializeField]
    private int hpMaxValue = 100;


    public void Start()
    {
        daleMovementController = FindObjectOfType<DaleMovementController>();
        dale = GameObject.FindGameObjectWithTag(TagsManager.PLAYER);
        daleAnimator = dale.GetComponentInChildren<Animator>();
        daleState = FindObjectOfType<DaleState>();
        daleHPSlider.maxValue = hpMaxValue;
        SetDaleHpToMaxValue();
    }

    public void DecreasePlayerHP()
    {
        if (timeOffsetPassedBetweenDrainingHP)
        {
            StartCoroutine(DrainHpFromPlayer());
        }
        if (!daleState.IsDead && daleState.Health <= 0)
        {
            daleAnimator.SetTrigger("isDead");
            daleState.IsDead = true;
            daleMovementController.enabled = false;
            return;
        }
    }

    IEnumerator DrainHpFromPlayer()
    {
        timeOffsetPassedBetweenDrainingHP = false;
        daleState.Health = daleState.Health - HP_DECREASE_VALUE;
        daleHPSlider.value = daleState.Health;
        yield return new WaitForSeconds(SECONDS_BETWEEN_DRAINING_HP);
        timeOffsetPassedBetweenDrainingHP = true;

    }

    public void SetDaleHpToMaxValue()
    {
        daleState.Health = hpMaxValue;
        daleHPSlider.value = hpMaxValue;
    }

}
