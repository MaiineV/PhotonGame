using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public float speed;
    float _currentDistance;
    public float _maxDistance;

    void Update()
    {
        var distanceToTravel = speed * Time.deltaTime;

        transform.position += transform.forward * distanceToTravel;
        _currentDistance += distanceToTravel;

        if (_currentDistance > _maxDistance)
        {
            BossFactory.Instance.ReturnBullet(this);
        }
    }

    private void Reset()
    {
        _currentDistance = 0;
    }

    public static void TurnOn(BossBullet b)
    {
        b.Reset();
        b.gameObject.SetActive(true);
    }

    public static void TurnOff(BossBullet b)
    {
        b.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        IPlayerDmg thisInterface = other.GetComponent<IPlayerDmg>();
        if(thisInterface != null)
        {
            thisInterface.TakeDMG();
            BossFactory.Instance.ReturnBullet(this);
        }
    }
}
