# NoCableLauncher
Rocksmith 2014 Launcher for playing without original RealTone cable (nocable fix).

Working principle based on [this information](http://cs.rin.ru/forum/viewtopic.php?f=10&t=63705&p=1006201#p1006201).

Multiplayer fix based on [AutoIt script](https://dl.dropboxusercontent.com/u/1288526/rocksmith2014_nocable_pbs.au3) by [phobos2077](https://github.com/phobos2077).

This project uses [Core Audio API](https://github.com/morphx666/CoreAudio).

### Downloads

[NoCableLauncher-m-binary.rar (Lastest version with multiplayer support)](https://www.dropbox.com/s/4a7l3ggd94jjd2z/NoCableLauncher-m-binary.rar)

### Getting Started
1) Unpack files to any folder.

2) Configure launcher using friendly UI by running "EditSettings.bat".

3) Run "NoCableLauncher.exe" for playing Rocksmith 2014 using your own audio interface!


### Setting Tips

![Settings Window](http://images.illuzor.com/uploads/rs14ncl.png)

* If you have Steam-licensed Rocksmith 2014, check the "Steam game" box, otherwise leave this checkbox and browse game EXE-file by pressing "..." button.
* "Device" сombobox contains all **active** found input audio devices in your system. Select the device connected to your guitar. If your device is not in the list, check the "Manual" box and set VID & PID values manually (find it in "Device manager"). VID & PID sets as "0000" means default non-USB input audio device, for example integrated Realtek microphone input.
* Press "OK" to save settings and close window or "Cancel" to close window without saving.
* To play multiplayer, check "Enable Multiplayer" box in the settings window and set **different** input devices for Player1 and Player2, otherwise multiplayer will not work! To activate Player 2 in game, select "Multiplayer" from game menu and press Ctrl+M (global hotkey).
