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

    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _spawnBulletPoint;

    [SerializeField] private LayerMask _rayMask;

    [SerializeField] private float playerHeight;
    [SerializeField] private Transform cameraPivot;

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
        Rotation();
        cameraPivot.position = transform.position;

        if (Input.GetMouseButtonDown(0))
        {
            _pv.RPC("InstanciateBullet", RpcTarget.All);
        }
    }

    void Rotation()
    {
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //RaycastHit hit;

        //if(Physics.Raycast(ray, out hit, Mathf.Infinity, _rayMask))
        //{
        //    transform.LookAt(new Vector3(hit.transform.position.x, transform.position.y, hit.transform.position.z));
        //}

        Vector3 mousePos = Input.mousePosition;
        Vector3 pointHit = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10));

        Vector3 VectorRaycast = pointHit - Camera.main.transform.position;

        RaycastHit hit;
        Physics.Raycast(Camera.main.transform.position, VectorRaycast, out hit, Mathf.Infinity);
        Debug.DrawLine(Camera.main.transform.position, VectorRaycast, Color.red);

        transform.LookAt(new Vector3(hit.point.x, playerHeight, hit.point.z));

    }

    [PunRPC]
    public void InstanciateBullet()
    {
        GameObject Bullet = Instantiate(_bullet, _spawnBulletPoint.position, Quaternion.identity);
        Destroy(Bullet, 2f);
    }

}
