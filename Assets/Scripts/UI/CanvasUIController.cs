using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasUIController : MonoBehaviour
{
    public Image bossLife;
    [SerializeField] private GameObject[] _posibleWeapons;

    void Start()
    {
        bossLife.fillAmount = 1;
        EventManager.Subscribe("UpdateBossLife", UpdateBossLife);
        EventManager.Subscribe("ChangeWeapon", ChangeWeapon);
    }

    public void UpdateBossLife(params object[] parameter)
    {
        Debug.Log("estoy modificando ui " + bossLife.fillAmount + " " + (float)parameter[0]);
        bossLife.fillAmount = (float)parameter[0];
    }

    private void ChangeWeapon(params object[] parameter)
    {
        foreach (var uiWeapon in _posibleWeapons)
        {
            uiWeapon.SetActive(false);
        }
        
        _posibleWeapons[(int)parameter[0]].SetActive(true);
    }
}
