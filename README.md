
# LogonVistaOrb

LogonVistaOrb is a .NET Framework app designed to bring the iconic Windows Vista startup animation in the login screen to Windows 10 and up

<p align="center">
<img src="https://i.imgur.com/wTzRBD2.png" height=300 border="10"/>
</p>
Windows Vista is a trademark of Microsoft Corporation. I am not affiliated with Microsoft, nor does Microsoft endorse the creation of this product.

## Customizing

### Changing the Graphics and Sounds
Head over to C:\Windows\System32\LogonVistaOrb. In there, you will find two folders, named "Images" and "Sounds". You can replace them with whatever you like. If you're looking for some skins online, try some of these pages:

https://www.deviantart.com/slicedefender/gallery?q=boot+logo

https://www.deviantart.com/xantic21/gallery?q=tuneup

https://www.deviantart.com/yethzart/art/Authui-dll-Vista-RTM-and-SP1-84385962

You may need [Resource Hacker]("https://www.angusj.com/resourcehacker/#download") to extract the images if the skin is offered as a DLL.

If you'd also like to use a custom background image, you can copy a PNG image to the "Images" folder, and rename it to "background.png". This image will be stretched to fill the entire screen, so make sure it matches your monitor's aspect ratio.

### Changing the program behaviour
LogonVistaOrb comes with a configuration tool to change how the program works. It features the following:
- Enabling/Disabling the program
- Toggling the startup sound
- Toggling the logon sound
- Toggling the shutdown sound
- The option to wait for the Windows audio service to start
- Changing the background color

## Compiling the software
LogonVistaOrb does not use a makefile, so you will need to manually compile it using a version of Visual Studio that supports the .NET Framework v4.8

For whatever reason you wish to compile the source code, bare in mind, that if you want to publish your own fork of the program, you must abide by the rules of the [GPL v3.0]("https://github.com/xxxman360/LogonVistaOrb/blob/main/LICENSE").

### Order of solutions to compile
1. You will need to compile the LogonVistaOrbInit solution first, if you are not planning on modifying it, you can skip this step. 
    - Once you have your compiled EXE, copy it to the LogonVistaOrb solution, and paste it in the folder named "LogonVistaOrb" (Note, this is a subfolder, so "LogonVistaOrb/LogonVistaOrb")

2. Compile the LogonVistaOrb solution, when you have your build, compress the "LogonVistaOrb" folder and "LogonVistaOrb.exe" from the output directory into a ZIP file named "app.zip"
    - Copy the ZIP file to the LogonVistaOrbInstaller solution, and paste it in the "Resources" folder.

3. You can now compile the LogonVistaOrbInstaller solution. It is recommended to make a 32 bit and 64 bit build to ensure the registry is accessed correctly. 

Have fun!
