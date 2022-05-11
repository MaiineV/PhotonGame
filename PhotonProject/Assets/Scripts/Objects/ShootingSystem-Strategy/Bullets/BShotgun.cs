using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BShotgun : MonoBehaviour, ISetDmg
{
    private float _actualDmg;

    private void OnEnable()
    {
        StartCoroutine(WaitToTurnOff());
    }

    public void SetDmg(int dmg)
    {
        _actualDmg = dmg;
    }

    private void OnTriggerEnter(Collider other)
    {
        ITakeDamage thisEnemy = other.GetComponent<ITakeDamage>();
        if (thisEnemy != null)
        {
            thisEnemy.TakeDmg(_actualDmg);
        }
    }

    IEnumerator WaitToTurnOff()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
    }
}
