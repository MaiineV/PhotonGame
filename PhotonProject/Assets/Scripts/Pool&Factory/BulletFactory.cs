using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFactory : MonoBehaviour
{
    public static BulletFactory Instance;

    public RBullet prefab;
    public int initialStock;

    public ObjectPool<RBullet> pool;

    private void Start()
    {
        Instance = this;
        pool = new ObjectPool<RBullet>(CreatorMethod, initialStock, true, RBullet.TurnOn, RBullet.TurnOff);
    }

    public RBullet CreatorMethod()
    {
        return Instantiate(prefab);
    }

    public void ReturnBullet(RBullet b)
    {
        pool.ReturnObject(b);
    }
}
