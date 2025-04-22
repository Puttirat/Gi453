using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSky : MonoBehaviour
{
    public LayerMask skyboz;
    public SkyBox skybob;
    private bool day = true;

    // Start is called before the first frame update
    void Start()
    {
        skybob.AfternoonTime();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            day = !day;

            if (day)
            {
                skybob.AfternoonTime();
            }
            else
            {
                skybob.NightTime();
            }
        }
    }
}
