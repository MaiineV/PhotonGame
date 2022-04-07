using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class RoomLobby : MonoBehaviourPunCallbacks
{
    public PhotonView pv;
    public List<bool> playerIsReady;
    public int id;
    public List<Text> names;

    public void BTN_Ready()
    {
        if (playerIsReady[id])
        {
            playerIsReady[id] = false;
            names[id].color = Color.red;
        }
        else
        {
            playerIsReady[id] = true;
            names[id].color = Color.green;
        }
    }

    public override void OnJoinedRoom()
    {
        id = PhotonNetwork.CurrentRoom.PlayerCount - 1;
        pv.RPC("ChangeList", RpcTarget.All);
    }

    [PunRPC]
    void ChangeList()
    {
        names[id].gameObject.SetActive(true);
        playerIsReady.Capacity = PhotonNetwork.CurrentRoom.PlayerCount;
    }

}
