using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ConnectMenu : MonoBehaviourPunCallbacks
{
    [SerializeField] GameObject _mainMenu;
    [SerializeField] GameObject _firstMenu;

    public void ConnectServer()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Succesfully Connect");
        _mainMenu.gameObject.SetActive(false);
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
        SceneManager.LoadScene(1);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log("You cant join a room");
    }
}
