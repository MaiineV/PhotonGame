using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject _player;
    void Update()
    {
        if (_player == null)
            _player = VarDontDestroy.instance.myPlayer;

        transform.position = _player.transform.position;
    }
}