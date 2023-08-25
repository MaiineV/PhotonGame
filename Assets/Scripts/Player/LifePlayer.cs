using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class LifePlayer : MonoBehaviourPun, IPlayerDmg
{
    
    public PhotonView pv;
    public UIController ui;
    public float maxLife;
    public float dmgTaken;
    float _life;
    bool added = false;

    void Start()
    {
        _life = maxLife;
    }

    private void Update()
    {
        if (!pv.IsMine) return;

        if (added == false)
        {
            pv.RPC("AddBool", RpcTarget.All);
            added = true;
        }
    }

    [PunRPC]
    void AddBool()
    {
        EventManager.Trigger("AddList");
    }

    public void TakeDMG()
    {
        if (!pv.IsMine) return;

        _life -= dmgTaken;
        float porcent = _life / maxLife;
        pv.RPC("UpdateUI", RpcTarget.All, porcent);

        if (_life <= 0)
            pv.RPC("Death", RpcTarget.All, VarDontDestroy.instance.id);
    }

    [PunRPC]
    public void UpdateUI(float porcent)
    {
        ui.UpdateLifeBar(porcent);
    }

    [PunRPC]
    void Death(int id)
    {
        EventManager.Trigger("SetDead", id);
        gameObject.SetActive(false);
    }
}
