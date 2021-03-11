int led = 8;
int boton = 7;
int valBotn = 0;
static byte com[1] = {0x3E};
unsigned long previousMillis = 0;  
void setup() {
  Serial.begin(9600);
  pinMode(led, OUTPUT);
  pinMode(boton, INPUT);
  
}

void loop() {
  unsigned long currentMillis = millis();
  valBotn = digitalRead(boton);
  if ((currentMillis - previousMillis) > 200) {
    previousMillis =currentMillis;
    if (valBotn == HIGH) {
      Serial.write(com,1);
      digitalWrite(led, HIGH);
    } else {
      digitalWrite(led, LOW);
      
    }
  }
}
