using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RBullet : MonoBehaviour, ISetDmg
{
    float _actualDmg;
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
            BulletFactory.Instance.ReturnBullet(this);
        }
    }

    private void Reset()
    {
        _currentDistance = 0;
    }


    public static void TurnOn(RBullet b)
    {
        b.Reset();
        b.gameObject.SetActive(true);
    }

    public static void TurnOff(RBullet b)
    {
        b.gameObject.SetActive(false);
    }

    public void SetDmg(int dmg)
    {
        _actualDmg = dmg;
    }

    private void OnTriggerEnter(Collider other)
    {
        ITakeDamage thisInterface = other.gameObject.GetComponent<ITakeDamage>();
        if(thisInterface != null)
        {
            Debug.Log("collisione?");
            thisInterface.TakeDmg(_actualDmg);
            BulletFactory.Instance.ReturnBullet(this);
        }
    }
}
