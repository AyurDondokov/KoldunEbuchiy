using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageEventManager : MonoBehaviour
{
    [SerializeField] StageData stageData;
    
    int eventIndexer;
    Timer stageTime;
    [SerializeField] RandomSpawner spawn;
    
    // Update is called once per frame
    private void Update()
    {
        stageTime = GetComponent<Timer>();
        if (eventIndexer >= stageData.stageEvent.Count){return;}
        if (stageTime.time > stageData.stageEvent[eventIndexer].time)
        {
            spawn.diflvl = stageData.stageEvent[eventIndexer].lvl;
            eventIndexer += 1;
        }

        
    }
}
