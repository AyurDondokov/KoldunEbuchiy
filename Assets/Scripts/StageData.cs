using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]

public class StageEvent
{
    public float time;
    public int lvl;
}

[CreateAssetMenu]
public class StageData : ScriptableObject
{
    public List<StageEvent> stageEvent;
}
