﻿#pragma checksum "..\..\..\UpdateProjectWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "E608381F14AA67361E2621E5768D64605E209D16"
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
    /// UpdateProjectWindow
    /// </summary>
    public partial class UpdateProjectWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 39 "..\..\..\UpdateProjectWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PreviewBox;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\UpdateProjectWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox DescriptionBox;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\UpdateProjectWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button UpdateBut;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\UpdateProjectWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button UploadImgBut;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\UpdateProjectWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image ProjectImage;
        
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
            System.Uri resourceLocater = new System.Uri("/SkillProfiDesctopClient;component/updateprojectwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UpdateProjectWindow.xaml"
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
            this.PreviewBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.DescriptionBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.UpdateBut = ((System.Windows.Controls.Button)(target));
            
            #line 62 "..\..\..\UpdateProjectWindow.xaml"
            this.UpdateBut.Click += new System.Windows.RoutedEventHandler(this.UpdateBut_OnClick);
            
            #line default
            #line hidden
            return;
            case 4:
            this.UploadImgBut = ((System.Windows.Controls.Button)(target));
            
            #line 70 "..\..\..\UpdateProjectWindow.xaml"
            this.UploadImgBut.Click += new System.Windows.RoutedEventHandler(this.UploadImgBut_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ProjectImage = ((System.Windows.Controls.Image)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

