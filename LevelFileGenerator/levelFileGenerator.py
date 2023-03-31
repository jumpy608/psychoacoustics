'''
Level File Generator 

Description: This program takes in a ".wav" file and outputs a level file  
Name: David Dahl
Created: 2.5.2023 adapted from the origninal level file generator programs
Revised: 
    David Dahl, 2.12.23 reviewed program and tested edge cases
    David Dahl, 2.16.23 ran stress tests and updated outputs to conform to current level file format, added in random elements
    David Dahl, 2.26.23 worked on improving file preformace and removing edge cases that hindered normal use

A non fatal error can occur with files longer then 30s
'''
import sys, os, os.path
from scipy.io import wavfile
import pandas as pd
import random


#takes in the wav file and makes sure it is the proper file type
input_filename = input("Input wav file name:")
if input_filename[-4:] != '.wav':
    print('file needs to end in .wav')
    sys.exit()

#imputs the wavfile data into variables so they can be turns into a data frame
samrate, data = wavfile.read(str('./wavfile/' + input_filename))

#default to my understanding of wav files
dataPointsPerSecondinWav = 48000

#current default of our game
notesPerSecond = 12.8

#percential choice
percential = 95

#noterange
noterange = 12

dataPointsPerNote = dataPointsPerSecondinWav/notesPerSecond

#inputs data into a dataframe
wavData = pd.DataFrame(data)

#names the colums of the wavdata so the can be used
if len(wavData.columns) == 2:
    wavData.columns = ['R', 'L']

elif len(wavData.columns) == 1:
    wavData.columns = ['L']

#intilizes a table to generize large amounts of data into smaller points
titleformat = {'id':[], 'mean':[], 'max':[], (str(percential)+"%"):[]}
representationData = pd.DataFrame(titleformat)

wavColstoProcess = len(wavData)
processedCols = 0

#collects the data and inputs it into the representationData table 
while(dataPointsPerNote <= wavColstoProcess):
    wavColstoProcess = wavColstoProcess - dataPointsPerNote
    tempRep = (wavData.iloc[int(processedCols):int(processedCols+dataPointsPerNote)].abs().describe(percentiles=[percential/100]))
    representationData.loc[len(representationData.index)] = [wavColstoProcess,tempRep.loc["mean","L"],tempRep.loc["max","L"],tempRep.loc[(str(percential)+"%"),"L"]]
    processedCols = processedCols + dataPointsPerNote

wavColstoProcess = len(wavData)
processedCols = 0

finalProcessMax = []
finalProcessAt = []
itt=0

#itterates through the generized points and if they have high enough importance compared to there neighbors they are recorded
while(dataPointsPerNote <= wavColstoProcess):
    wavColstoProcess = wavColstoProcess - dataPointsPerNote

    rangemax=itt+noterange+1
    rangemin=itt-noterange

    if(rangemax>(len(representationData))):
        rangemax=(len(representationData))

    if(rangemin<0):
        rangemin=0

    tempPro = representationData.abs().iloc[int(rangemin):int(rangemax),3]


    #if(tempPro.max() == representationData.abs().iloc[itt,3]):

    finalProcessMax.append(tempPro.max())
    finalProcessAt.append(representationData.abs().iloc[itt,3])
    itt=itt+1



#print(finalProcessMax)
#print(finalProcessAt)

#outputs finalProcessAt into the format of the level file 
for i in range(len(finalProcessMax)):
    if(finalProcessMax.count(finalProcessAt[i])):
        print(random.randint(1, 3),end=" ")
    else:
        print("-",end=" ")
    if(((i+1)%4)==0):
        print("|")

#representationData.to_csv(str("levelfile_" + input_filename[:-4] + ".csv"), mode='w')
