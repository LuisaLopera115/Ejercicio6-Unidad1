  int potenciometro = A0;
int valpotenciometro = 0;
int valormap = 0;
unsigned long previousMillis = 0;  
void setup() {
  Serial.begin(9600);
  pinMode(potenciometro, INPUT);
}

void loop() {

  unsigned long currentMillis = millis();
  int milisActual = 0;
  if ((currentMillis - previousMillis) > 100) {
    previousMillis =currentMillis;
    valpotenciometro = analogRead(potenciometro);
    valormap = map(valpotenciometro, 0, 1020, -9, 9);
    Serial.println(valormap);
  }
}
