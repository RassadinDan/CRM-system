﻿#pragma checksum "..\..\..\WorkbenchWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "165699989A93513AC530F0643C762E6D1F7ACE0E"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using SkillProfiDesctopClient;
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


namespace SkillProfiDesctopClient {
    
    
    /// <summary>
    /// WorkbenchWindow
    /// </summary>
    public partial class WorkbenchWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\..\WorkbenchWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button WorkbenchBut;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\WorkbenchWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button MainBut;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\WorkbenchWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ProjectsBut;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\WorkbenchWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BlogsBut;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\WorkbenchWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ServicesBut;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\WorkbenchWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ContactsBut;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\WorkbenchWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ApplicationsListBox;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.4.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/SkillProfiDesctopClient;component/workbenchwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\WorkbenchWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.4.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.WorkbenchBut = ((System.Windows.Controls.Button)(target));
            return;
            case 2:
            this.MainBut = ((System.Windows.Controls.Button)(target));
            return;
            case 3:
            this.ProjectsBut = ((System.Windows.Controls.Button)(target));
            return;
            case 4:
            this.BlogsBut = ((System.Windows.Controls.Button)(target));
            return;
            case 5:
            this.ServicesBut = ((System.Windows.Controls.Button)(target));
            return;
            case 6:
            this.ContactsBut = ((System.Windows.Controls.Button)(target));
            
            #line 54 "..\..\..\WorkbenchWindow.xaml"
            this.ContactsBut.Click += new System.Windows.RoutedEventHandler(this.ContactsBut_OnClick);
            
            #line default
            #line hidden
            return;
            case 7:
            this.ApplicationsListBox = ((System.Windows.Controls.ListBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

