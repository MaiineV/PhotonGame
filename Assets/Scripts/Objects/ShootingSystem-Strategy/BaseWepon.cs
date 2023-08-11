using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseWepon
{
    protected int dmg;
    protected float shootSpeed;
    protected Transform spawnPoint;

    public abstract void Shoot();
    public abstract bool CanShoot(float time);
}
