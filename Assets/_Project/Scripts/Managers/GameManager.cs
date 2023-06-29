using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static event Action OnGameStart;
    
    private void Start()
    {
        OnGameStart?.Invoke();    
    }
}
