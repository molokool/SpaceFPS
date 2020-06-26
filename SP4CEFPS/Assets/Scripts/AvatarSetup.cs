using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarSetup : MonoBehaviour
{
    private PhotonView PV;

    public int playerHealth;
    public int playerDamage;

    public Camera myCamera;
    public AudioListener myAL;

    void Start()
    {
        PV = GetComponent<PhotonView>();

        if (PV.IsMine)
        {

        }
        else
        {
            Destroy(myCamera);
            Destroy(myAL);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
