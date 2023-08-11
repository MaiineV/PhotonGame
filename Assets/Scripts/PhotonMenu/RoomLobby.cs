using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class RoomLobby : MonoBehaviourPunCallbacks
{
    #region vars
    public PhotonView pv;
    public List<bool> playerIsReady;
    public List<bool> playerIDWasTook;
    public List<Text> names;
    #endregion

    #region OnAction
    public override void OnJoinedRoom()
    {
        StartCoroutine(WaitBuffered());
    }

    public override void OnLeftRoom()
    {
        pv.RPC("ChangeListOff", RpcTarget.All, VarDontDestroy.instance.id);
    }
    #endregion

    #region Buttons
    public void BTN_Ready()
    {
        pv.RPC("SetReady", RpcTarget.AllBuffered, VarDontDestroy.instance.id);
    }

    public void BTN_Start()
    {
        if (Check())
            pv.RPC("LoadScene", RpcTarget.All);
    }
    #endregion

    #region Check
    bool Check()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            for (int i = 0; i < playerIDWasTook.Count; i++)
            {
                if (playerIDWasTook[i] != playerIsReady[i])
                {
                    return false;
                }
            }
            return true;
        }
        return false;
    }
    #endregion

    #region RPC
    [PunRPC]
    void LoadScene()
    {
        PhotonNetwork.LoadLevel("GameScene");
    }

    [PunRPC]
    void SetReady(int myID)
    {
        if (playerIsReady[myID])
        {
            playerIsReady[myID] = false;
            names[myID].color = Color.red;
        }
        else
        {
            playerIsReady[myID] = true;
            names[myID].color = Color.green;
        }
    }

    [PunRPC]
    void ChangeListOn(string nick ,int myID)
    {
        names[myID].gameObject.SetActive(true);
        if (nick != "")
            names[myID].text = nick;
        else
            names[myID].text = "Player" + myID;
        playerIDWasTook[myID] = true;
    }

    [PunRPC]
    void ChangeListOff(int myID)
    {
        names[myID].gameObject.SetActive(false);
        playerIDWasTook[myID] = false;
    }
    #endregion

    #region Corrutina
    IEnumerator WaitBuffered()
    {
        yield return new WaitForSeconds(1f);

        int countID = 0;
        foreach (var item in playerIDWasTook)
        {
            if (!item)
            {
                VarDontDestroy.instance.id = countID;
                break;
            }
            countID++;
        }
        pv.RPC("ChangeListOn", RpcTarget.AllBuffered, VarDontDestroy.instance.nickName, VarDontDestroy.instance.id);
    }
    #endregion
}