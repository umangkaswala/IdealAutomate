﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows;
using WindowsInput;
using WindowsInput.Native;
using System.IO;
using System.Linq;
using System.Reflection;
using IdealAutomateCore;
using System.Windows.Controls;



namespace IdealAutomate.Core {
  public class Methods {


    private bool fbDebugMode = false;
    private int intFileCtr = 0;
    bool boolUseGrayScaleDB = false;
    public bool DebugMode {
      get { return fbDebugMode; }
      set { fbDebugMode = value; }
    }

    [System.Runtime.InteropServices.DllImport("user32.dll")]
    static extern IntPtr GetOpenClipboardWindow();

    [System.Runtime.InteropServices.DllImport("user32.dll")]
    static extern int GetWindowText(int hwnd, StringBuilder text, int count);

    [System.Runtime.InteropServices.DllImport("user32.dll")]
    private static extern int GetWindowTextLength(int hwnd);

    //Import the FindWindow API to find our window
    [DllImportAttribute("User32.dll")]
    private static extern int FindWindow(String ClassName, String WindowName);

    //Import the SetForeground API to activate it
    [DllImportAttribute("User32.dll")]
    private static extern IntPtr SetForegroundWindow(int hWnd);

    [DllImport("user32.dll")]
    private static extern
      bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);
    [DllImport("user32.dll")]
    private static extern
      bool IsIconic(IntPtr hWnd);

    private const int SW_HIDE = 0;
    private const int SW_SHOWNORMAL = 1;
    private const int SW_SHOWMINIMIZED = 2;
    private const int SW_SHOWMAXIMIZED = 3;
    private const int SW_SHOWNOACTIVATE = 4;
    private const int SW_RESTORE = 9;
    private const int SW_SHOWDEFAULT = 10;
    Process oProcess;
    public Methods() {

      oProcess = Process.GetCurrentProcess();
      BreakOnPauseKeyPress();
      string directory = AppDomain.CurrentDomain.BaseDirectory;
      DirectoryInfo dir = new DirectoryInfo(directory);

      foreach (FileInfo fi in dir.GetFiles()) {
        if (fi.Extension.ToUpper() == ".BMP" && fi.Name.StartsWith("temp")) {
          fi.Delete();
        }
      }
    }

    public bool ActivateWindowByTitle(string myTitle) {

      //Find the window, using the CORRECT Window Title, for example, Notepad
      int hWnd = FindWindow(null, myTitle);
      if (hWnd > 0) //If found
            {
        {
          ShowWindowAsync((IntPtr)hWnd, SW_RESTORE);
        }        
        SetForegroundWindow(hWnd); //Activate it              
        return true;
      } else {
        MessageBox.Show("Window Not Found! - ActivateWindowByTitle:" + myTitle + " You can try to manually activate it and then click okay on this popup" );
        return false;
      }

    }
    /// <summary>
    /// GetWindowTitlesByProcessName allows you to get a list of all the WindowTitles
    /// for a process name. ProcessNames are called image names in task manager.
    /// You can find all of the iexplore or devenv and activate each one to see if it 
    /// is the one you want
    /// </summary>
    /// <param name="myProcessName"></param>
    /// <returns></returns>
    public List<string> GetWindowTitlesByProcessName(string myProcessName) {
      List<string> lstWindowTitles = new List<string>();
      var processes = from proc in System.Diagnostics.Process.GetProcesses() orderby proc.ProcessName ascending select proc;
      foreach (var item in processes) {
        if (item.ProcessName == myProcessName) {
          lstWindowTitles.Add(item.MainWindowTitle);
        }        
      }
      return lstWindowTitles;

    }

    private static string GetOpenClipboardWindowText() {

      var hwnd = GetOpenClipboardWindow();
      if (hwnd == IntPtr.Zero) {
        return "Unknown";
      }
      var int32Handle = hwnd.ToInt32();
      var len = GetWindowTextLength(int32Handle);
      var sb = new StringBuilder(len);
      GetWindowText(int32Handle, sb, len);
      return sb.ToString();
    }
    public DateTime dtStartDateTime = System.DateTime.Now;

    private const int SW_SHOWMINNOACTIVE = 6;
    private const uint SWP_NOACTIVATE = 0X10;




    private const Int32 WM_GETTEXT = 0XD;
    private const Int32 WM_GETTEXTLENGTH = 0XE;


    # region DllImports

    /*- Retrieves Id of the thread that created the specified window -*/
    [DllImport("user32.dll", SetLastError = true)]
    static extern uint GetWindowThreadProcessId(int hWnd, out uint lpdwProcessId);

    /*- Retrieves information about active window or any specific GUI thread -*/
    [DllImport("user32.dll", EntryPoint = "GetGUIThreadInfo")]
    public static extern bool GetGUIThreadInfo(uint tId, out GUITHREADINFO threadInfo);


    /*- Converts window specific point to screen specific -*/
    [DllImport("user32.dll")]
    public static extern bool ClientToScreen(IntPtr hWnd, out System.Drawing.Point position);

