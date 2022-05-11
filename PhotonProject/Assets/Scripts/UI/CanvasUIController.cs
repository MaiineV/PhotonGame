using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasUIController : MonoBehaviour
{
    public Image bossLife;

    void Start()
    {
        bossLife.fillAmount = 1;
        EventManager.Subscribe("UpdateBossLife", UpdateBossLife);
    }

    public void UpdateBossLife(params object[] parameter)
    {
        Debug.Log("estoy modificando ui " + bossLife.fillAmount + " " + (float)parameter[0]);
        bossLife.fillAmount = (float)parameter[0];
    }
}
