using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageEventManager : MonoBehaviour
{
    [SerializeField] StageData stageData;
    
    int eventIndexer;
    Timer stageTime;
    [SerializeField] RandomSpawner spawn;
    
    public void Awake(){
        stageTime = GetComponent<Timer>();
    }
    private void Update()
    {
        if (eventIndexer >= stageData.stageEvent.Count){return;}
        if (stageTime.time > stageData.stageEvent[eventIndexer].time)
        {
            switch(stageData.stageEvent[eventIndexer].stageEventType)
            {
                case StageEventType.SpawnObject:
                    break;
                case StageEventType.WinStage:
                    break;
            }
            spawn.diflvl = stageData.stageEvent[eventIndexer].lvl;
            eventIndexer += 1;
        }

        
    }
}
