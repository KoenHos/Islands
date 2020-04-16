import os
import time
import tkinter


print("hallo wat is je naam")
name = input("")
os.system("cls")
groet = ("welkom bij dit zelf gemaakte programma ")
print(groet + name)
print("wat wil je doen")
print("")
print("help - voor als je hulp wilt")
print("programma - als je een programma wilt openen")
print("")
I = input()
while True:

#hulp voor gebruiker
 if I == 'help':
  print("") #leege line
  print("dit is help centrum")
  print("wat je kan doen is")
  print("")
  print("programma - hier kan je een programma mee openen")
  print("help - dan krijg je dit scherm wilt")
  print("meer hulp - krijg je meer hulp")
  print("")
  I = input()


#loop
 elif I  == 'programma':
  print("")
  print("welk programma wil je openen?")
  print("notepad - je doodgewone kladblok waar je kan typen wat je wilt")
  print("anders - als je iets anders wilt open")
  prog = input()
  while True: #loop in een loop alle programmas opties

   if prog == ("notepad"):
     os.system("Notepad.exe")
    

   elif prog == "anders":
     print("wat wil je openen?")
     anders = input()
     os.system(anders + ".exe")
     I = input()

   else:
    print("")
    print("dit is niks de commando's zijn")
    print("programma - voor als je een programma wilt openen")
    print("help - voor als je hulp wilt")
    I = input()
    break

    
     

 elif I == ("meer hulp"):
  print("dit programma is gemaakt door sam vraag hem voor meer hulp")
  I = input()
 


 else:
  print("dit is geen commando de commando's zijn")
  print("Programma")
  print("Help")
  print("")
  I = input()

