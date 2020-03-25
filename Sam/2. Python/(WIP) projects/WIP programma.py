import os
import time


print("hallo wat is je naam")
name = input("")
groet = ("welkom bij dit zelf gemaakte programma ")
print(groet + name)
print("wat wil je doen")
I = input()
while True:

 if I == 'help':
  print("") #leege line
  print("dit is help centrum")
  print("wat je kan doen is")
  print("")
  print("programma openen")
  print("")
  I = input()


#loop
 elif I  == 'programma':
  print("")
  print("welk programma wil je openen geef de naam in het engels")
  prog = input()
  os.system(prog + ".exe")
  I = input()


 else:
  print("dit is geen programma of iets")
  I = input()

