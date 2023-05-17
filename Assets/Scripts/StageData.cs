using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum StageEventType
{
    SpawnObject,
    WinStage
}

[Serializable]

public class StageEvent
{
    public StageEventType stageEventType;
    public GameObject objectToSpawn; 
    public float time;
    public int lvl;
}

[CreateAssetMenu]
public class StageData : ScriptableObject
{
    public List<StageEvent> stageEvent;
}
