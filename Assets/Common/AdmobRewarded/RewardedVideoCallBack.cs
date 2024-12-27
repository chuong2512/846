
using UnityEngine;

public class RewardedVideoCallBack : MonoBehaviour {

    private void Start()
    {
        Timer.Schedule(this, 0.5f, AddEvents);
    }

    private void AddEvents()
    {
    }
    

    
    
    private void OnDestroy()
    {
    }
}
