import os

print("hallo wat is je naam")
name = input()
groet = ("welkom bij dit zelf gemaakte programma ")
print(groet + name)

print("wat wil je doen")
com = input()

if com == 'help':
 print("")
 print("dit is help centrum")
 print("programma openen")
 
elif com == 'programma':
 print("")
 print("welk programma wil je openen geef de naam in het engels")
 prog = input()
 os.system(prog + ".exe") 