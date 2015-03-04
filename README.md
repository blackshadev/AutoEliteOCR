AutoEliteOCR will trigger EliteOCR upon taking a snapshot. 
The results of eliteOCR will be stored in memory untill the program is told to 
write the data to a file.

# Downloading
Click [here](executable/AutoEliteOCR.exe) to download the latest version.

# Instructions
Extract the .exe to a location of your choice. Double click to open.

**The program will start minimized in the system tray**, right click on the newly added icon to view the tray menu. 

Click on options from the tray menu to open a options window.

In here **you need to specify all paths in order for the program to start watching**

## Paths
*   Screenshot Folder: The folder where Elites puts it screenshots (Elites default path is ~/pictures/Frontier Developments/Elite Dangerous
*   EliteOCR folder: The folder of the EliteOCR tool, the folder must contain the `/bin` folder and the `eliteOCR.exe` program. (do not select the bin folder as the EliteOCR folder, it must be it's parent)
*   Tmp folder: A folder where the tool will output temporary files containing the output of the eliteOCR tool.
*   Csv Folder: The output folder where to store the resulting CSV files.

In the options you can also choice the tool to automatically delete any processed  images.

You can **press start** in the tray menu or options menu. Now when you take a screenshot in elite, the images will automatically be processed. And instead of every screenshot to result in a new file, you can choice when to write the results to file. This is done via the tray menu's 'write out' option or in the option menu 'Write to file' button.

# Requirements

EliteOCR needs to be working correctly. Please test this before using this tool.

If you have problems with EliteOCR visit their forum thread. Trudds trading tool ([http://www.elitetradingtool.co.uk/](http://www.elitetradingtool.co.uk/)) also provides a handy guide on how to setup and use eliteOCR. (NoteL you need to be logged in order to see this guide, this is because it is on the actual import page) 

# Updates
*   20-2-2015 20:00UTC: A minor bug where a UI update causes an error, added BPC support.


# Problems?
Add an issue or see [this thread](https://forums.frontier.co.uk/showthread.php?t=116807&p=1814155#post1814155)