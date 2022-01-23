from tkinter import Tk
from tkinter.filedialog import askopenfilename, asksaveasfilename
import os

class Key:
	def __init__(self, mod, name, itemid, calories, fat, sodium, carbs, protein):
		self.mod = mod
		self.itemid = itemid
		self.name = name
		self.calories = calories
		self.fat = fat
		self.sodium = sodium
		self.carbs = carbs
		self.protein = protein


def parseContents():
	keyarray = contents[0].split(",")
	key = Key(keyarray.index("Mod"), keyarray.index("Name"), keyarray.index("Item ID"), keyarray.index("Calories"),
		keyarray.index("Fat"), keyarray.index("Sodium"), keyarray.index("Carbs"), keyarray.index("Protein"))
	formatted = []
	for i in range(1, len(contents)):
		line = contents[i]
		tokens = line.split(",")
		if (tokens[key.calories].isdigit() and tokens[key.fat].isdigit() 
			and tokens[key.sodium].isdigit() and tokens[key.carbs].isdigit() and tokens[key.protein].isdigit()):
			formatted.append(format(tokens, key))
			
	return formatted


def format(tokens, key):
	
	mod = tokens[key.mod]
	name = tokens[key.name]
	itemid = tokens[key.itemid]
	calories = tokens[key.calories]
	fat = tokens[key.fat]
	sodium = tokens[key.sodium]
	carbs = tokens[key.carbs]
	protein = tokens[key.protein]
	if mod == "Terraria":
		return ("AddVanillaEntry(set, id: " + itemid + "," + " calories: " + calories + ", fat: " + fat + 
		 ", sodium: " + sodium + ", carbs: " + carbs + ", protein: " + protein + ");")
	else:
		return ("AddModdedEntry(set, mod: \"" + mod + "\", name: \"" + name + "\", calories: " + calories + ", fat: " + fat + 
		 ", sodium: " + sodium + ", carbs: " + carbs + ", protein: " + protein + ");")


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

