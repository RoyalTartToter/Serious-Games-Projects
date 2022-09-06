using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSkybox : MonoBehaviour
{
    public Material Skybox;
    // Start is called before the first frame update
    void Start()
    {
        RenderSettings.skybox = Skybox;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
