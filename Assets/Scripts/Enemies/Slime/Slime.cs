using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Slime : MonsterTemplate
{
    // Start is called before the first frame update
    void Start()
    {
        StartUp();
    }

    // Update is called once per frame
    void Update()
    {
        Patrol();
        
    }
    
    
}
