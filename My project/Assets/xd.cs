using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using TMPro;


enum TaskState
{
    INIT,
    WAIT_START,
    WAIT_EVENTS
}
public class xd : MonoBehaviour
{
    constexpr uint8_t led = 25;
    constexpr uint8_t button1Pin = 12;
    constexpr uint8_t button2Pin = 13;
    constexpr uint8_t button3Pin = 32;
    constexpr uint8_t button4Pin = 33;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
