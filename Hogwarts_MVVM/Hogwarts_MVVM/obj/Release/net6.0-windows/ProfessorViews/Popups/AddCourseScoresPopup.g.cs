﻿#pragma checksum "..\..\..\..\..\ProfessorViews\Popups\AddCourseScoresPopup.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "48316D3792D0B549CBFE4A40AF17DAD578AF523A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Hogwarts.Views.ProfessorViews.Popups;
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


namespace Hogwarts.Views.ProfessorViews.Popups {
    
    
    /// <summary>
    /// AddCourseScoresPopup
    /// </summary>
    public partial class AddCourseScoresPopup : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 53 "..\..\..\..\..\ProfessorViews\Popups\AddCourseScoresPopup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Minimize;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\..\..\ProfessorViews\Popups\AddCourseScoresPopup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Close;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\..\..\ProfessorViews\Popups\AddCourseScoresPopup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid gradesDataGrid;
        
        #line default
        #line hidden
        
        
        #line 137 "..\..\..\..\..\ProfessorViews\Popups\AddCourseScoresPopup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SubmitScores;
        
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
            System.Uri resourceLocater = new System.Uri("/Hogwarts.Views;component/professorviews/popups/addcoursescorespopup.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\ProfessorViews\Popups\AddCourseScoresPopup.xaml"
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
            
            #line 11 "..\..\..\..\..\ProfessorViews\Popups\AddCourseScoresPopup.xaml"
            ((Hogwarts.Views.ProfessorViews.Popups.AddCourseScoresPopup)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Minimize = ((System.Windows.Controls.Button)(target));
            
            #line 56 "..\..\..\..\..\ProfessorViews\Popups\AddCourseScoresPopup.xaml"
            this.Minimize.Click += new System.Windows.RoutedEventHandler(this.Minimize_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Close = ((System.Windows.Controls.Button)(target));
            
            #line 61 "..\..\..\..\..\ProfessorViews\Popups\AddCourseScoresPopup.xaml"
            this.Close.Click += new System.Windows.RoutedEventHandler(this.Close_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.gradesDataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 5:
            this.SubmitScores = ((System.Windows.Controls.Button)(target));
            
            #line 140 "..\..\..\..\..\ProfessorViews\Popups\AddCourseScoresPopup.xaml"
            this.SubmitScores.Click += new System.Windows.RoutedEventHandler(this.SubmitScores_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

