Windows Virtual Key Wrapper ver 1.0.2
Written by Byulbram (KwangSam Kim) 2016 (byulbram@gmail.com)

Windows input system for Unity3D using GetAsyncKeyState() from Windows user32.dll 
to avoid not-english IME problems in Unity3D Input.GetKey() function.
You can use Unity Keycode in this WinInput.GetKey() 

You can use this code for free at any situation.

How To Use:
  Just insert "using WindowsInput" to your code 
  and use WinInput.GetKey() instead of Input.GetKey()
  This will work on Windows PC Platform 
  
Sample Scene:
  https://github.com/Byulbram/WinInputSample

Update Log:

1.0.0 (2016)

1.0.1 (2021.01.08): Fixed Bug for Getkey not released. thanks to 우유들컴(4joseph)

1.0.2 (2021.01.08): Added GetKeyDown and GetKeyUp function. thanks to FlashScape

