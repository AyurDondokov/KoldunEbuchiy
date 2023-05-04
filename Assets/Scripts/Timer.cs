using UnityEngine;
using TMPro;


public class Timer : MonoBehaviour
{
    public float time = 0;
    public TextMeshProUGUI value;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        int minutes = (int)(time/60);
        int seconds = (int)(time%60);
            value.text = minutes.ToString() + ":" + seconds.ToString("00");
    }
}
