using UnityEngine;

public class CarLight : MonoBehaviour
{
    public Light[] rearLights;
    public Light[] frontLights;

    private void Awake()
    {
        TurnOffLights(rearLights);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TurnOffLights(Light[] lights)
    {
        foreach (var light in lights)
        {
            if (light.gameObject.activeSelf == false)
            {
                return;
            }
            light.gameObject.SetActive(false);
        }
        
    }

    public void TurnOnLights(Light[] lights)
    {
        foreach (var light in lights)
        {
            if (light.gameObject.activeSelf == true)
            {
                return;
            }
            light.gameObject.SetActive(true);
        }
       
    }
}
