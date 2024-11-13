using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DataMgr : MonoBehaviour
{
    public enum Character
    {
        Knight, Archer, //Magician
    }
    public static DataMgr instance;
    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) return;
        DontDestroyOnLoad(gameObject);
    }
    public Character selectedCharacter;
}
