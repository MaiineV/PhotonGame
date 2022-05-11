using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Create : MonoBehaviour
{
    public List<GameObject> _player;
    public List<Transform> _instancePoint;
    public GameObject boss;

    public PhotonView pv;


    void Start()
    {
        Debug.Log(VarDontDestroy.instance.skinSelected);
        PhotonNetwork.Instantiate(_player[VarDontDestroy.instance.skinSelected].name, _instancePoint[VarDontDestroy.instance.id].position, Quaternion.identity);

        if (pv.IsMine)
            PhotonNetwork.Instantiate(boss.name, new Vector3(0, 0.5f, 0), Quaternion.identity);
    }
}
