using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ShootingBeheivor : MonoBehaviour
{
    [SerializeField] private PhotonView _pv;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _spawnPoint;

    void Update()
    {
        if (!_pv.IsMine)
            return;
        
        if (Input.GetMouseButtonDown(0))
        {
            _pv.RPC("InstanciateBullet", RpcTarget.All);
        }
    }

    [PunRPC]
    public void InstanciateBullet()
    {
        GameObject bullet = Instantiate(_bullet, _spawnPoint.position, transform.rotation);
        Destroy(bullet, 2f);
    }
}