    [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "SendMessageA", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
    public static extern Int32 SendMessage(IntPtr hwnd, Int32 wMsg, Int32 wParam, Int32 lParam);
    [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "SendMessageA", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
    public static extern Int32 SendMessage(IntPtr hwnd, Int32 wMsg, Int32 wParam, string lParam);
    [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "GetForegroundWindow", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
    private static extern IntPtr GetForegroundWindow();
    [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "GetWindowThreadProcessId", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
    public static extern int GetWindowThreadProcessId(IntPtr hwnd, ref int lpdwProcessID);
    [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "GetWindowTextA", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
    private static extern int GetWindowText(IntPtr hWnd, string WinTitle, int MaxLength);
    [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "GetWindowTextLengthA", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
    private static extern int GetWindowTextLengthx(int hwnd);
    [DllImport("user32.dll")]
    private extern static bool ShowWindow(IntPtr hWnd, int nCmdShow);

    # endregion
    System.Drawing.Point caretPosition;
    [StructLayout(LayoutKind.Sequential)]    // Required by user32.dll
    public struct RECT {
      public uint Left;
      public uint Top;
      public uint Right;
      public uint Bottom;
    };
    [StructLayout(LayoutKind.Sequential)]    // Required by user32.dll
    public struct GUITHREADINFO {
      public uint cbSize;
      public uint flags;
      public IntPtr hwndActive;
      public IntPtr hwndFocus;
      public IntPtr hwndCapture;
      public IntPtr hwndMenuOwner;
      public IntPtr hwndMoveSize;
      public IntPtr hwndCaret;
      public RECT rcCaret;
    };

    // Point required for ToolTip movement by Mouse
    GUITHREADINFO guiInfo;                     // To store GUI Thread Information

    public long prevElapsedTicks = 0;
    public long ticks;
    public long tempTicks;

    [System.Runtime.InteropServices.DllImport("user32", EntryPoint = "GetAsyncKeyState", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
    private static extern int GetAsyncKeyState(uint vkey);

    private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e) {
      uint VK_PAUSE = 0x13;
      int intPauseKeyState = GetAsyncKeyState(VK_PAUSE);
      if (intPauseKeyState != 0) {
        string FileDes = "IdealAutomateScript"; //FileDescription
        var myCurrentProcess = Process.GetCurrentProcess();
        foreach (Process x in Process.GetProcesses()) {
          try {
            if (FileDes == x.MainModule.FileVersionInfo.Comments && x.ProcessName != myCurrentProcess.ProcessName) {
              //  System.Diagnostics.Debugger.Break();
              x.Kill();
            }
          } catch (Exception) {

            continue;
          }

        }
        try {
          Thread thread = new Thread(new ThreadStart(() => {
            var window = new Window() //make sure the window is invisible
            {
              Width = 300,
              Height = 300,
              Title = "Application Cancelled",
              Content = "Application Cancelled",
              WindowStyle = WindowStyle.ToolWindow,
              Visibility = System.Windows.Visibility.Visible,
              Topmost = true,
              FontSize = 24,
              ShowInTaskbar = true,
              ShowActivated = true,
            };
            window.Show();
            Sleep(5000);
          }));

          thread.SetApartmentState(ApartmentState.STA);

          thread.Start();
          thread.Join();
        } catch (Exception ex) {

        }
        Sleep(500);
        Environment.Exit(0);
        //Here is the code that runs when the hotkey is pressed'
      }
    }
    private void BreakOnPauseKeyPress() {
      // Create a timer and set a two millisecond interval.
      System.Timers.Timer aTimer = new System.Timers.Timer();
      aTimer.Interval = 2;

      // Alternate method: create a Timer with an interval argument to the constructor. 
      //aTimer = new System.Timers.Timer(2000); 

      // Create a timer with a two millisecond interval.
      aTimer = new System.Timers.Timer(2);

      // Hook up the Elapsed event for the timer. 
      aTimer.Elapsed += OnTimedEvent;

      // Have the timer fire repeated events (true is the default)
      aTimer.AutoReset = true;

      // Start the timer
      aTimer.Enabled = true;
    }
    public string GetValueByKey(string pKey, string pInitialCatalog) {

      string myValue = "";
      // InitialCatalog is the database name where keyvalue pairs are stored
      SqlConnection con = new SqlConnection("Server=(local)\\SQLEXPRESS;Initial Catalog=" + pInitialCatalog + ";Integrated Security=SSPI");
      SqlCommand cmd = new SqlCommand("SelectValueByKey", con);
      cmd.CommandType = CommandType.StoredProcedure;

      // Add Parameters to Command Parameters collection
      cmd.Parameters.Add("@myKey", SqlDbType.VarChar);
      cmd.Parameters["@myKey"].Value = pKey;


      try {
        con.Open();
        myValue = (string)cmd.ExecuteScalar();
      } finally {
        con.Close();
      }
      return myValue;
    }
    public string SetValueByKey(string pKey, string pValue, string pInitialCatalog) {

      string myValue = "";
      // InitialCatalog is the database name where keyvalue pairs are stored
      SqlConnection con = new SqlConnection("Server=(local)\\SQLEXPRESS;Initial Catalog=" + pInitialCatalog + ";Integrated Security=SSPI");
      SqlCommand cmd = new SqlCommand("SetValueByKey", con);
      cmd.CommandType = CommandType.StoredProcedure;

      // Add Parameters to Command Parameters collection
      cmd.Parameters.Add("@myKey", SqlDbType.VarChar,500);
      cmd.Parameters["@myKey"].Value = pKey;
      cmd.Parameters.Add("@myValue", SqlDbType.VarChar,500);
      cmd.Parameters["@myValue"].Value = pValue;


      try {
        con.Open();
        myValue = (string)cmd.ExecuteScalar();
      } finally {
        con.Close();
      }
      return myValue;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="myImage"></param>
    /// <returns></returns>
    public int[,] PutAll(ImageEntity myImage) {
      if (fbDebugMode) {
        Console.WriteLine(oProcess.ProcessName + "==> " + "PutAll:");
        Logging.WriteLogSimple(oProcess.ProcessName + "==> " + "PutAll:");
        foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(myImage)) {
          string name = descriptor.Name;
          object value = descriptor.GetValue(myImage);
          Console.WriteLine("{0}={1}", name, value);
          Logging.WriteLogSimple(String.Format("{0}={1}", name, value));
        }
      }
      int[,] intArray = new int[,]{ {2000, 2000}};

      PositionCursor(intArray);
 
      // If ParentImage != null, we need to get the parent image and 
      // do everything that we normally to for an image 
      // to the parent image. If the parent image is found,
      // we need to continue on to get the child image.
      // If the child image is found, we have to adjust the
      // coordinates by adding the coordinates for the parent
      // to the child.

      bool boolImageFound = false;
      int intAttempts = 0;
      List<SubPositionInfo> ls = new List<SubPositionInfo>();
      boolUseGrayScaleDB = myImage.UseGrayScale;
      while (boolImageFound == false && intAttempts < myImage.Attempts) {
        ls = Click_PNG(myImage, boolUseGrayScaleDB);
        if (ls.Count > 0) {
          boolImageFound = true;
        }
        intAttempts += 1;
       // boolUseGrayScaleDB = false; //!boolUseGrayScaleDB;
      }
      int intRowIndex = 0;
      int[,] myArray = new int[0, 0];
      List<SubPositionInfo> SortedList = ls.OrderByDescending(o => o.percentcorrect).ToList();
      foreach (var myRow in SortedList) {
        int[] NewSizes = new int[] { intRowIndex + 1, 2 };
        if (myRow.percentcorrect < myImage.Tolerance) {
          break;
        }
        myArray = (int[,])myArray.ResizeArray(NewSizes);
        myArray[intRowIndex, 0] = myRow.myPoint.X;
        myArray[intRowIndex, 1] = myRow.myPoint.Y;
        //myListObject[2] = myRow.percentcorrect;
        //   myListListObject.Add(myListObject);
        intRowIndex++;

      }
      return myArray;
    }
    public int[,] PutCursorPosition() {
      if (fbDebugMode) {
        Console.WriteLine(oProcess.ProcessName + "==> " + "PutCursorPosition");
        Logging.WriteLogSimple(oProcess.ProcessName + "==> " + "PutCursorPosition");
      }
      int[,] myArray = new int[1, 2];
      myArray[0, 0] = System.Windows.Forms.Cursor.Position.X;
      myArray[0, 1] = System.Windows.Forms.Cursor.Position.Y;
      return myArray;
    }
    public int[,] PutCaretPositionInArray() {
      if (fbDebugMode) {
        Console.WriteLine(oProcess.ProcessName + "==> " + "PutCaretPositionInArray");
        Logging.WriteLogSimple(oProcess.ProcessName + "==> " + "PutCaretPositionInArray");
      }
      int[,] myArray = new int[1, 2];
      string activeProcess = GetActiveProcess();
      if (activeProcess == string.Empty) {
        Logging.WriteLogSimple("No active window found");
        MessageBox.Show("No active window found");
      }

      // If window explorer is active window (eg. user has opened any drive)
      // Or for any failure when activeProcess is nothing               

      // Otherwise Calculate Caret position
      EvaluateCaretPosition();

      myArray[0, 0] = caretPosition.X;
      myArray[0, 1] = caretPosition.Y;
      return myArray;


    }
    public void ClickImageIfExists(ImageEntity myImage) {
      if (fbDebugMode) {
        Console.WriteLine(oProcess.ProcessName + "==> " + "ClickImageIfExists:");
        Logging.WriteLogSimple(oProcess.ProcessName + "==> " + "ClickImageIfExists:");
        foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(myImage)) {
          string name = descriptor.Name;
          object value = descriptor.GetValue(myImage);
          Console.WriteLine("{0}={1}", name, value);
          Logging.WriteLogSimple(String.Format("{0}={1}", name, value));
        }
      }
      int[,] intArray = new int[,] { { 2000, 2000 } };

      PositionCursor(intArray);

      // If ParentImage != null, we need to get the parent image and 
      // do everything that we normally to for an image 
      // to the parent image. If the parent image is found,
      // we need to continue on to get the child image.
      // If the child image is found, we have to adjust the
      // coordinates by adding the coordinates for the parent
      // to the child.

      bool boolImageFound = false;
      int intAttempts = 0;
      List<SubPositionInfo> ls = new List<SubPositionInfo>();
      while (boolImageFound == false && intAttempts < myImage.Attempts) {
        ls = Click_PNG(myImage, boolUseGrayScaleDB);
        if (ls.Count > 0) {
          List<SubPositionInfo> SortedList = ls.OrderByDescending(o => o.percentcorrect).ToList();
          boolImageFound = true;
          System.Drawing.Point p = SortedList[0].myPoint;
          Position_Cursor.MoveMouse(p.X, p.Y);
          UInt32 myX = Convert.ToUInt32(p.X);
          UInt32 myY = Convert.ToUInt32(p.Y);
          Position_Cursor.DoMouseClick(myX, myY);
          break;
        }
        intAttempts += 1;
      //  boolUseGrayScaleDB = false; // !boolUseGrayScaleDB;
      }
    }

    public void LeftClick(int[,] myArray) {
      if (fbDebugMode) {
        Console.WriteLine(oProcess.ProcessName + "==> " + "LeftClick:");
        Logging.WriteLogSimple(oProcess.ProcessName + "==> " + "LeftClick:");
        int bound0 = myArray.GetUpperBound(0);
        int bound1 = myArray.GetUpperBound(1);
        // ... Loop over bounds.
        for (int i = 0; i <= bound0; i++) {
          for (int x = 0; x <= bound1; x++) {
            // Display the element at these indexes.
            Console.WriteLine(myArray[i, x].ToString());
            Logging.WriteLogSimple(myArray[i, x].ToString());
          }
          Console.WriteLine();
          Logging.WriteLogSimple("");
        }
      }
      int RelX = myArray[0, 0];
      int RelY = myArray[0, 1];
      Position_Cursor.MoveMouse(RelX, RelY);
      UInt32 myX1 = Convert.ToUInt32(RelX);
      UInt32 myY1 = Convert.ToUInt32(RelY);
      Position_Cursor.DoMouseClick(myX1, myY1);
    }
    public void ShiftClick(int[,] myArray) {
      if (fbDebugMode) {
        Console.WriteLine(oProcess.ProcessName + "==> " + "ShiftClick:");
        Logging.WriteLogSimple(oProcess.ProcessName + "==> " + "ShiftClick:");
        int bound0 = myArray.GetUpperBound(0);
        int bound1 = myArray.GetUpperBound(1);
        // ... Loop over bounds.
        for (int i = 0; i <= bound0; i++) {
          for (int x = 0; x <= bound1; x++) {
            // Display the element at these indexes.
            Console.WriteLine(myArray[i, x].ToString());
            Logging.WriteLogSimple(myArray[i, x].ToString());
          }
          Console.WriteLine();
          Logging.WriteLogSimple(" ");
        }
      }
      int RelX = myArray[0, 0];
      int RelY = myArray[0, 1];
      Position_Cursor.MoveMouse(RelX, RelY);
      UInt32 myX1 = Convert.ToUInt32(RelX);
      UInt32 myY1 = Convert.ToUInt32(RelY);
      Position_Cursor.DoMouseShiftClick(myX1, myY1);
    }
    public void RightClick(int[,] myArray) {
      if (fbDebugMode) {
        Console.WriteLine(oProcess.ProcessName + "==> " + "RightClick:");
        Logging.WriteLogSimple(oProcess.ProcessName + "==> " + "RightClick:");
        int bound0 = myArray.GetUpperBound(0);
        int bound1 = myArray.GetUpperBound(1);
        // ... Loop over bounds.
        for (int i = 0; i <= bound0; i++) {
          for (int x = 0; x <= bound1; x++) {
            // Display the element at these indexes.
            Console.WriteLine(myArray[i, x].ToString());
            Logging.WriteLogSimple(myArray[i, x].ToString());
          }
          Console.WriteLine();
          Logging.WriteLogSimple(" ");
        }
      }
      int RelX = myArray[0, 0];
      int RelY = myArray[0, 1];
      Position_Cursor.MoveMouse(RelX, RelY);
      UInt32 myX1 = Convert.ToUInt32(RelX);
      UInt32 myY1 = Convert.ToUInt32(RelY);
      Position_Cursor.DoMouseRightClick(myX1, myY1);
    }
    public void PositionCursor(int[,] myArray) {
      if (fbDebugMode) {
        Console.WriteLine(oProcess.ProcessName + "==> " + "PositionCursor:");
        Logging.WriteLogSimple(oProcess.ProcessName + "==> " + "PositionCursor:");
        int bound0 = myArray.GetUpperBound(0);
        int bound1 = myArray.GetUpperBound(1);
        // ... Loop over bounds.
        for (int i = 0; i <= bound0; i++) {
          for (int x = 0; x <= bound1; x++) {
            // Display the element at these indexes.
            Console.WriteLine(myArray[i, x].ToString());
            Logging.WriteLogSimple(myArray[i, x].ToString());
          }
          Console.WriteLine();
          Logging.WriteLogSimple(" ");
        }
      }
      Position_Cursor.MoveMouse(myArray[0, 0], myArray[0, 1]);
    }
    public string PutClipboardInEntity() {
      if (fbDebugMode) {
        Console.WriteLine(oProcess.ProcessName + "==> " + "PutClipboardInEntity: ");
        Logging.WriteLogSimple(oProcess.ProcessName + "==> " + "PutClipboardInEntity: ");
      }
      int intTryAgainCtr = 0;
      TryAgain:
      string myEntity = "";
      try {
        //Thread thread = new Thread(new ThreadStart(() => {
          try {

            for (int i = 0; i < 45; i++) {
              if (Clipboard.GetData(DataFormats.Text) == null) {
                Sleep(100);
              } else {
                break;
              }
              if (i == 10 || i == 20 || i == 30 || i == 40) {
                TypeText("^(c)",500);
                Sleep(1001);
               // System.Diagnostics.Debugger.Break();
              }
            }

            myEntity = Clipboard.GetData(DataFormats.Text).ToString();
            if (myEntity.Contains("Failed to copy selection to the clipboard")) {
              TypeText("^(c)", 500);
              Sleep(1002);
              intTryAgainCtr++;
              if (intTryAgainCtr < 10) {
                goto TryAgain;
              }
              
            }
           // myEntity = Clipboard.GetText(System.Windows.TextDataFormat.Html);
          } catch (Exception e) {
            Console.WriteLine("Exception occurred in PutClipboardInEntity!!!! " + e.Message);
            Logging.WriteLogSimple("Exception occurred in PutClipboardInEntity!!!! " + e.Message);
            myEntity = "";
          }

          // or call logic here



        //}));

        //thread.SetApartmentState(ApartmentState.STA);

        //thread.Start();
        //thread.Join();
      } catch (Exception ex) {
        try {
          TypeText("^(c)", 500);
          //Thread thread = new Thread(new ThreadStart(() => {
            try {

              for (int i = 0; i < 45; i++) {
                if (Clipboard.GetData(DataFormats.Text) == null) {
                  Sleep(100);
                } else {
                  break;
                }
                if (i == 10 || i == 20 || i == 30 || i == 40) {
                  TypeText("^(c)", 500);
                  Sleep(1003);
                }
              }

              myEntity = Clipboard.GetData(DataFormats.Text).ToString();
              // myEntity = Clipboard.GetText(System.Windows.TextDataFormat.Html);
            } catch (Exception e) {
              Console.WriteLine("Exception occurred in PutClipboardInEntity!!!! " + e.Message);
              Logging.WriteLogSimple("Exception occurred in PutClipboardInEntity!!!! " + e.Message);
              myEntity = "";
            }

            // or call logic here



          //}));

          //thread.SetApartmentState(ApartmentState.STA);

          //thread.Start();
          //thread.Join();
        } catch (Exception ex1) {
          MessageBox.Show(ex1.Message);
        }
      }
      if (myEntity.Length > 5000) {
        Console.Write("PutEntityInClipboard: myEntity more than 5000 in length");
        Logging.WriteLogSimple("PutEntityInClipboard: myEntity more than 5000 in length");
      } else {
        Console.Write("myEntity=" + myEntity);
        Logging.WriteLogSimple("myEntity=" + myEntity);
      }
      return myEntity;
    }
    public string PutWindowTitleInEntity() {
      if (fbDebugMode) {
        Console.WriteLine(oProcess.ProcessName + "==> " + "PutWindowTitleInEntity");
        Logging.WriteLogSimple(oProcess.ProcessName + "==> " + "PutWindowTitleInEntity");
      }
      string myEntity = "";
      try {
        myEntity = GetActiveProcessTitle();
        // or call logic here
      } catch (Exception ex) {

        MessageBox.Show(ex.Message);
      }
      return myEntity;
    }
    public string PutInternetExplorerTabTitleInEntity() {
      if (fbDebugMode) {
        Console.WriteLine(oProcess.ProcessName + "==> " + "PutInternetExplorerTabTitleInEntity");
        Logging.WriteLogSimple(oProcess.ProcessName + "==> " + "PutInternetExplorerTabTitleInEntity");
      }
   
      TypeText("{UP}", 1000);
      TypeText("%(v)", 1000);
      TypeText("c", 1000);

      string strPageTitle = PutWindowTitleInEntity();
      strPageTitle = strPageTitle.Replace(" - Original Source", "");
      CloseApplicationAltFc(500);
      return strPageTitle;
    
    }
    public string PutInternetExplorerTabURLContainingStringInEntity(string myEntity) {
      if (fbDebugMode) {
        Console.WriteLine(oProcess.ProcessName + "==> " + "PutInternetExplorerTabURLContainingStringInEntity: myEntity=" + myEntity);
        Logging.WriteLogSimple(oProcess.ProcessName + "==> " + "PutInternetExplorerTabURLContainingStringInEntity: myEntity=" + myEntity);
      }

      List<string> myWindowTitles = GetWindowTitlesByProcessName("iexplore");
      myWindowTitles.RemoveAll(item => item == "");

      string strCurrentTabURL = "";
      bool boolTargetURLFound = false;
      bool boolInternetExplorerFound = false;
      foreach (var myWindowTitle in myWindowTitles) {
        boolInternetExplorerFound = true;
        if (myWindowTitle != "") {
          ActivateWindowByTitle(myWindowTitle);
          // go to last tab;
          // myActions.TypeText("^(9)",2500);
          Sleep(500);
          TypeText("%(d)", 500); // select address bar
          string strFirstTabURL = SelectAllCopyIntoEntity(500);
          TypeText("{ESC}", 500);
          if (strFirstTabURL.ToLower().Contains(myEntity)) {
            strCurrentTabURL = strFirstTabURL;
            boolTargetURLFound = true;
            break;
          }
          
          // go to next tab
          while (strCurrentTabURL != strFirstTabURL) {
            TypeText("^({TAB})", 2500);
            TypeText("%(d)", 500); // select address bar
            strCurrentTabURL = SelectAllCopyIntoEntity(500);
            TypeText("{ESC}", 500);
            if (strCurrentTabURL.ToLower().Contains(myEntity)) {
              boolTargetURLFound = true;
              break;
            }
          }
          if (boolTargetURLFound) {

            break;
          }

        }
      }
      if (boolInternetExplorerFound == false) {
        strCurrentTabURL = "IE not found";
        return strCurrentTabURL;
      }
      if (boolTargetURLFound == false) {
        return "";
      }
      return strCurrentTabURL;

    }


    public void PutEntityInClipboard(string myEntity) {
      if (fbDebugMode) {
        if (myEntity.Length > 5000) {
          Console.WriteLine("PutEntityInClipboard: myEntity more than 5000 in length");
          Logging.WriteLogSimple("PutEntityInClipboard: myEntity more than 5000 in length");
        } else {
          Console.WriteLine("PutEntityInClipboard: myEntity=" + myEntity);
          Logging.WriteLogSimple("PutEntityInClipboard: myEntity=" + myEntity);
        }
      }
      try {
        
        Thread thread = new Thread(new ThreadStart(() => {
          Clipboard.Clear();          
         // Clipboard.SetText(myEntity);
          Clipboard.SetDataObject((Object)myEntity, true);
          // or call logic here



        }));

        thread.SetApartmentState(ApartmentState.STA);

        thread.Start();
        thread.Join();
      } catch (Exception ex) {
        MessageBox.Show(ex.Message);
      }
    }
    public void TypeText(string myEntity, int intSleep) {
      if (fbDebugMode) {
        Console.WriteLine(oProcess.ProcessName + "==> " + "TypeText: myEntity=" + myEntity + " intSleep=" + intSleep.ToString());
        Logging.WriteLogSimple(oProcess.ProcessName + "==> " + "TypeText: myEntity=" + myEntity + " intSleep=" + intSleep.ToString());
      }
      InputSimulator InputSimulator = new InputSimulator();
      //if (myEntity == "{LWin}") {
      //  KeyboardSend.KeyDown(System.Windows.Forms.Keys.ControlKey);
      //  KeyboardSend.KeyDown(System.Windows.Forms.Keys.Alt);
      //  KeyboardSend.KeyDown(System.Windows.Forms.Keys.L);
      //  KeyboardSend.KeyUp(System.Windows.Forms.Keys.L);
      //  KeyboardSend.KeyUp(System.Windows.Forms.Keys.Alt);
      //  KeyboardSend.KeyUp(System.Windows.Forms.Keys.ControlKey);
      //}
      if (intSleep > 0) {
        System.Threading.Thread.Sleep(intSleep);
      }
      //          public void SimulateSomeModifiedKeystrokes()
      //{
      //  // CTRL-C (effectively a copy command in many situations)
      //  InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_C);

      //  // You can simulate chords with multiple modifiers
      //  // For example CTRL-K-C whic is simulated as
      //  // CTRL-down, K, C, CTRL-up
      //  InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.CONTROL, new [] {VirtualKeyCode.VK_K, VirtualKeyCode.VK_C});

      //  // You can simulate complex chords with multiple modifiers and key presses
      //  // For example CTRL-ALT-SHIFT-ESC-K which is simulated as
      //  // CTRL-down, ALT-down, SHIFT-down, press ESC, press K, SHIFT-up, ALT-up, CTRL-up
      //  InputSimulator.SimulateModifiedKeyStroke(
      //    new[] { VirtualKeyCode.CONTROL, VirtualKeyCode.MENU, VirtualKeyCode.SHIFT },
      //    new[] { VirtualKeyCode.ESCAPE, VirtualKeyCode.VK_K });
      //}
      if (myEntity == "%(f)e") {
        InputSimulator.Keyboard.ModifiedKeyStroke(VirtualKeyCode.MENU, VirtualKeyCode.VK_F); //System.Windows.Forms.Keys.Alt);
        InputSimulator.Keyboard.KeyPress(VirtualKeyCode.VK_E);
        return;
      }
      if (myEntity == "%(\" \")n") {
        InputSimulator.Keyboard.ModifiedKeyStroke(VirtualKeyCode.MENU, VirtualKeyCode.SPACE); //System.Windows.Forms.Keys.Alt);
        InputSimulator.Keyboard.KeyPress(VirtualKeyCode.VK_N);
        return;
      }
      if (myEntity == "%(\" \")") {
        InputSimulator.Keyboard.ModifiedKeyStroke(VirtualKeyCode.MENU, VirtualKeyCode.SPACE); //System.Windows.Forms.Keys.Alt);              
        return;
      }
      if (myEntity == "%(\" \")x") {
        InputSimulator.Keyboard.ModifiedKeyStroke(VirtualKeyCode.MENU, VirtualKeyCode.SPACE); //System.Windows.Forms.Keys.Alt);
        InputSimulator.Keyboard.KeyPress(VirtualKeyCode.VK_X);
        return;
      }
      if (myEntity == "%({DOWN})") {
        InputSimulator.Keyboard.ModifiedKeyStroke(VirtualKeyCode.MENU, VirtualKeyCode.DOWN); //System.Windows.Forms.Keys.Alt);
       
        return;
      }
      if (myEntity == "%({F8})") {
        InputSimulator.Keyboard.ModifiedKeyStroke(VirtualKeyCode.MENU, VirtualKeyCode.F8); //System.Windows.Forms.Keys.Alt);
        return;
      }
      if (myEntity == "{NUMPADADD}") {
        InputSimulator.Keyboard.KeyPress(VirtualKeyCode.ADD);
        return;
      }
      if (myEntity == "{NUMPADMULT}") {
        InputSimulator.Keyboard.KeyPress(VirtualKeyCode.MULTIPLY);
        return;
      }
      if (myEntity == "{ENTER}") {
        InputSimulator.Keyboard.KeyPress(VirtualKeyCode.RETURN);
        return;
      }
      if (myEntity == "^(n)") {
        InputSimulator.Keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_N);
        return;
      }
      if (myEntity == "^(v)") {
        InputSimulator.Keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_V);
        return;
      }
      if (myEntity == "^(c)") {
        try {

          Thread thread = new Thread(new ThreadStart(() => {
            Clipboard.Clear();           
            // Clipboard.SetText(myEntity);            
            // or call logic here



          }));

          thread.SetApartmentState(ApartmentState.STA);

          thread.Start();
          thread.Join();
        } catch (Exception ex) {
          MessageBox.Show(ex.Message);
        }
        InputSimulator.Keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_C);
        return;
      }
      if (myEntity == "{F5}") {
        InputSimulator.Keyboard.KeyPress(VirtualKeyCode.F5);
        return;
      }
      if (myEntity == "{F6}") {
        InputSimulator.Keyboard.KeyPress(VirtualKeyCode.F6);
        return;
      }
      if (myEntity == "{DOWN}") {
        InputSimulator.Keyboard.KeyPress(VirtualKeyCode.DOWN);
        return;
      }
      if (myEntity == "{UP}") {
        InputSimulator.Keyboard.KeyPress(VirtualKeyCode.UP);
        return;
      }
      if (myEntity == "^({END})") {
        InputSimulator.Keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.END);
        return;
      }
      if (myEntity == "^({HOME})") {
        InputSimulator.Keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.HOME);
        return;
      }
      if (myEntity == "+({F10})") {
        InputSimulator.Keyboard.ModifiedKeyStroke(VirtualKeyCode.SHIFT, VirtualKeyCode.F10);
        return;
      }
      if (myEntity == "{LWin}") {
        KeyboardSend.KeyDown(System.Windows.Forms.Keys.LWin);
        KeyboardSend.KeyDown(System.Windows.Forms.Keys.Shift);
        KeyboardSend.KeyDown(System.Windows.Forms.Keys.Right);
        KeyboardSend.KeyUp(System.Windows.Forms.Keys.LWin);
        KeyboardSend.KeyUp(System.Windows.Forms.Keys.D4);
        KeyboardSend.KeyUp(System.Windows.Forms.Keys.Right);
      } else {

        System.Windows.Forms.SendKeys.SendWait(myEntity);
      }
    }

   public void CloseApplicationAltFx(int intSleep) {
      if (fbDebugMode) {
        Console.WriteLine(oProcess.ProcessName + "==> " + "CloseInternetExplorer: intSleep=" + intSleep.ToString());
        Logging.WriteLogSimple(oProcess.ProcessName + "==> " + "CloseInternetExplorer: intSleep=" + intSleep.ToString());
      }
      InputSimulator InputSimulator = new InputSimulator();
      if (intSleep > 0) {
        System.Threading.Thread.Sleep(intSleep);
      }
       InputSimulator.Keyboard.ModifiedKeyStroke(VirtualKeyCode.MENU, VirtualKeyCode.VK_F); //System.Windows.Forms.Keys.Alt);
      System.Threading.Thread.Sleep(200);
      InputSimulator.Keyboard.KeyPress(VirtualKeyCode.VK_X);
    }
   public void CloseApplicationAltFc(int intSleep) {
     if (fbDebugMode) {
       Console.WriteLine(oProcess.ProcessName + "==> " + "CloseInternetExplorer: intSleep=" + intSleep.ToString());
       Logging.WriteLogSimple(oProcess.ProcessName + "==> " + "CloseInternetExplorer: intSleep=" + intSleep.ToString());
     }
     InputSimulator InputSimulator = new InputSimulator();
     if (intSleep > 0) {
       System.Threading.Thread.Sleep(intSleep);
     }
     InputSimulator.Keyboard.ModifiedKeyStroke(VirtualKeyCode.MENU, VirtualKeyCode.VK_F); //System.Windows.Forms.Keys.Alt);
     System.Threading.Thread.Sleep(200);
     InputSimulator.Keyboard.KeyPress(VirtualKeyCode.VK_C);
   }
    public void SelectAllCopy(int intSleep) {
      if (fbDebugMode) {
        Console.WriteLine(oProcess.ProcessName + "==> " + "SelectAllCopy: intSleep=" + intSleep.ToString());
        Logging.WriteLogSimple(oProcess.ProcessName + "==> " + "SelectAllCopy: intSleep=" + intSleep.ToString());
      }
      InputSimulator InputSimulator = new InputSimulator();
      if (intSleep > 0) {
        System.Threading.Thread.Sleep(intSleep);
      }
      InputSimulator.Keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_A);
      System.Threading.Thread.Sleep(200);
      InputSimulator.Keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_C);
    }
    public string SelectAllCopyIntoEntity(int intSleep) {
      if (fbDebugMode) {
        Console.WriteLine(oProcess.ProcessName + "==> " + "SelectAllCopy: intSleep=" + intSleep.ToString());
        Logging.WriteLogSimple(oProcess.ProcessName + "==> " + "SelectAllCopy: intSleep=" + intSleep.ToString());
      }
      InputSimulator InputSimulator = new InputSimulator();
      if (intSleep > 0) {
        System.Threading.Thread.Sleep(intSleep);
      }
      InputSimulator.Keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_A);
      System.Threading.Thread.Sleep(200);
      InputSimulator.Keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_C);
      return PutClipboardInEntity();
    }
    public void SelectAllPaste(int intSleep) {
      if (fbDebugMode) {
        Console.WriteLine(oProcess.ProcessName + "==> " + "SelectAllPaste: intSleep=" + intSleep.ToString());
        Logging.WriteLogSimple(oProcess.ProcessName + "==> " + "SelectAllPaste: intSleep=" + intSleep.ToString());
      }
      InputSimulator InputSimulator = new InputSimulator();
      if (intSleep > 0) {
        System.Threading.Thread.Sleep(intSleep);
      }
      InputSimulator.Keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_A);
      System.Threading.Thread.Sleep(200);
      if (intSleep > 0) {
        System.Threading.Thread.Sleep(intSleep);
      }
      InputSimulator.Keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_V);
    }
    public void SelectAllPasteFromEntity(string myEntity, int intSleep) {
      PutEntityInClipboard(myEntity);
      if (fbDebugMode) {
        Console.WriteLine(oProcess.ProcessName + "==> " + "SelectAllPaste: intSleep=" + intSleep.ToString());
        Logging.WriteLogSimple(oProcess.ProcessName + "==> " + "SelectAllPaste: intSleep=" + intSleep.ToString());
      }
      InputSimulator InputSimulator = new InputSimulator();
      if (intSleep > 0) {
        System.Threading.Thread.Sleep(intSleep);
      }
      InputSimulator.Keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_A);
      System.Threading.Thread.Sleep(200);
      InputSimulator.Keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_V);
    }
    public void SelectAllDelete(int intSleep) {
      if (fbDebugMode) {
        Console.WriteLine(oProcess.ProcessName + "==> " + "SelectAllDelete: intSleep=" + intSleep.ToString());
        Logging.WriteLogSimple(oProcess.ProcessName + "==> " + "SelectAllDelete: intSleep=" + intSleep.ToString());
      }
      InputSimulator InputSimulator = new InputSimulator();
      if (intSleep > 0) {
        System.Threading.Thread.Sleep(intSleep);
      }
      InputSimulator.Keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_A);
      System.Threading.Thread.Sleep(200);
      InputSimulator.Keyboard.KeyPress(VirtualKeyCode.DELETE);
    }
    public void WindowMultipleControls(ref List<ControlEntity> myListControlEntity, int intWindowHeight, int intWindowWidth) {
      if (fbDebugMode) {
        Console.WriteLine(oProcess.ProcessName + "==> " + "WindowMultipleControls");
        Logging.WriteLogSimple(oProcess.ProcessName + "==> " + "WindowMultipleControls");
      }
      WindowMultipleControls dlg = new WindowMultipleControls(ref myListControlEntity, intWindowHeight, intWindowWidth);

      // dlg.Owner = (Window)Window.GetWindow(this);
      // Shadow.Visibility = Visibility.Visible;
      dlg.ShowDialog();
      
    }
    public ComboBoxPair WindowComboBox(IEnumerable<object> myEntity, string myEntity2) {
      if (fbDebugMode) {
        Console.WriteLine(oProcess.ProcessName + "==> " + "WindowComboBox: myEntity=" + myEntity);
        Logging.WriteLogSimple(oProcess.ProcessName + "==> " + "WindowComboBox: myEntity=" + myEntity);
      }
      WindowComboBox dlg = new WindowComboBox(myEntity, myEntity2);
    
     // dlg.Owner = (Window)Window.GetWindow(this);
      // Shadow.Visibility = Visibility.Visible;
      dlg.ShowDialog();
      return dlg.SelectedComboBoxPair;
    }
    public string WindowTextBox(string myEntity) {
      if (fbDebugMode) {
        Console.WriteLine(oProcess.ProcessName + "==> " + "WindowTextBox: myEntity=" + myEntity);
        Logging.WriteLogSimple(oProcess.ProcessName + "==> " + "WindowTextBox: myEntity=" + myEntity);
      }
      WindowTextBox dlg = new WindowTextBox(myEntity);

      // dlg.Owner = (Window)Window.GetWindow(this);
      // Shadow.Visibility = Visibility.Visible;
      dlg.ShowDialog();
      return dlg.TextBoxValue;
    }
    public void WindowShape(string myShape, string myOrientation,string myTitle, string myContent, int intTop, int intLeft) {
      if (fbDebugMode) {
        Console.WriteLine(oProcess.ProcessName + "==> " + "WindowShape: myEntity=" + myTitle);
        Logging.WriteLogSimple(oProcess.ProcessName + "==> " + "WindowShape: myEntity=" + myTitle);
      }
      WindowShape dlg = new WindowShape(myShape,myOrientation, myTitle, myContent, intTop, intLeft);

      // dlg.Owner = (Window)Window.GetWindow(this);
      // Shadow.Visibility = Visibility.Visible;
      dlg.ShowDialog();
      return;
    }
    public void MessageBoxShow(string myEntity) {
      if (fbDebugMode) {
        Console.WriteLine(oProcess.ProcessName + "==> " + "MessageBoxShow: myEntity=" + myEntity);
        Logging.WriteLogSimple(oProcess.ProcessName + "==> " + "MessageBoxShow: myEntity=" + myEntity);
      }
      System.Windows.Forms.MessageBox.Show(myEntity, "Header", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.None,
    System.Windows.Forms.MessageBoxDefaultButton.Button1, (System.Windows.Forms.MessageBoxOptions)0x40000);  // MB_TOPMOST
    }
    public System.Windows.Forms.DialogResult MessageBoxShowWithYesNo(string myEntity) {
      if (fbDebugMode) {
        Console.WriteLine(oProcess.ProcessName + "==> " + "MessageBoxShow: myEntity=" + myEntity);
        Logging.WriteLogSimple(oProcess.ProcessName + "==> " + "MessageBoxShow: myEntity=" + myEntity);
      }
      System.Windows.Forms.DialogResult _dialogResult =
      System.Windows.Forms.MessageBox.Show(myEntity, "Header", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.None,
    System.Windows.Forms.MessageBoxDefaultButton.Button1, (System.Windows.Forms.MessageBoxOptions)0x40000);  // MB_TOPMOST
      return _dialogResult;
    }
    public void Run(string myEntityForExecutable, string myEntityForContent) {
      if (fbDebugMode) {
        Console.WriteLine(oProcess.ProcessName + "==> " + "Run: myEntityForExecutable=" + myEntityForExecutable + " myEntityForContent=" + myEntityForContent);
        Logging.WriteLogSimple(oProcess.ProcessName + "==> " + "Run: myEntityForExecutable=" + myEntityForExecutable + " myEntityForContent=" + myEntityForContent);
      }

      if (myEntityForExecutable == null) {
        string message = "Error - You need to specify executable primitive  "; // +"; EntityName is: " + myEntityForExecutable.EntityName;
        Logging.WriteLogSimple("Error - You need to specify executable primitive  ");
        MessageBoxResult result = MessageBox.Show(message, "Run-time Error", MessageBoxButton.OK, MessageBoxImage.Error);
        return;
      }
      string strExecutable = myEntityForExecutable;

      string strContent = "";
      if (myEntityForContent != null) {
        strContent = myEntityForContent;
      }
      if (strContent == "") {
        Process.Start(strExecutable);
      } else {
        try {
          Process.Start(strExecutable, string.Concat("", strContent, ""));
        } catch (Exception ex) {

          MessageBox.Show(ex.ToString());
        }
      }
    }
    public void RunSync(string myEntityForExecutable, string myEntityForContent) {
      if (fbDebugMode) {
        Console.WriteLine(oProcess.ProcessName + "==> " + "RunSync: myEntityForExecutable=" + myEntityForExecutable + " myEntityForContent=" + myEntityForContent);
        Logging.WriteLogSimple(oProcess.ProcessName + "==> " + "RunSync: myEntityForExecutable=" + myEntityForExecutable + " myEntityForContent=" + myEntityForContent);
      }

      if (myEntityForExecutable == null) {
        string message = "Error - You need to specify executable primitive  "; // +"; EntityName is: " + myEntityForExecutable.EntityName;
        MessageBoxResult result = MessageBox.Show(message, "Run-time Error", MessageBoxButton.OK, MessageBoxImage.Error);
        return;
      }
      string strExecutable = myEntityForExecutable;

      string strContent = "";
      if (myEntityForContent != null) {
        strContent = myEntityForContent;
      }
      var p = new Process();
      p.StartInfo.FileName = strExecutable;
      if (strContent != "") {
        p.StartInfo.Arguments = string.Concat("", strContent, "");
      }
      bool started = true;
      p.Start();
      int procId = 0;
      try {
        procId = p.Id;
        Console.WriteLine("ID: " + procId);
        Logging.WriteLogSimple("ID: " + procId);
      } catch (InvalidOperationException) {
        started = false;
      } catch (Exception ex) {
        started = false;
      }
      while (started == true && GetProcByID(procId) != null) {
        System.Threading.Thread.Sleep(1000);
      }
    
    }
    private Process GetProcByID(int id) {
      Process[] processlist = Process.GetProcesses();
      return processlist.FirstOrDefault(pr => pr.Id == id);
    }
    public void Sleep(int intSleep) {
      if (fbDebugMode) {
        Console.WriteLine(oProcess.ProcessName + "==> " + "Sleep:  intSleep=" + intSleep.ToString());
        Logging.WriteLogSimple(oProcess.ProcessName + "==> " + "Sleep:  intSleep=" + intSleep.ToString());
      }
      System.Threading.Thread.Sleep(intSleep);
    }

  

    private List<SubPositionInfo> Click_PNG(ImageEntity myImage, bool boolUseGrayScaleDB) {
      if (fbDebugMode) {
        Console.WriteLine(oProcess.ProcessName + "==> " + "Click_PNG:");
        Logging.WriteLogSimple(oProcess.ProcessName + "==> " + "Click_PNG:");
        foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(myImage)) {
          string name = descriptor.Name;
          object value = descriptor.GetValue(myImage);
          Console.WriteLine("{0}={1}", name, value);
          Logging.WriteLogSimple(String.Format("{0}={1}", name, value));
        }
      }
      System.Threading.Thread.Sleep(100);


      //Bitmap bm = BytesToBitmap(myEntityForPicture.ImageFile);
      string directory = AppDomain.CurrentDomain.BaseDirectory;
      Bitmap bm = new Bitmap(directory + myImage.ImageFile);
      // Bitmap bm = new Bitmap(directory + pPNG_File_Name);
      //  Bitmap bm = BytesToBitmap(scriptStep.SubImage);
      // Bitmap bm = null;
      //     bm.MakeTransparent(Color.White);


      // previewImageBox.Source = BitmapSourceFromImage(bm);
      //bm;
      // find the least popular color in sub image and find the relative position in
      // subimage
      if (boolUseGrayScaleDB) {
        intFileCtr += 1;
        string myfile = "temp" + intFileCtr + ".bmp";
        System.IO.File.Delete(directory + myfile);
        bm.Save(directory + myfile, System.Drawing.Imaging.ImageFormat.Bmp);
        System.Drawing.Image myImageD = System.Drawing.Image.FromFile(directory + myfile);
        // myImage = System.Drawing.Image.FromFile(@"C:\TFS\WadeHome\Applications\TreeView\Sample Application\Images\Small.png");

        myImageD = Scraper.ConvertToGrayscale(myImageD);
        bm = new Bitmap(myImageD);
        intFileCtr += 1;
        myfile = "temp" + intFileCtr + ".bmp";
        System.IO.File.Delete(directory + myfile);
        bm.Save(directory + myfile, System.Drawing.Imaging.ImageFormat.Bmp);

        myImageD.Dispose();
      }
      Hashtable pixels = new Hashtable(); // looks like this is no longer used and can be deleted

      //resultsTextBox.Text += "Searching..." + scriptStep.Seq1.ToString() + Environment.NewLine;
      Console.WriteLine(oProcess.ProcessName + "==> " + "Searching..." + myImage.ImageFile + Environment.NewLine);
      Logging.WriteLogSimple(oProcess.ProcessName + "==> " + "Searching..." + myImage.ImageFile + Environment.NewLine);

    
      // Find subimages
      Bitmap bmx;

      bmx = Scraper.getDesktopBitmap(boolUseGrayScaleDB); //forcing both images to be the same Scraper.getDesktopBitmap(boolUseGrayScaleDB); // BytesToBitmap(myEntityForPicture.ImageFile); //forcing both images to be the same


      // bigPictureImageBox.Source = BitmapSourceFromImage(bmx);
      decimal highestPercentCorrect = 0;

      List<SubPositionInfo> ls = Scraper.GetSubPositions(bmx, bm, boolUseGrayScaleDB, ref highestPercentCorrect, myImage.Tolerance);
      // List<System.Drawing.Point> ls = null;
      int intLastSlashIndex = myImage.ImageFile.LastIndexOf("\\");
      string strfilename = myImage.ImageFile.Substring(intLastSlashIndex + 1);
      if (ls.Count > 0) {



        for (int i = 0; i < ls.Count; i++) {
          System.Drawing.Point p = ls[i].myPoint;

          string myfile = "tempsmall" + strfilename + i.ToString() + ".bmp";

          System.IO.File.Delete(directory + myfile);
          bm.Save(directory + myfile, System.Drawing.Imaging.ImageFormat.Bmp);
          myfile = "tempbig" + strfilename + i.ToString() + ".bmp";
          System.IO.File.Delete(directory + myfile);
          bmx.Save(directory + myfile, System.Drawing.Imaging.ImageFormat.Bmp);

          Console.WriteLine(oProcess.ProcessName + "==> " + "Image found at: " + p.ToString() + strfilename + i.ToString() + " highestPercentCorrect=" + ls[i].percentcorrect.ToString() + ";Search Method: " + ls[i].strSearchMethod + Environment.NewLine);
          Logging.WriteLogSimple(oProcess.ProcessName + "==> " + "Image found at: " + p.ToString() + strfilename + i.ToString() + " highestPercentCorrect=" + ls[i].percentcorrect.ToString() + ";Search Method: " + ls[i].strSearchMethod + Environment.NewLine);
          int intOffX = p.X + myImage.RelativeX;
          int intOffY = p.Y + myImage.RelativeY;


          p.X = intOffX;
          p.Y = intOffY;
          ls[i].myPoint = p;
          //Position_Cursor.MoveMouse(intOffX, intOffY);
          //UInt32 myX = Convert.ToUInt32(intOffX);
          //UInt32 myY = Convert.ToUInt32(intOffY);
          //Position_Cursor.DoMouseClick(myX, myY);
          //System.Threading.Thread.Sleep(1000);
          // System.Windows.Forms.SendKeys.SendWait("Wade is a nut");

        }

        return ls;
      } else {

        string myfile = "tempsmall" + strfilename + ".bmp";

        System.IO.File.Delete(directory + myfile);
        bm.Save(directory + myfile, System.Drawing.Imaging.ImageFormat.Bmp);
        myfile = "tempbig" + strfilename + ".bmp";
        System.IO.File.Delete(directory + myfile);
        bmx.Save(directory + myfile, System.Drawing.Imaging.ImageFormat.Bmp);

        myfile = "tempbig" + strfilename + ".bmp";

        Console.WriteLine(oProcess.ProcessName + "==> " + "Image not found" + strfilename + " highestPercentCorrect=" + highestPercentCorrect.ToString() + Environment.NewLine);
        Logging.WriteLogSimple(oProcess.ProcessName + "==> " + "Image not found" + strfilename + " highestPercentCorrect=" + highestPercentCorrect.ToString() + Environment.NewLine);
        return ls;
      }
    }

    /// <summary>
    /// Evaluates Cursor Position with respect to client screen.
    /// </summary>
    private void EvaluateCaretPosition() {

      caretPosition = new System.Drawing.Point();

      // Fetch GUITHREADINFO
      GetCaretPosition();

      caretPosition.X = (int)guiInfo.rcCaret.Left;
      caretPosition.Y = (int)guiInfo.rcCaret.Top;
      //       MessageBox.Show(caretPosition.X.ToString() + "," + caretPosition.Y.ToString());
      ClientToScreen(guiInfo.hwndCaret, out caretPosition);
      //        MessageBox.Show(caretPosition.X.ToString() + "," + caretPosition.Y.ToString());

      //txtCaretX.Text = (caretPosition.X).ToString();
      //txtCaretY.Text = caretPosition.Y.ToString();

    }

    /// <summary>
    /// Get the caret position
    /// </summary>
    private void GetCaretPosition() {
      if (fbDebugMode) {
        Console.WriteLine(oProcess.ProcessName + "==> " + "GetCaretPosition");
        Logging.WriteLogSimple(oProcess.ProcessName + "==> " + "GetCaretPosition");
      }
      guiInfo = new GUITHREADINFO();
      guiInfo.cbSize = (uint)Marshal.SizeOf(guiInfo);

      // Get GuiThreadInfo into guiInfo
      GetGUIThreadInfo(0, out guiInfo);
    }

    /// <summary>
    /// Retrieves name of active Process.
    /// </summary>
    /// <returns>Active Process Name</returns>
    private string GetActiveProcess() {
      const int nChars = 256;
      int handle = 0;
      StringBuilder Buff = new StringBuilder(nChars);
      handle = (int)GetForegroundWindow();

      // If Active window has some title info
      if (GetWindowText(handle, Buff, nChars) > 0) {
        uint lpdwProcessId;
        uint dwCaretID = GetWindowThreadProcessId(handle, out lpdwProcessId);
        uint dwCurrentID = (uint)Thread.CurrentThread.ManagedThreadId;
        return Process.GetProcessById((int)lpdwProcessId).ProcessName;
      }
      // Otherwise either error or non client region
      return String.Empty;
    }
    private string GetActiveProcessTitle() {
      const int nChars = 256;
      int handle = 0;
      StringBuilder Buff = new StringBuilder(nChars);
      handle = (int)GetForegroundWindow(); 
      // If Active window has some title info..
      if (GetWindowText(handle, Buff, nChars) > 0) {
        uint lpdwProcessId;
        uint dwCaretID = GetWindowThreadProcessId(handle, out lpdwProcessId);
        uint dwCurrentID = (uint)Thread.CurrentThread.ManagedThreadId;
        //   MessageBox.Show(Process.GetProcessById((int)lpdwProcessId).MainWindowTitle);
        return Process.GetProcessById((int)lpdwProcessId).MainWindowTitle;
      }
      // Otherwise either error or non client region
      return String.Empty;
    }

  }
}
