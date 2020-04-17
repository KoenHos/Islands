

#window = Tk()
#window.title("kekw")
#window.configure (background="black")
###window.configure (background="red")
#Label (window, text="hoi", bg="black", fg="red") .grid(row=1, column=0, sticky=W)
#window.mainloop()


#frame = Tk()

#topframe = Frame(frame)
#topframe.pack()
#knop = Button(topframe, text="druk mij in", fg="red", command=chrome)
#knop.grid(row=2)
#frame.title("hoi dit is mijn programma en ik weet niet hoe ik het moet gebruiken")
#frame.mainloop()
#--------------------------------------------------------------------------------------------------#
#getest dingen#

from tkinter import *
import subprocess
import webbrowser
import os
import winsound

#defs
def chrome():
      subprocess.call("C:\Program Files (x86)\Google\Chrome\Application\chrome.exe")
def school():
 webbrowser.open_new_tab("https://somtoday.nl")
 webbrowser.open_new_tab("https://amstelveencollege.zportal.nl/")
 os.startfile("teams.bat")
def goat():
 winsound.PlaySound("goat.wav", winsound.SND_FILENAME)


#GUI
project = Tk()

#photos
geit = PhotoImage(file="goat.png")


#text
ding = Label(project, text="als je op deze knop drukt open je google chrome", fg="black", bg="white", height=1)
schooltext = Label(project, text="als je deze knop indrukt open je school sites", fg="black", bg="white", height=1, width=37)


#knop
chromeknop = Button(text="open google chrome", fg="red", command=chrome)
schoolknop = Button(text="school", fg="red", command=school, width=16)
soundbuttongeit = Button(image=geit, width=50, height=50, command=goat)

#plaatsing IK MOET PACK GEBRUIKEN
ding.grid(row=1, column=1) 
chromeknop.grid(row=1, column=2)
schooltext.grid(row=2, column=1)
schoolknop.grid(row=2, column=2)
soundbuttongeit.grid()

#gui laten zien
project.mainloop()

