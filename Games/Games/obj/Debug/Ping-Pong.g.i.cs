﻿#pragma checksum "..\..\Ping-Pong.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "B092DECA34FDEB60302E12DDB577273BA213BFB3A8F7B885C802A015E30CA4CC"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Games;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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


namespace Games {
    
    
    /// <summary>
    /// Ping_Pong
    /// </summary>
    public partial class Ping_Pong : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\Ping-Pong.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas GameCanvas;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\Ping-Pong.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock LeftScoreText;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\Ping-Pong.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock RightScoreText;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\Ping-Pong.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle BottomRectangle;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\Ping-Pong.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Ellipse Shar;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\Ping-Pong.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle TopRectangle;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\Ping-Pong.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel Menu;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Games;component/ping-pong.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Ping-Pong.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.GameCanvas = ((System.Windows.Controls.Canvas)(target));
            return;
            case 2:
            this.LeftScoreText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.RightScoreText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.BottomRectangle = ((System.Windows.Shapes.Rectangle)(target));
            return;
            case 5:
            this.Shar = ((System.Windows.Shapes.Ellipse)(target));
            return;
            case 6:
            this.TopRectangle = ((System.Windows.Shapes.Rectangle)(target));
            return;
            case 7:
            this.Menu = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 8:
            
            #line 18 "..\..\Ping-Pong.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.continues);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 19 "..\..\Ping-Pong.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.menus);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

