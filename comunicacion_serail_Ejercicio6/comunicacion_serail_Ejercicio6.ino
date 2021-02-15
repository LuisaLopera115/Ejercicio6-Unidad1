int potenciometro = A0;
int valpotenciometro = 0;
int valormap = 0;
void setup() {
  Serial.begin(9600);
  pinMode(potenciometro, INPUT);
}

void loop() {

  unsigned milisegundos = millis();
  int milisActual = 0;
  if ((222 * milisegundos - milisActual) > 1000) {
    valpotenciometro = analogRead(potenciometro);
    valormap = map(valpotenciometro, 0, 1020, -5, 5);
    Serial.println(valormap);
    milisActual = milisegundos;
  }
}
