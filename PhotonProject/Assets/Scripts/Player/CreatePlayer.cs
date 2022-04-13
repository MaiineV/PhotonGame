using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CreatePlayer : MonoBehaviour
{
    public GameObject _player;
    public List<Transform> _instancePoint;

    void Start()
    {
        PhotonNetwork.Instantiate(_player.name, _instancePoint[VarDontDestroy.instance.id].position, Quaternion.identity);
    }
}
