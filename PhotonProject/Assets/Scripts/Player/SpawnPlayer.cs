using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject _player;

    void Start()
    {
        //PhotonNetwork.Instantiate(_player.name, transform.position, Quaternion.identity);
    }
}
