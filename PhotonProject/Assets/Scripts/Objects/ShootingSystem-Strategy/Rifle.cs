using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : BaseWepon
{
    public Rifle(int d, float sS, Transform sp)
    {
        dmg = d;
        shootSpeed = sS * 0.5f;
        spawnPoint = sp;
    }

    public override bool CanShoot(float time)
    {
        if (time > shootSpeed) return true;
        else return false;
    }

    public override void Shoot()
    {
        RBullet thisBullet = BulletFactory.Instance.pool.GetT();
        thisBullet.transform.position = spawnPoint.position;
        thisBullet.transform.rotation = spawnPoint.rotation;
        thisBullet.SetDmg(dmg);
    }
}
