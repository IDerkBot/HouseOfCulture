﻿#pragma checksum "..\..\..\..\Views\Tables\GroupsTableControl.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "043DBDD3412820FEAAE0776EC5F76D708FB546E0E11775E60C93CBF1EBAE1BB0"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Arion.Style.AttachedProperties;
using HouseOfCulture.ViewModels;
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


namespace HouseOfCulture.Views.Tables {
    
    
    /// <summary>
    /// GroupsTableControl
    /// </summary>
    public partial class GroupsTableControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 24 "..\..\..\..\Views\Tables\GroupsTableControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TbSearch;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\Views\Tables\GroupsTableControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DgData;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\..\Views\Tables\GroupsTableControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTemplateColumn ColumnEdit;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\..\Views\Tables\GroupsTableControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTemplateColumn ColumnRequest;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\..\..\Views\Tables\GroupsTableControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnDelete;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\..\..\Views\Tables\GroupsTableControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnAdd;
        
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
            System.Uri resourceLocater = new System.Uri("/HouseOfCulture;component/views/tables/groupstablecontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\Tables\GroupsTableControl.xaml"
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
            
            #line 11 "..\..\..\..\Views\Tables\GroupsTableControl.xaml"
            ((HouseOfCulture.Views.Tables.GroupsTableControl)(target)).Loaded += new System.Windows.RoutedEventHandler(this.GroupsTableControl_OnLoaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.TbSearch = ((System.Windows.Controls.TextBox)(target));
            
            #line 29 "..\..\..\..\Views\Tables\GroupsTableControl.xaml"
            this.TbSearch.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TbSearch_OnTextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.DgData = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 4:
            this.ColumnEdit = ((System.Windows.Controls.DataGridTemplateColumn)(target));
            return;
            case 6:
            this.ColumnRequest = ((System.Windows.Controls.DataGridTemplateColumn)(target));
            return;
            case 8:
            this.BtnDelete = ((System.Windows.Controls.Button)(target));
            
            #line 91 "..\..\..\..\Views\Tables\GroupsTableControl.xaml"
            this.BtnDelete.Click += new System.Windows.RoutedEventHandler(this.BtnDelete_OnClick);
            
            #line default
            #line hidden
            return;
            case 9:
            this.BtnAdd = ((System.Windows.Controls.Button)(target));
            
            #line 97 "..\..\..\..\Views\Tables\GroupsTableControl.xaml"
            this.BtnAdd.Click += new System.Windows.RoutedEventHandler(this.BtnAdd_OnClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 5:
            
            #line 60 "..\..\..\..\Views\Tables\GroupsTableControl.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnEdit_OnClick);
            
            #line default
            #line hidden
            break;
            case 7:
            
            #line 69 "..\..\..\..\Views\Tables\GroupsTableControl.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnRequest_OnClick);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

