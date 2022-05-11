using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public abstract class Entity : MonoBehaviourPun
{
    public float life;
    public float maxlife;
    protected int dmg;
    protected float shootSpeed;
    protected GameObject bulletPrefab;
}
