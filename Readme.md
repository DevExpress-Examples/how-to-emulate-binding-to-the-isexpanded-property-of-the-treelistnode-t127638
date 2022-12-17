<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128657792/22.2.2%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T127638)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [BindableExpandingBehavior.cs](./CS/DevExpress.Example04/BindableExpandingBehavior.cs) (VB: [BindableExpandingBehavior.vb](./VB/DevExpress.Example04/BindableExpandingBehavior.vb))
* [DataHelper.cs](./CS/DevExpress.Example04/Data/DataHelper.cs) (VB: [DataHelper.vb](./VB/DevExpress.Example04/Data/DataHelper.vb))
* [Parent.cs](./CS/DevExpress.Example04/Data/Parent.cs) (VB: [Parent.vb](./VB/DevExpress.Example04/Data/Parent.vb))
* **[MainWindow.xaml](./CS/DevExpress.Example04/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/DevExpress.Example04/MainWindow.xaml))**
* [MainWindow.xaml.cs](./CS/DevExpress.Example04/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/DevExpress.Example04/MainWindow.xaml.vb))
<!-- default file list end -->
# How to emulate Binding to the IsExpanded property of the TreeListNode


<p>Because the TreeListNode’s IsExpanded property is not a DependencyProperty, there is no way to create TwoWay binding between the IsExpanded and data source item’s property. The example demonstrates how to emulate this functionality using behaviors.</p>
<p>BindableExpandingBehavior class attaches to a GridControl to provide the functionality. The BindableExpandingBehavior’s ExpandingProperty must be set and has to contain the name of the property in a data item, which will be used to expand/collapse the TreeListNode. The type of the property has to be Boolean.</p>
<p>The behavior will be automatically enabled for each level in TreeListView where a data item contains the same property name set in the BindableExpandingBehavior’s ExpandingProperty.</p>
<p>You can easily add the same functionality to your project using BindableExpandingBehavior class and attaching it as a behavior to your GridControl.</p>

<br/>


