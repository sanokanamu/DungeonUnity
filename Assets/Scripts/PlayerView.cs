using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    private enum PlaterMode
    {
        Idle = 0,
        RightWalk = 1,
        Walk = 2,
        LeftWalk = 3,
        BackWalk = 4,

    }

    private PlaterMode _playerMode = PlaterMode.Idle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
