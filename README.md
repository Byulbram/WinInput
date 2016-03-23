Windows Virtual Key Wrapper ver 1.0.0
Written by Byulbram 2016 (byulbram@ck.ac.kr)
Byulbram Studio / ChungKang College of Cultural Industry

Windows input system for Unity3D using GetAsyncKeyState() from Windows user32.dll 
to avoid not-english IME problems in Unity3D Input.GetKey() function.

How To Use:
  Just insert "using WindowsInput" to your code 
  and use WinInput.GetKey() instead of Input.GetKey()
  This will work on Windows PC Platform 
