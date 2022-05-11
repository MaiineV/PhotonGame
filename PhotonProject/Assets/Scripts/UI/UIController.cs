using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class UIController : MonoBehaviourPun
{
    public Renderer render;
    public PhotonView pv;

    public Material myLifeBar;
    public Material allyLifeBar;


    void Start()
    {
        if (pv.IsMine)
            render.material = myLifeBar;
        else
            render.material = allyLifeBar;
    }

    public void UpdateLifeBar(float porcent)
    {
        Debug.Log(porcent);
        transform.localScale = new Vector3(porcent, transform.localScale.y, transform.localScale.z);
    }
}
