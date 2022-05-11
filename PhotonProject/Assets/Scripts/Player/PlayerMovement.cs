using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMovement : MonoBehaviourPun
{
    [SerializeField] private PhotonView _pv;
    [SerializeField] private GameObject _target;

    [SerializeField] private float _speed;

    [SerializeField] private LayerMask _rayMask;

    [SerializeField] private float playerHeight;

    void Start()
    {
        if (_pv.IsMine)
        {
            _target.SetActive(true);
            VarDontDestroy.instance.myPlayer = this.gameObject;
        }
    }

    void Update()
    {
        if (!_pv.IsMine) return;

        transform.position += new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * Time.deltaTime * _speed;
        Rotation();
    }

    void Rotation()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 pointHit = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10));

        Vector3 VectorRaycast = pointHit - Camera.main.transform.position;

        RaycastHit hit;
        Physics.Raycast(Camera.main.transform.position, VectorRaycast, out hit, Mathf.Infinity);
        Debug.DrawLine(Camera.main.transform.position, VectorRaycast, Color.red);

        transform.LookAt(new Vector3(hit.point.x, playerHeight, hit.point.z));
    }
}
