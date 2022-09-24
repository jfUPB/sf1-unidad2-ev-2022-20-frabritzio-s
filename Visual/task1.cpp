#include <Arduino.h>
#include "task1.h"

String btnState(uint8_t btnState)
{
  if(btnState == HIGH){
    return "OFF";
  }
  else return "ON";
}

void task1()
{

enum TaskStates
{
    INIT,
    COMPARE,
};

static TaskStates taskState = TaskStates::INIT;
constexpr uint8_t button1 = 12;
constexpr uint8_t button2 = 13;
constexpr uint8_t button3 = 33;
constexpr u_int8_t led_1 = 25;
constexpr u_int8_t led_2 = 14;
constexpr u_int8_t led_3 = 26;

    switch (taskState)
    {
        case TaskStates::INIT:
        {
            Serial.begin(115200);
            pinMode(button1, INPUT_PULLUP);
            pinMode(button2, INPUT_PULLUP);
            pinMode(button3, INPUT_PULLUP);
            pinMode(led_1, OUTPUT);
            digitalWrite(led_1, LOW);
            pinMode(led_2, OUTPUT);
            digitalWrite(led_2, LOW);
            pinMode(led_3, OUTPUT);
            digitalWrite(led_3, LOW);
            taskState = TaskStates::COMPARE;
        }
        break;

        case TaskStates::COMPARE:
        {
            if (Serial.available() > 0)
            {
         
                String command = Serial.readStringUntil('\n');
                if (command == "Case1"){
                    Serial.print("button1: ");
                    Serial.print(btnState(digitalRead(button1)).c_str());
                    Serial.print('\n');     
                }
                else if (command == "Case2"){
                    Serial.print("button2: ");
                    Serial.print(btnState(digitalRead(button2)).c_str());
                    Serial.print('\n');    
                }
                else  if (command == "Case3"){
                    Serial.print("button3: ");
                    Serial.print(btnState(digitalRead(button3)).c_str());
                    Serial.print('\n');               
                }
                if (command == "led_1ON"){
                    digitalWrite(led_1, HIGH);
                }
                if (command == "led_1OFF"){
                    digitalWrite(led_1, LOW);
                }
                if (command == "led_2ON"){
                    digitalWrite(led_2, HIGH);
                }
                if (command == "led_2OFF"){
                    digitalWrite(led_2, LOW);
                }
                if (command == "led_3ON"){
                    digitalWrite(led_3, HIGH);
                }
                if (command == "led_3OFF"){
                    digitalWrite(led_3, LOW);
                }  
            }
        }
        break;

        default:
        break;
    }
}