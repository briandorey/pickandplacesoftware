#include <Wire.h>
#include <TimerOne.h>

// i2c def
#define  SLAVE_ADDRESS         0x14  
#define  REG_MAP_SIZE             14
#define  MAX_SENT_BYTES       1


byte registerMap[REG_MAP_SIZE];
byte registerMapTemp[REG_MAP_SIZE - 1];
byte receivedCommands[MAX_SENT_BYTES];

// feeder location variables
long feederArray[16]={
  0,
  106,
  213,
  320,
  426,
  533,
  640,
  746,
  853,
  960,
  1066,
  1173,
  1280,
  1386,
  1493,
  1600
};

int speedArray[200];
long stepstomove = 0;
long currentposition = 0;
int previousposition = 0;

byte currentFeeder = 0;
byte previousFeeder = 0;
byte pickaftermove = 0;

float stepperSpeed = 450; // lower = faster
float stepperAcceleration = 0.92; // closer to 1 = slower accelleration
float stepperStartSpeed = 10000;
int decelerationPoint = 0;
float currentSpeed = 0;
int timeTillStep = 0;

// Arduino pin mapping for stepper and IO control
#define relayZPin1 5
#define relayZPin2 6
#define stopZPin 2
#define dirXPin 4
#define stepXPin 3
#define stopXPin 7
#define pickerRunning A3


void setup()
{  
  // configure i2c inputs
  Wire.begin(SLAVE_ADDRESS); 
  //Wire.onRequest(requestEvent);
  Wire.onReceive(receiveEvent);

  // configure stepper drivers and air valve
  pinMode(relayZPin1, OUTPUT);
  pinMode(relayZPin2, OUTPUT);
  pinMode(stopZPin, INPUT);
  pinMode(dirXPin, OUTPUT);
  pinMode(stepXPin, OUTPUT);
  pinMode(stopXPin, INPUT);
  pinMode(pickerRunning, OUTPUT);  
 
  digitalWrite(stopZPin, LOW);
  digitalWrite(stopXPin, LOW);

  initStepper();
  while (!Zero());
}

void loop()
{      
}

void initStepper(){
    Timer1.initialize(stepperSpeed); // set a timer of length 100000 microseconds (or 0.1 sec - or 10Hz => the led will blink 5 times, 5 cycles of on-and-off, per second)
    Timer1.attachInterrupt( Stepper_Step ); // attach the service routine here
}

void Stepper_Move(long movepos, int feeder){
  
    if ((previousFeeder == feeder + 1) || (previousFeeder == feeder - 1)){
      stepperSpeed = 800; 
    }
    else if ((previousFeeder == feeder + 2) || (previousFeeder == feeder - 2)){
      stepperSpeed = 600; 
    }    
    else{
       stepperSpeed = 450; 
    }    
    
    if ((movepos - currentposition) < 0){
        digitalWrite(dirXPin, LOW);
        stepstomove = (movepos - currentposition) * -1;
    }
    else{
       digitalWrite(dirXPin, HIGH); 
       stepstomove = (movepos - currentposition);
    }
    
    currentSpeed = stepperStartSpeed; // set the currentAcceleration to default
    decelerationPoint = 0;
    currentposition = movepos;
}

void Stepper_Step(){
  
    if (stepstomove > 0){      
        digitalWrite(stepXPin, HIGH);
        delayMicroseconds(5);
        digitalWrite(stepXPin, LOW);
        stepstomove--;
        if (stepstomove >= decelerationPoint){
          if (currentSpeed > 1){ 
              currentSpeed = currentSpeed * stepperAcceleration;   
              decelerationPoint = decelerationPoint + 1;            
         } else {
              currentSpeed = 1;
          }          
          timeTillStep = stepperSpeed + currentSpeed;
          speedArray[decelerationPoint] = timeTillStep;
           
        }
        if (stepstomove < decelerationPoint){
          timeTillStep = speedArray[stepstomove + 1];
        }
        Timer1.setPeriod(timeTillStep);      
    }
    else{
      if (pickaftermove == 1){                  
           PickerDown();
      }
    }
}

void PickerDown(){
     digitalWrite(relayZPin1, LOW); // set solenoid relay 1 to on
     digitalWrite(relayZPin2, HIGH); // set solenoid relay 1 to off 
     digitalWrite(pickerRunning, LOW);
}

boolean PickerUp(){
  digitalWrite(pickerRunning, HIGH);
     digitalWrite(relayZPin1, HIGH); // set solenoid relay 1 to on
     digitalWrite(relayZPin2, LOW); // set solenoid relay 1 to off 
     while (digitalRead(stopZPin)) {
        delay(10);
     }
     return true;    
}

boolean Zero() {
  // disable picker ram
  digitalWrite(relayZPin1, HIGH); // set solenoid relay 1 to off
  digitalWrite(relayZPin2, LOW); // set solenoid relay 1 to on
  
  digitalWrite(pickerRunning, HIGH); // signal to host that picker is runnning

  PickerUp();

  digitalWrite(dirXPin, LOW);

  while (!digitalRead(stopXPin)) {
    digitalWrite(stepXPin, HIGH);
    delayMicroseconds(100); 
    digitalWrite(stepXPin, LOW);
    delayMicroseconds(2000);
  }
  delayMicroseconds(250);

  currentFeeder = 0;
  
  digitalWrite(pickerRunning, LOW); // signal to host that picker is stopped
  stepstomove = 0;
  currentposition = 0;
  previousposition = 0;

  currentFeeder = 0;
  previousFeeder = 0;
  pickaftermove = 0;
  
  return true; 
}

void moveToPosition(int feeder){

  // disable picker ram
  PickerUp();

  if (feeder == previousFeeder){
    PickerDown();
  }
  
  else{
    Stepper_Move(feederArray[feeder], feeder);  
    pickaftermove = 1;
  }
  previousFeeder = feeder;
}

// i2c code

void requestEvent(){
  //Wire.write(registerMap, REG_MAP_SIZE);  //Set the buffer up to send all 14 bytes of data
  //Wire.write( (const byte *) "a", 1);
  //Serial.write("bytes requested");
}

void receiveEvent(int bytesReceived)
{
  int x = 99;  
  while (Wire.available())
{
  x = Wire.read();    // receive byte as an integer
}
  
  switch(x){
    // pick component commands
  case 0:
    moveToPosition(0);
    break;
  case 1:
    moveToPosition(1);
    break;
  case 2:
    moveToPosition(2);
    break;
  case 3:
    moveToPosition(3);
    break;
  case 4:
    moveToPosition(4);
    break;
  case 5:
    moveToPosition(5);
    break;
  case 6:
    moveToPosition(6);
    break;
  case 7:
    moveToPosition(7);
    break;
  case 8:
    moveToPosition(8);
    break;
  case 9:
    moveToPosition(9);
    break;
  case 10:// int 10
    moveToPosition(10);
    break;
  case 11:// int 11
    moveToPosition(11);
    break;
  case 12:// int 12
    moveToPosition(12);
    break;
  case 13:// int 13
    moveToPosition(13);
    break;
  case 14:// int 14
    moveToPosition(14);
    break;
  case 15: // int 15
    moveToPosition(15);
    break;
    // reset commands
  case 70: // int 70
    // reset picker
    while (!Zero());
    previousFeeder = 0;
    //stepperX.setCurrentPosition(0);

    break;
  case 80: // int 80
    // reset picker z axis, turn off ram
    PickerUp();
    break;
    
  default:
    break;
  }
  
}



