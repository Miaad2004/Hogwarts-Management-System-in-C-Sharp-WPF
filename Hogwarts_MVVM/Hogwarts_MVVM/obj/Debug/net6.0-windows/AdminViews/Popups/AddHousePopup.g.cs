﻿#pragma checksum "..\..\..\..\..\AdminViews\Popups\AddHousePopup.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "D3F555D1F05AFEE41993B231724EAAE4B4134D8F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Hogwarts.Views.AdminViews.Popups;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Hogwarts.Views.AdminViews.Popups {
    
    
    /// <summary>
    /// AddHousePopup
    /// </summary>
    public partial class AddHousePopup : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 58 "..\..\..\..\..\AdminViews\Popups\AddHousePopup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Minimize;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\..\..\AdminViews\Popups\AddHousePopup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Close;
        
        #line default
        #line hidden
        
        
        #line 117 "..\..\..\..\..\AdminViews\Popups\AddHousePopup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox houseCombo;
        
        #line default
        #line hidden
        
        
        #line 133 "..\..\..\..\..\AdminViews\Popups\AddHousePopup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtOpenFile;
        
        #line default
        #line hidden
        
        
        #line 141 "..\..\..\..\..\AdminViews\Popups\AddHousePopup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button OpenFile;
        
        #line default
        #line hidden
        
        
        #line 149 "..\..\..\..\..\AdminViews\Popups\AddHousePopup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddHouse;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.5.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Hogwarts.Views;component/adminviews/popups/addhousepopup.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\AdminViews\Popups\AddHousePopup.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.5.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 11 "..\..\..\..\..\AdminViews\Popups\AddHousePopup.xaml"
            ((Hogwarts.Views.AdminViews.Popups.AddHousePopup)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Minimize = ((System.Windows.Controls.Button)(target));
            
            #line 61 "..\..\..\..\..\AdminViews\Popups\AddHousePopup.xaml"
            this.Minimize.Click += new System.Windows.RoutedEventHandler(this.Minimize_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Close = ((System.Windows.Controls.Button)(target));
            
            #line 66 "..\..\..\..\..\AdminViews\Popups\AddHousePopup.xaml"
            this.Close.Click += new System.Windows.RoutedEventHandler(this.Close_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.houseCombo = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.txtOpenFile = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.OpenFile = ((System.Windows.Controls.Button)(target));
            
            #line 142 "..\..\..\..\..\AdminViews\Popups\AddHousePopup.xaml"
            this.OpenFile.Click += new System.Windows.RoutedEventHandler(this.OpenFile_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.AddHouse = ((System.Windows.Controls.Button)(target));
            
            #line 152 "..\..\..\..\..\AdminViews\Popups\AddHousePopup.xaml"
            this.AddHouse.Click += new System.Windows.RoutedEventHandler(this.AddHouse_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

