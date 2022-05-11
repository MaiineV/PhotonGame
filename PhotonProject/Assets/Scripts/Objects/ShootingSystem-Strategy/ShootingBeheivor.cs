using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ShootingBeheivor : MonoBehaviour
{
    [SerializeField] private PhotonView _pv;
    [SerializeField] private Transform _spawnPoint;

    private BaseWepon _actualWeapon;

    private List<BaseWepon> allWeapons = new List<BaseWepon>();

    public BShotgun shotgunBullet;

    public int dmg;
    public float shootSpeed;

    public float timer;

    private void Start()
    {
        allWeapons.Add(new Shotgun(dmg, shootSpeed, _spawnPoint, shotgunBullet));
        allWeapons.Add(new Rifle(dmg, shootSpeed, _spawnPoint));
        _actualWeapon = allWeapons[0];
    }


    void Update()
    {
        if (!_pv.IsMine)
            return;
        
        if (Input.GetMouseButtonDown(0) && _actualWeapon.CanShoot(timer))
        {
            _pv.RPC("RPCShot", RpcTarget.All);
        }

        Inputs();

        timer += Time.deltaTime;
    }

    public void Inputs()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _pv.RPC("ChangeWepon", RpcTarget.All, 0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _pv.RPC("ChangeWepon", RpcTarget.All, 1);
        }
    }


    [PunRPC]
    public void RPCShot()
    {
        _actualWeapon.Shoot();
    }

    [PunRPC]
    public void ChangeWepon(int newWepon)
    {
        _actualWeapon = allWeapons[newWepon];
    }
}