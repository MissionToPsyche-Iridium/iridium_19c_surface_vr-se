using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRScreenOption : MonoBehaviour
{
    public bool isVROn;
    
    // Start is called before the first frame update
    void Start()
    {
        if (isVROn)
        {
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isVROn)
        {
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }
}
