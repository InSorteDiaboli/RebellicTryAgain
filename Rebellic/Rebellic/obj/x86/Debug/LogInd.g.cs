﻿#pragma checksum "C:\Users\louis\source\repos\RebellicTryAgain\Rebellic\Rebellic\LogInd.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "C3BF43BD4304C0370ACCA991490B2494"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Rebellic
{
    partial class LogInd : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // LogInd.xaml line 22
                {
                    this.btnShowPaneBack = (global::Windows.UI.Xaml.Shapes.Rectangle)(target);
                    ((global::Windows.UI.Xaml.Shapes.Rectangle)this.btnShowPaneBack).Tapped += this.BtnShowPane_OnClick;
                }
                break;
            case 3: // LogInd.xaml line 23
                {
                    this.btnShowPane = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBlock)this.btnShowPane).Tapped += this.BtnShowPane_OnClick;
                    ((global::Windows.UI.Xaml.Controls.TextBlock)this.btnShowPane).PointerEntered += this.BtnShowPane_OnPointerEntered;
                    ((global::Windows.UI.Xaml.Controls.TextBlock)this.btnShowPane).PointerExited += this.BtnShowPane_OnPointerExited;
                }
                break;
            case 4: // LogInd.xaml line 24
                {
                    this.MenuPopup = (global::Windows.UI.Xaml.Controls.Primitives.Popup)(target);
                }
                break;
            case 5: // LogInd.xaml line 49
                {
                    this.LogIndGrid = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 6: // LogInd.xaml line 68
                {
                    this.OpretBrugerGrid = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 7: // LogInd.xaml line 95
                {
                    this.InfoPopupBackground = (global::Windows.UI.Xaml.Shapes.Rectangle)(target);
                    ((global::Windows.UI.Xaml.Shapes.Rectangle)this.InfoPopupBackground).PointerEntered += this.InfoPointerEnter;
                    ((global::Windows.UI.Xaml.Shapes.Rectangle)this.InfoPopupBackground).PointerExited += this.InfoPointerExit;
                }
                break;
            case 8: // LogInd.xaml line 96
                {
                    global::Windows.UI.Xaml.Controls.TextBlock element8 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBlock)element8).PointerEntered += this.InfoPointerEnter;
                    ((global::Windows.UI.Xaml.Controls.TextBlock)element8).PointerExited += this.InfoPointerExit;
                    ((global::Windows.UI.Xaml.Controls.TextBlock)element8).Tapped += this.InfoPopup_Tapped;
                }
                break;
            case 9: // LogInd.xaml line 97
                {
                    this.InfoPopup = (global::Windows.UI.Xaml.Controls.Primitives.Popup)(target);
                }
                break;
            case 10: // LogInd.xaml line 171
                {
                    global::Windows.UI.Xaml.Controls.Grid element10 = (global::Windows.UI.Xaml.Controls.Grid)(target);
                    ((global::Windows.UI.Xaml.Controls.Grid)element10).PointerEntered += this.ProfileOpener_OnPointerEntered;
                    ((global::Windows.UI.Xaml.Controls.Grid)element10).PointerExited += this.ProfileOpener_OnPointerExited;
                }
                break;
            case 11: // LogInd.xaml line 184
                {
                    this.myPopup = (global::Windows.UI.Xaml.Controls.Primitives.Popup)(target);
                }
                break;
            case 12: // LogInd.xaml line 190
                {
                    global::Windows.UI.Xaml.Controls.StackPanel element12 = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                    ((global::Windows.UI.Xaml.Controls.StackPanel)element12).PointerEntered += this.ChangeCursorEnter;
                    ((global::Windows.UI.Xaml.Controls.StackPanel)element12).PointerExited += this.ChangeCursorExit;
                }
                break;
            case 13: // LogInd.xaml line 201
                {
                    this.setting3Ikon = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 14: // LogInd.xaml line 211
                {
                    this.setting3 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 15: // LogInd.xaml line 196
                {
                    this.setting2Ikon = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 16: // LogInd.xaml line 197
                {
                    this.setting2 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 17: // LogInd.xaml line 192
                {
                    this.setting1Ikon = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 18: // LogInd.xaml line 193
                {
                    this.setting1 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 19: // LogInd.xaml line 172
                {
                    this.profileOpenImg = (global::Windows.UI.Xaml.Controls.Grid)(target);
                    ((global::Windows.UI.Xaml.Controls.Grid)this.profileOpenImg).Tapped += this.ProfileOpen_OnTapped;
                    ((global::Windows.UI.Xaml.Controls.Grid)this.profileOpenImg).PointerEntered += this.ChangeCursorEnter;
                    ((global::Windows.UI.Xaml.Controls.Grid)this.profileOpenImg).PointerExited += this.ChangeCursorExit;
                }
                break;
            case 20: // LogInd.xaml line 177
                {
                    this.profileOpen = (global::Windows.UI.Xaml.Controls.Grid)(target);
                    ((global::Windows.UI.Xaml.Controls.Grid)this.profileOpen).Tapped += this.ProfileOpen_OnTapped;
                    ((global::Windows.UI.Xaml.Controls.Grid)this.profileOpen).PointerEntered += this.ChangeCursorEnter;
                    ((global::Windows.UI.Xaml.Controls.Grid)this.profileOpen).PointerExited += this.ChangeCursorExit;
                }
                break;
            case 21: // LogInd.xaml line 179
                {
                    this.ProfileArrowDown = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBlock)this.ProfileArrowDown).Tapped += this.ProfileOpen_OnTapped;
                    ((global::Windows.UI.Xaml.Controls.TextBlock)this.ProfileArrowDown).PointerEntered += this.ChangeCursorEnter;
                    ((global::Windows.UI.Xaml.Controls.TextBlock)this.ProfileArrowDown).PointerExited += this.ChangeCursorExit;
                }
                break;
            case 22: // LogInd.xaml line 180
                {
                    this.ProfileArrowUp = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBlock)this.ProfileArrowUp).Tapped += this.ProfileOpen_OnTapped;
                    ((global::Windows.UI.Xaml.Controls.TextBlock)this.ProfileArrowUp).PointerEntered += this.ChangeCursorEnter;
                    ((global::Windows.UI.Xaml.Controls.TextBlock)this.ProfileArrowUp).PointerExited += this.ChangeCursorExit;
                }
                break;
            case 23: // LogInd.xaml line 181
                {
                    global::Windows.UI.Xaml.Controls.TextBlock element23 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBlock)element23).Tapped += this.ProfileOpen_OnTapped;
                    ((global::Windows.UI.Xaml.Controls.TextBlock)element23).PointerEntered += this.ChangeCursorEnter;
                    ((global::Windows.UI.Xaml.Controls.TextBlock)element23).PointerExited += this.ChangeCursorExit;
                }
                break;
            case 24: // LogInd.xaml line 83
                {
                    this.OpretBrugerBtnBack = (global::Windows.UI.Xaml.Shapes.Rectangle)(target);
                    ((global::Windows.UI.Xaml.Shapes.Rectangle)this.OpretBrugerBtnBack).PointerEntered += this.LogIndBtn_PointerEntered;
                    ((global::Windows.UI.Xaml.Shapes.Rectangle)this.OpretBrugerBtnBack).PointerExited += this.LogIndBtn_PointerExited;
                }
                break;
            case 25: // LogInd.xaml line 84
                {
                    this.OpretBrugerBtnText = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBlock)this.OpretBrugerBtnText).PointerEntered += this.LogIndBtn_PointerEntered;
                    ((global::Windows.UI.Xaml.Controls.TextBlock)this.OpretBrugerBtnText).PointerExited += this.LogIndBtn_PointerExited;
                }
                break;
            case 26: // LogInd.xaml line 71
                {
                    this.LogIndd = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBlock)this.LogIndd).PointerEntered += this.ChangeCursorEnter;
                    ((global::Windows.UI.Xaml.Controls.TextBlock)this.LogIndd).PointerExited += this.ChangeCursorExit;
                    ((global::Windows.UI.Xaml.Controls.TextBlock)this.LogIndd).Tapped += this.OpretBrugerLogInd_Tapped;
                }
                break;
            case 27: // LogInd.xaml line 58
                {
                    this.LogIndBtnBack = (global::Windows.UI.Xaml.Shapes.Rectangle)(target);
                    ((global::Windows.UI.Xaml.Shapes.Rectangle)this.LogIndBtnBack).PointerEntered += this.LogIndBtn_PointerEntered;
                    ((global::Windows.UI.Xaml.Shapes.Rectangle)this.LogIndBtnBack).PointerExited += this.LogIndBtn_PointerExited;
                }
                break;
            case 28: // LogInd.xaml line 59
                {
                    this.LogIndBtnText = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBlock)this.LogIndBtnText).PointerEntered += this.LogIndBtn_PointerEntered;
                    ((global::Windows.UI.Xaml.Controls.TextBlock)this.LogIndBtnText).PointerExited += this.LogIndBtn_PointerExited;
                }
                break;
            case 29: // LogInd.xaml line 52
                {
                    this.OpretBruger = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBlock)this.OpretBruger).PointerEntered += this.ChangeCursorEnter;
                    ((global::Windows.UI.Xaml.Controls.TextBlock)this.OpretBruger).PointerExited += this.ChangeCursorExit;
                    ((global::Windows.UI.Xaml.Controls.TextBlock)this.OpretBruger).Tapped += this.OpretBrugerLogInd_Tapped;
                }
                break;
            case 30: // LogInd.xaml line 30
                {
                    this.MainMenu = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 31: // LogInd.xaml line 31
                {
                    this.btnClosePane = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBlock)this.btnClosePane).Tapped += this.BtnShowPane_OnClick;
                    ((global::Windows.UI.Xaml.Controls.TextBlock)this.btnClosePane).PointerEntered += this.ChangeCursorEnter;
                    ((global::Windows.UI.Xaml.Controls.TextBlock)this.btnClosePane).PointerExited += this.ChangeCursorExit;
                }
                break;
            case 32: // LogInd.xaml line 33
                {
                    this.hoverEffect1 = (global::Windows.UI.Xaml.Shapes.Rectangle)(target);
                }
                break;
            case 33: // LogInd.xaml line 40
                {
                    this.GridCursor1 = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 34: // LogInd.xaml line 35
                {
                    this.NavMainPage = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBlock)this.NavMainPage).Tapped += this.ChangeMenu;
                    ((global::Windows.UI.Xaml.Controls.TextBlock)this.NavMainPage).PointerEntered += this.MenuItem_OnPointerEntered2;
                    ((global::Windows.UI.Xaml.Controls.TextBlock)this.NavMainPage).PointerExited += this.MenuItem_OnPointerExited2;
                }
                break;
            case 35: // LogInd.xaml line 36
                {
                    this.NavLogInd = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBlock)this.NavLogInd).Tapped += this.ChangeMenu;
                    ((global::Windows.UI.Xaml.Controls.TextBlock)this.NavLogInd).PointerEntered += this.MenuItem_OnPointerEntered2;
                    ((global::Windows.UI.Xaml.Controls.TextBlock)this.NavLogInd).PointerExited += this.MenuItem_OnPointerExited2;
                }
                break;
            case 36: // LogInd.xaml line 37
                {
                    this.NavLogUd = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBlock)this.NavLogUd).Tapped += this.ChangeMenu;
                    ((global::Windows.UI.Xaml.Controls.TextBlock)this.NavLogUd).PointerEntered += this.MenuItem_OnPointerEntered2;
                    ((global::Windows.UI.Xaml.Controls.TextBlock)this.NavLogUd).PointerExited += this.MenuItem_OnPointerExited2;
                }
                break;
            case 37: // LogInd.xaml line 38
                {
                    this.NavCustProfile = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBlock)this.NavCustProfile).Tapped += this.ChangeMenu;
                    ((global::Windows.UI.Xaml.Controls.TextBlock)this.NavCustProfile).PointerEntered += this.MenuItem_OnPointerEntered2;
                    ((global::Windows.UI.Xaml.Controls.TextBlock)this.NavCustProfile).PointerExited += this.MenuItem_OnPointerExited2;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

