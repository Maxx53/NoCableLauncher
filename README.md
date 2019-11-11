# NoCableLauncher
Rocksmith 2014 Remastered Launcher for playing without original RealTone cable (nocable fix).

Created by [Maxx54](https://github.com/Maxx53)
Improved by [Mywk](https://github.com/Mywk)

### Changelog


###### Version 2.0.1

- Fixed: No need to disable all audio devices, only conflicting devices will be automatically disabled and restored

###### Version 2.0

- New logo
- Crash fixes
- Code cleanup
- Interface re-design
- Automatic enable/disable of capture devices
- Several fixes for those using the onboard soundcard
- Automatic switching to secondary input if primary isn't plugged in


### Downloads

[NoCableLauncher Version 2.0](https://github.com/Mywk/NoCableLauncher/releases/download/2.0/NoCableLauncher.zip)

### Getting Started

1) Unpack the file "NoCableLauncher" to any folder.

2) Open the file "NoCableLauncher".

3) Run "NoCableLauncher" to play Rocksmith 2014 using your own audio interface!

Note: If you want to edit the settings again you can simply open the file "NCL_EditSettings.bat".

### Onboard soundcard

For those who, like me, don't have an extra audio capture device, there are two available options for single player mode:

###### Disable devices and re-enable on game close
All audio capture devices except the one used in game will be disabled when the game opens and re-enabled when the game closes.

Note: This prevents you from using other capture devices, for example if you want to be in a call while you play.

###### Prevent game from recognizing more devices
All audio capture devices except the one used in-game will be disabled when the game opens.

After the game is opened and in the main menu, press ALT-TAB to leave the game and press 'OK' on the message prompt, this will prevent the game from recognizing any other device and re-enable the disabled ones.

This allows you to use your microphone or any other device outside the game (assuming the game is not in exclusive mode).

### Setting Tips

![Settings Window](https://techcoders.net/images/content/ncl_screenshot.png)

* If you have Steam-licensed Rocksmith 2014, check the "Steam game" box, otherwise leave this checkbox and browse game EXE-file by pressing "..." button.
* "Device" сombobox contains all **active** found input audio devices in your system. Select the device connected to your guitar. If your device is not in the list, check the "Manual" box and set VID & PID values manually (find it in "Device manager"). VID & PID sets as "0000" means default non-USB input audio device, for example integrated Realtek microphone input.
* Press "OK" to save settings and close window or "Cancel" to close window without saving.
* To play multiplayer, check "Enable Multiplayer" box in the settings window and set **different** input devices for Player1 and Player2, otherwise multiplayer will not work! To activate Player 2 in game, select "Multiplayer" from game menu and press Ctrl+M (global hotkey).


### Extra Info

Working principle based on [this information](http://cs.rin.ru/forum/viewtopic.php?f=10&t=63705&p=1006201#p1006201).

Multiplayer fix based on [AutoIt script](https://dl.dropboxusercontent.com/u/1288526/rocksmith2014_nocable_pbs.au3) by [phobos2077](https://github.com/phobos2077).

This project uses [Core Audio API](https://github.com/morphx666/CoreAudio).

### Extra Credits

phobos2077, janabimustafa, Alexx999