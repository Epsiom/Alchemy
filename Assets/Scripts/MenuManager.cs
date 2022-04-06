using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

    //TODO:HANDLE (EVENTUAL) POP-UP MENUS (OR HUD UI?), SEE https://youtu.be/4I0vonyqMi8?t=379

    private void Awake()
    {
        GameManager.OnGameStateChanged += GameManagerOnOnGameStateChanged;
    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GameManagerOnOnGameStateChanged;
    }

    private void GameManagerOnOnGameStateChanged(GameState obj)
    {
        throw new System.NotImplementedException();
    }
}
