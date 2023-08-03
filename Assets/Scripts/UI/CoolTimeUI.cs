using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolTimeUI : MonoBehaviour
{
    [SerializeField] private Image coolTimeImg;

    public void SetCoolTime(float time)
    {
        StopAllCoroutines();
        StartCoroutine(CoolTime(time));
    }

    IEnumerator CoolTime(float time)
    {
        float reversalTime = 1/time;
        
        while (time >= 0)
        {
            time -= Time.deltaTime;
            coolTimeImg.fillAmount = time * reversalTime;
            yield return null;
        }

        coolTimeImg.fillAmount = 1f;
    }
}
