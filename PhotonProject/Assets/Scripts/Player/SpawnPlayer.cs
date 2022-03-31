using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayer : MonoBehaviourPun
{
    [SerializeField] private GameObject _player;
    [SerializeField] private PhotonView _pv;

    void Start()
    {
        _pv.RPC("InstantiateCharacter", RpcTarget.OthersBuffered);
    }

    [PunRPC]
    void InstantiateCharacter()
    {
        Instantiate(_player, Vector3.zero + Vector3.up, Quaternion.identity);
    }
}
