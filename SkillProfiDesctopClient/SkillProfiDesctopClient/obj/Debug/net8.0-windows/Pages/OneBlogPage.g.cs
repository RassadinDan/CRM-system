﻿#pragma checksum "..\..\..\..\Pages\OneBlogPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "E833C325CDC82634342AB68C592F75954ACD4AAF"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
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
    /// OneBlogPage
    /// </summary>
    public partial class OneBlogPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 34 "..\..\..\..\Pages\OneBlogPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TitleBlock;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\..\Pages\OneBlogPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock PreviewBlock;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\..\Pages\OneBlogPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock DescriptionBlock;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\..\Pages\OneBlogPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image BlogImage;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\..\Pages\OneBlogPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button UpdateBut;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\..\Pages\OneBlogPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeleteBut;
        
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
            System.Uri resourceLocater = new System.Uri("/SkillProfiDesctopClient;component/pages/oneblogpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\OneBlogPage.xaml"
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
            this.TitleBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.PreviewBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.DescriptionBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.BlogImage = ((System.Windows.Controls.Image)(target));
            return;
            case 5:
            this.UpdateBut = ((System.Windows.Controls.Button)(target));
            
            #line 65 "..\..\..\..\Pages\OneBlogPage.xaml"
            this.UpdateBut.Click += new System.Windows.RoutedEventHandler(this.UpdateBut_OnClick);
            
            #line default
            #line hidden
            return;
            case 6:
            this.DeleteBut = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

