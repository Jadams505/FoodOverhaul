from tkinter import Tk
from tkinter.filedialog import askopenfilename, asksaveasfilename
import os

def parseContents():
	key = contents[0].split(",")
	key = [key.index("Mod"), key.index("Item ID"), key.index("Calories"),
		key.index("Fat"), key.index("Sodium"), key.index("Carbs"), key.index("Protein")]
	formatted = []
	for i in range(1, len(contents)):
		line = contents[i]
		tokens = line.split(",")
		if (tokens[key[1]].isdigit() and tokens[key[2]].isdigit() and tokens[key[3]].isdigit() 
			and tokens[key[4]].isdigit() and tokens[key[5]].isdigit() and tokens[key[6]].isdigit()):
			formatted.append(format(tokens, key))
	return formatted


def format(tokens, key):
	return ("set.Add(VanillaEntry(id: " + tokens[key[1]] + "," + " calories: " + tokens[key[2]] + ", fat: " + tokens[key[3]] + 
		 ", sodium: " + tokens[key[4]] + ", carbs: " + tokens[key[5]] + ", protein: " + tokens[key[6]] + "));")


Tk().withdraw()
filename = askopenfilename(filetypes = [("CSV Files", "*.csv")])
print(filename)

openfile = open(filename, "r")
contents = openfile.readlines()
openfile.close()

toAdd = parseContents()
writefile = asksaveasfilename(defaultextension = "*.txt", filetypes = [("Text Files", "*.txt")])
outputfile = open(writefile, "w")
for line in toAdd:
	outputfile.write(line + "\n")
outputfile.close()

os.system("pause")

