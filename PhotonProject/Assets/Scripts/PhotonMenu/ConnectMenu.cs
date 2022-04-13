using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ConnectMenu : MonoBehaviourPunCallbacks
{
    [SerializeField] GameObject _firstMenu;
    [SerializeField] GameObject _roomMenu;

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Succesfully Connect");
        _firstMenu.gameObject.SetActive(true);
    }

    public void JoinOrCreateRoom()
    {
        PhotonNetwork.JoinRandomOrCreateRoom();
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("Created Room");
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("You cant creat a room");
    }

    public override void OnJoinedRoom()
    {
        _firstMenu.gameObject.SetActive(false);
        _roomMenu.gameObject.SetActive(true);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log("You cant join a room");
    }
}
