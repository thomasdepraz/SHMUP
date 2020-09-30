using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{

    public PlayerMovement playerMovement;
    public PlayerShoot playerShoot;
    private void Awake()
    {
        MakeSingleton(false);//Make the player a singleton
    }
}
