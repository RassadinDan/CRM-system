﻿#pragma checksum "..\..\..\..\Pages\UpdateUIPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "AD694E63FFD77A67A1675DAE010BAF366F1FF008"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using SkillProfiDesctopClient.Pages;
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


namespace SkillProfiDesctopClient.Pages {
    
    
    /// <summary>
    /// UpdateUIPage
    /// </summary>
    public partial class UpdateUIPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 73 "..\..\..\..\Pages\UpdateUIPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox MainBox;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\..\Pages\UpdateUIPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ProjectsBox;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\..\..\Pages\UpdateUIPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox BlogsBox;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\..\..\Pages\UpdateUIPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ServicesBox;
        
        #line default
        #line hidden
        
        
        #line 97 "..\..\..\..\Pages\UpdateUIPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ContactsBox;
        
        #line default
        #line hidden
        
        
        #line 103 "..\..\..\..\Pages\UpdateUIPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button UpdateBut;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.6.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/SkillProfiDesctopClient;component/pages/updateuipage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\UpdateUIPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.6.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.MainBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.ProjectsBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.BlogsBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.ServicesBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.ContactsBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.UpdateBut = ((System.Windows.Controls.Button)(target));
            
            #line 109 "..\..\..\..\Pages\UpdateUIPage.xaml"
            this.UpdateBut.Click += new System.Windows.RoutedEventHandler(this.UpdateBut_OnClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

