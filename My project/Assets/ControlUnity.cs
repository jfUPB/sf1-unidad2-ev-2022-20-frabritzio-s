using System;
using UnityEngine;
using System.IO.Ports;
using TMPro;

public class ControlUnity : MonoBehaviour
{
    StringComparer stringComparer = StringComparer.OrdinalIgnoreCase;
    private SerialPort _serialPort;
    public TextMeshProUGUI button1;
    public TextMeshProUGUI button2;
    public TextMeshProUGUI button3;
   
    private string _index, _ledState;
    
    public GameObject InputLed;
    public GameObject InputOnOff;
    void Start()
    {
        _serialPort = new SerialPort();
        _serialPort.PortName = "/dev/ttyUSB0";
        _serialPort.BaudRate = 115200;
        _serialPort.DtrEnable = true;
        _serialPort.NewLine = "\n";
        _serialPort.Open();
        Debug.Log("Open Serial Port");
    }

    void Update()
    {
        if (_serialPort.BytesToRead > 0)
        { 
            string check = _serialPort.ReadLine();
            Debug.Log(check);
            
            if (stringComparer.Equals("button1: OFF", check)){
                button1.text = "RELEASED";
            }
            if (stringComparer.Equals("button1: ON", check)){
                button1.text = "PUSHED";
            }
            if (stringComparer.Equals("button2: OFF", check)){
                button2.text = "RELEASED";
            }
            if (stringComparer.Equals("button2: ON", check)){
                button2.text = "PUSHED";
            }
            if (stringComparer.Equals("button3: OFF", check)){
                button3.text = "RELEASED";
            }
            if (stringComparer.Equals("button3: ON", check)){
                button3.text = "PUSHED";
            }
        }
    }
    
    public void ReadButtons()
    {
        _serialPort.Write("Case1\n");
        _serialPort.Write("Case2\n");
        _serialPort.Write("Case3\n");
        Debug.Log("Send CMS");
    }
    
    public void LedControl()
    {
        _index = InputLed.GetComponent<TMP_InputField>().text;
        Debug.Log(_index);
        _ledState = InputOnOff.GetComponent<TMP_InputField>().text;
        Debug.Log(_ledState);
        
        switch (_index)
        {
            case "1":
                if (_ledState == "ON"){
                    _serialPort.Write("led_1ON");
                }
                else if (_ledState == "OFF"){
                    _serialPort.Write("led_1OFF");
                }
                break;
            case "2":
                if (_ledState == "ON"){
                    _serialPort.Write("led_2ON");
                }
                else if (_ledState == "OFF"){
                    _serialPort.Write("led_2OFF");
                }
                break;
            case "3":
                if (_ledState == "ON"){
                    _serialPort.Write("led_3ON");
                }
                else if (_ledState == "OFF"){
                    _serialPort.Write("led_3OFF");
                }
                break;
            
            default:
                Debug.Log("Try with 1, 2 or 3.");
                break;
        }
    }
}