using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class WaveManager : MonoBehaviour
{
    public static WaveManager instance;

    public float length = 2f;
    public float amplitude = 1f;
    public float speed = 1f;
    public float offset = 0f;


    private void Awake()
    { //singleton to allow us to access a specific instance of this class anywhere in the project,
      //while also making sure there is only ever one in the existence 
        if (instance == null)
        {
            instance = this;
        }
        else if(instance!=this)
        {
            Debug.Log("Instance already exists, destroying object");
            Destroy(this);
        }
    }

    private void Update()
    {
        offset += Time.deltaTime * speed;
    }

    public float GetWaveHeight(float _x)
    {

        return amplitude * Mathf.Sin(_x / length + offset);
    }
}
