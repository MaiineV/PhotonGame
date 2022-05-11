using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : BaseWepon
{
    BShotgun myBullet;
    public Shotgun(int damage, float _shootSpeed, Transform _spawnPoint, BShotgun shotgunBullet)
    {
        dmg = damage * 3;
        shootSpeed = _shootSpeed * 1.5f;
        spawnPoint = _spawnPoint;
        myBullet = shotgunBullet;
        myBullet.SetDmg(dmg);
    }

    public override bool CanShoot(float time)
    {
        if (time > shootSpeed) return true;
        else return false;
    }

    public override void Shoot()
    {
        myBullet.gameObject.SetActive(true);
    }
}
