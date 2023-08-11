using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class BossWeaponController : MonoBehaviourPun, IAttack
{
    public PhotonView pv;

    LookUpTable<int, int> _firstAttackAngle;
    LookUpTable<int, int> _secondAttackAngle;

    public delegate void ActualAction();
    ActualAction selectAttack;
    ActualAction actualAttack;

    int actualAngle = 0;
    float timer;
    public Transform spawnBossBullet;
    public Transform pivotSpawn;

    void Awake()
    {
        if (!pv.IsMine) return;

        _firstAttackAngle = new LookUpTable<int, int>(FirstAtackFM);
        _secondAttackAngle = new LookUpTable<int, int>(SecondAtackFM);
        selectAttack = SelectAtk;
    }

    void Update()
    {
        if (!pv.IsMine) return;

        selectAttack();
        Attack();
        timer += Time.deltaTime;
    }

    void SelectAtk()
    {
        int random = Random.Range(0, 2);

        if (random == 0)
            actualAttack = FirstAttack;
        else if (random == 1)
            actualAttack = SecondAttack;

        pv.RPC("RPC_SetAngle", RpcTarget.All, 0);
        selectAttack = delegate { };
    }

    public void Attack()
    {
        actualAttack();
    }

    public void FirstAttack()
    {
        if (actualAngle >= 360)
        {
            actualAngle = 0;
            actualAttack = delegate { };
            selectAttack = SelectAtk;
        }

        if (timer > 0.2f)
        {
            pv.RPC("RPC_SetAngle", RpcTarget.All, actualAngle);
            pv.RPC("RPC_CallBullet", RpcTarget.All);
            actualAngle = _firstAttackAngle.ReturnValue(actualAngle);
            timer = 0;
        }
    }

    public void SecondAttack()
    {
        if (actualAngle >= 360)
        {
            actualAngle = 0;
            actualAttack = delegate { };
            selectAttack = SelectAtk;
        }

        if (timer > 1)
        {
            for (int i = 0; i < 4; i++)
            {
                pv.RPC("RPC_SetAngle", RpcTarget.All, actualAngle);
                pv.RPC("RPC_CallMultyBullet", RpcTarget.All);
                actualAngle = _secondAttackAngle.ReturnValue(actualAngle);
            }
            timer = 0;
        }
    }

    [PunRPC]
    void RPC_SetAngle(int angle)
    {
        pivotSpawn.rotation = Quaternion.Euler(new Vector3(0, angle, 0));
    }

    [PunRPC]
    void RPC_CallBullet()
    {
        BossBullet thisBullet = BossFactory.Instance.pool.GetT();
        thisBullet.transform.position = spawnBossBullet.position;
        thisBullet.transform.rotation = spawnBossBullet.rotation;
    }

    [PunRPC]
    void RPC_CallMultyBullet()
    {
        for (int i = 0; i < 3; i++)
        {
            BossBullet thisBullet = BossFactory.Instance.pool.GetT();
            if (i == 0)
            {
                thisBullet.transform.position = spawnBossBullet.position;
                thisBullet.transform.rotation = spawnBossBullet.rotation;
            }
            else if (i == 1)
            {
                thisBullet.transform.position = spawnBossBullet.position + spawnBossBullet.right * 2;
                thisBullet.transform.rotation = spawnBossBullet.rotation;
            }
            else if (i == 2)
            {
                thisBullet.transform.position = spawnBossBullet.position + spawnBossBullet.right * -2;
                thisBullet.transform.rotation = spawnBossBullet.rotation;
            }
        }
    }


    public int FirstAtackFM(int previousAngle)
    {
        return (previousAngle + 15);
    }

    public int SecondAtackFM(int previousAngle)
    {
        return (previousAngle + 45);
    }
}
