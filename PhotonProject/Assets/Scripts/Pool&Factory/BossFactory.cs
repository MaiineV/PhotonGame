using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFactory : MonoBehaviour
{
    public static BossFactory Instance;

    public BossBullet prefab;
    public int initialStock;

    public ObjectPool<BossBullet> pool;

    private void Start()
    {
        Instance = this;
        pool = new ObjectPool<BossBullet>(CreatorMethod, initialStock, true, BossBullet.TurnOn, BossBullet.TurnOff);
    }

    public BossBullet CreatorMethod()
    {
        return Instantiate(prefab);
    }

    public void ReturnBullet(BossBullet b)
    {
        pool.ReturnObject(b);
    }
}
