using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMovement : MonoBehaviourPun
{
    [SerializeField] private PhotonView _pv;
    [SerializeField] private Renderer _renderer;

    [SerializeField] private Material _playerMat;
    [SerializeField] private Material _allyMat;

    [SerializeField] private float _speed;

    void Start()
    {
        if (_pv.IsMine)
        {
            _renderer.material = _playerMat;
        }
        else
        {
            _renderer.material = _allyMat;
        }
    }

    void Update()
    {
        if (!_pv.IsMine) return;

        transform.position += new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * Time.deltaTime * _speed;
    }

}
