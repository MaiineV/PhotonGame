using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class LoseWin : MonoBehaviourPun
{
    public List<bool> isDead;

    public GameObject LoseScreen;
    public GameObject WinScreen;
    public PhotonView pv;

    private void Start()
    {
        EventManager.Subscribe("SetDead", SetDead);
        EventManager.Subscribe("BossDead", BossDead);
        EventManager.Subscribe("AddList", AddList);
    }

    public void AddList(params object[] parameters)
    {
        isDead.Add(false);
    }

    public void SetDead(params object[] parameters)
    {
        if (!pv.IsMine) return;
        Debug.Log((int)parameters[0]);
        Debug.Log(isDead[(int)parameters[0]]);
        isDead[(int)parameters[0]] = true;

        if (Lose())
        {
            pv.RPC("RPC_Lose", RpcTarget.All);
        }
    }

    public void BossDead(params object[] parameters)
    {
        if (!pv.IsMine) return;

        pv.RPC("RPC_Win", RpcTarget.All);
    }

    [PunRPC]
    public void RPC_Win()
    {
        WinScreen.SetActive(true);
    }

    [PunRPC]
    public void RPC_Lose()
    {
        LoseScreen.SetActive(true);
    }

    bool Lose()
    {
        foreach (bool item in isDead)
        {
            if (!item)
                return false;
        }
        return true;
    }

}
