using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{


    //Singleton
    private static MusicManager instance = null;

    private void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(this);
        }
        DontDestroyOnLoad(this);
    }

    public static MusicManager Instance() {
        return instance;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

}
