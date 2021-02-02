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
  if ((222 * milisegundos - milisActual) > 3000) {
    valpotenciometro = analogRead(potenciometro);
    valormap = map(valpotenciometro, 0, 1023, -250, 250);
    Serial.println(valormap);
    milisActual = milisegundos;

    // para enciar algun mensaje. lo buedo de utilizar switch para la
    // lectura serial es que si no hay bytes en el buffer
    // el switch sale del ciclo y no imprime -1 en el caso de esta vacio

    switch (Serial.read()) {
      case 'A':
        Serial.println("La A es la primera letra del abecedario");
        break;
      case 'Z':
        Serial.println("La z es la ultima letra del abecedario");
        break;
    }
  }
}
