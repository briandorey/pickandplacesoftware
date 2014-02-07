#include <Wire.h>
#include <AccelStepper.h>

// i2c def
#define  SLAVE_ADDRESS         0x29  
#define  REG_MAP_SIZE             14
#define  MAX_SENT_BYTES       1


byte registerMap[REG_MAP_SIZE];
byte registerMapTemp[REG_MAP_SIZE - 1];
byte receivedCommands[MAX_SENT_BYTES];

// stepper control
// feeder location variables
long feederArray[16]={
  0,
  -106.6666666667,
  -213.3333333333,
  -320,
  -426.6666666667,
  -533.3333333333,
  -640,
  -746.6666666667,
  -853.3333333333,
  -960,
  -1066.6666666667,
  -1173.3333333333,
  -1280,
  -1386.6666666667,
  -1493.3333333333,
  -1600
};


long xcurrentpos = 0;
int currentFeeder = 0;
int previousFeeder = 0;
int sensorValue = 0;
int zHeight = -700; //-5600;

// Arduino pin mapping for stepper and IO control
#define ZPin 10
#define stopZPin A1
#define dirXPin 12
#define stepXPin 13
#define stopXPin A0
#define pickComplete 8

AccelStepper stepperX(1,stepXPin,dirXPin); 

void setup()
{
  // serial for debugging 
  Serial.begin(9600);
  
  // configure i2c inputs
  Wire.begin(SLAVE_ADDRESS); 
  Wire.onRequest(requestEvent);
  Wire.onReceive(receiveEvent);


  pinMode(pickComplete, OUTPUT);

  // configure stepper drivers and air valve
  pinMode(ZPin, OUTPUT);
  pinMode(dirXPin, OUTPUT);
  pinMode(stepXPin, OUTPUT);

  stepperX.setMaxSpeed(15000);
  stepperX.setAcceleration(25000);


  stepperX.setCurrentPosition(0);

  //while (!Zero());

}

void loop()
{

}

boolean Zero() {
  digitalWrite(ZPin, LOW);
  sensorValue = analogRead(stopZPin); 
  while (sensorValue >= 100) {
    delayMicroseconds(4000);
    sensorValue = analogRead(stopZPin);  
  }

  digitalWrite(dirXPin, LOW);
  sensorValue = analogRead(stopXPin);    

  while (sensorValue <= 200) {
    digitalWrite(stepXPin, HIGH);
    delayMicroseconds(50); 
    digitalWrite(stepXPin, LOW);
    delayMicroseconds(4000);
    sensorValue = analogRead(stopXPin); 
  }
  delayMicroseconds(250);
  sensorValue = 0;
  currentFeeder = 0;
  return true; 
}

void calcXPosition(int feeder){
  digitalWrite(pickComplete, LOW);
  digitalWrite(ZPin, LOW);
  sensorValue = analogRead(stopZPin); 
  while (sensorValue >= 100) {
    delayMicroseconds(4000);
    sensorValue = analogRead(stopZPin);  
  }

  if (currentFeeder == feeder){
    digitalWrite(ZPin, HIGH);
  }
  else{
    long travel = feederArray[feeder];
    travel = travel *-1;
    stepperX.runToNewPosition(travel);
    digitalWrite(ZPin, HIGH);
    xcurrentpos = feederArray[feeder];
  }
  previousFeeder = currentFeeder;
  currentFeeder = feeder;
  digitalWrite(pickComplete, HIGH);
}

// i2c code

void requestEvent(){
  Wire.write(registerMap, REG_MAP_SIZE);  //Set the buffer up to send all 14 bytes of data
}

void receiveEvent(int bytesReceived)
{
  for (int a = 0; a < bytesReceived; a++)
  {
    if ( a < MAX_SENT_BYTES)
    {
      receivedCommands[a] = Wire.read();

    }
    else
    {
      Wire.read();  // if we receive more data then allowed just throw it away
    }
  }
  Serial.write(receivedCommands[0]);
  
  switch(receivedCommands[0]){
    // pick component commands
  case 0x00:
    calcXPosition(0);
    return; 
    break;
  case 0x01:
    calcXPosition(1);
    return; 
    break;
  case 0x02:
    calcXPosition(2);
    return; 
    break;
  case 0x03:
    calcXPosition(3);
    return; 
    break;
  case 0x04:
    calcXPosition(4);
    return; 
    break;
  case 0x05:
    calcXPosition(5);
    return; 
    break;
  case 0x06:
    calcXPosition(6);
    return; 
    break;
  case 0x07:
    calcXPosition(7);
    return; 
    break;
  case 0x08:
    calcXPosition(8);
    return; 
    break;
  case 0x09:
    calcXPosition(9);
    return; 
    break;
  case 0x0A:// int 10
    calcXPosition(10);
    return; 
    break;
  case 0x0B:// int 11
    calcXPosition(11);
    return; 
    break;
  case 0x0C:// int 12
    calcXPosition(12);
    return; 
    break;
  case 0x0D:// int 13
    calcXPosition(13);
    return; 
    break;
  case 0x0E:// int 14
    calcXPosition(14);
    return; 
    break;
  case 0x0F: // int 15
    calcXPosition(15);
    return; 
    break;
    // reset commands
  case 0x46: // int 70
    // reset picker
    while (!Zero());
    currentFeeder = 0;
    stepperX.setCurrentPosition(0);
    return; 
    break;
  case 0x50: // int 80
    // reset picker z axis, turn off valve
    digitalWrite(ZPin, LOW);
    return; 
    break;
    
  default:

    return; // ignore the commands and return

  }
}



