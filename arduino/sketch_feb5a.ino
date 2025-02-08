#include "HX711.h"

#define DT_PIN 3  
#define SCK_PIN 2  

HX711 scale;
float calibration_factor = 1.0;  // Калибровочный коэффициент

void setup() {
    Serial.begin(9600);
    scale.begin(DT_PIN, SCK_PIN);
    scale.tare();  // Сразу обнуляем весы при старте
}

void loop() {
    if (Serial.available() > 0) {
        String command = Serial.readStringUntil('\n');
        command.trim(); 

        if (command.startsWith("CAL ")) {  
            calibration_factor = command.substring(4).toFloat();
        } 
        else if (command == "TARE") { 
            scale.tare();  // Используем tare(), а не get_units()
        } 
        else if (command == "GET") { 
            long weight = scale.get_units(1) * calibration_factor;
            Serial.println(weight);  
        }
    }
}

