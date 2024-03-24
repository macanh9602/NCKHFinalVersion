using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class WaveManager : MonoBehaviour
{
    //wave manager
    public static WaveManager instance;
    public List<Wave> waves;
    public int currentWaveIndex = 0;
    public State state;
    public enum State
    {
        WaitForNextWave,
        SpawnEnemy
    }

}

