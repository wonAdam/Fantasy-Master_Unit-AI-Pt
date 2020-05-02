using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton
{
    private static Singleton _instance;
    public static Singleton singleton
    {
        get{ 
            if(_instance == null)
                _instance = new Singleton();
            
            return _instance;  
        }
    }


    public LayerMask FloorMask = 1 << 10;


}
