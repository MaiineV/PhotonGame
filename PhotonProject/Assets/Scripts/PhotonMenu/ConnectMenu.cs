using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class ConnectMenu : MonoBehaviourPunCallbacks
{
    [SerializeField] GameObject _firstMenu;
    [SerializeField] GameObject _roomMenu;
    [SerializeField] InputField _nick;
    [SerializeField] private Text _warningText;
    [SerializeField] int maxCaracters = 10;
    [SerializeField] int minCaracters = 3;


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
        int ammountOfLetters = 0;
        int amountOfCaracters = 0;

        foreach (var item in _nick.text)
        {
            Debug.Log(item.ToString());
            amountOfCaracters++;
            if (item.ToString() != " ")
            {
                ammountOfLetters++;
                Debug.Log("sume");
            }
            else
            {
                Debug.Log("no sume");
                continue;
            }
        }

        Debug.Log(amountOfCaracters);

        if(ammountOfLetters >= minCaracters && amountOfCaracters <= maxCaracters)
        {
            VarDontDestroy.instance.nickName = _nick.text;
            PhotonNetwork.JoinRandomOrCreateRoom();
        }
        else if(ammountOfLetters < minCaracters)
        {
            _warningText.gameObject.SetActive(true);
            _warningText.text = "Nombre muy corto! Minimo de caracteres: " + minCaracters;
        }
        else if(amountOfCaracters > maxCaracters)
        {
            _warningText.gameObject.SetActive(true);
            _warningText.text = "Nombre muy largo! Maximo de caracteres: " + maxCaracters;
        }
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
