using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class BaseBoss : Entity, ITakeDamage, IDie
{
    public PhotonView pv;

    public void TakeDmg(float dmg)
    {
        life -= dmg;
        float porcent = life / maxlife;
        pv.RPC("UpdateBossUI", RpcTarget.All, porcent);

        if (life <= 0)
            Die();
    }

    public void Die()
    {
        pv.RPC("RPC_Death", RpcTarget.All);
    }

    [PunRPC]
    public void RPC_Death()
    {
        EventManager.Trigger("BossDead");
        gameObject.SetActive(false);
    }

    [PunRPC]
    public void UpdateBossUI(float porcent)
    {
        Debug.Log("tome dmg " + life + " " + porcent);
        EventManager.Trigger("UpdateBossLife", porcent);
    }

}
