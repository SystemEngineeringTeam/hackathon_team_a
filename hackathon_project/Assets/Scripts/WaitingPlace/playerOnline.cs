using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;
using Photon.Realtime;

public class playerOnline : MonoBehaviourPunCallbacks
{
        public void Awake()
    {
        PhotonView mypv = GetComponent<PhotonView>();
        transform.GetChild(0).GetComponent<TextMesh>().text=mypv.Owner.NickName;
    }
}
