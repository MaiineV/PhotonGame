using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CreatePlayer : MonoBehaviour
{
    public GameObject _player;
    public PhotonView pv;

    public void Create()
    {
        PhotonNetwork.Instantiate(_player.name, Vector3.zero, Quaternion.identity);
        //PhotonNetwork.IsMasterClient();
        Debug.Log(PhotonNetwork.PlayerList[0].UserId);
    }
}
