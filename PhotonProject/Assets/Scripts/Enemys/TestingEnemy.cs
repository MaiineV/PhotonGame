using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingEnemy : Entity, ITakeDamage
{
    public Renderer render;
    public Material dmgMat;
    public Material baseMat;

    void Start()
    {
        render = GetComponent<Renderer>();
    }

    public void TakeDmg(float dmg)
    {
        StartCoroutine(RenderDMG());
        life -= dmg;
    }

    IEnumerator RenderDMG()
    {
        render.material = dmgMat;
        yield return new WaitForSeconds(0.2f);
        render.material = baseMat;
    }
}
