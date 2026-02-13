<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128657792/24.2.1%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T127638)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->

# WPF Grid (TreeListView) - Sync TreeListNode Expansion with ViewModel

This example adds two-way synchronization between the expanded state of each [`TreeListNode`](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.TreeListNode) and a `Boolean` property in the `ViewModel`.

![Sync TreeListNode Expansion with ViewModel](./Images/grid.jpg)

[`IsExpanded`](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.TreeListNode.IsExpanded) is not a dependency property - you cannot bind this property directly to a `Boolean` property in your data model.

This example defines a helper class (`BindableExpandingBehavior`) that attaches to a `GridControl` and synchronizes the expanded state for each node with the [`IsExpanded`](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.TreeListNode.IsExpanded) property in bound data objects.

The `BindableExpandingBehavior` class updates each node in response to underlying property value changes. This helper class also tracks expand/collapse actions in the UI and updates the corresponding data property to reflect the change.

You can use this technique to:

* Maintain node expanded state consistency across user sessions.

* Manage node expanded/collapsed states in code at the data model level.

* Respond to UI actions using the `ViewModel`.

You can reuse the `BindableExpandingBehavior` class in any [`GridControl`](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.GridCell.GridControl) that includes a hierarchical `TreeListView`.

## Implementation Details

### Bindable Expanding Behavior

The `BindableExpandingBehavior` class synchronizes the `TreeListNode`'s expanded state with a `Boolean` property in your `ViewModel`:

* The example attaches `BindableExpandingBehavior` to the `GridControl` and sets its `ExpandingProperty` to `IsExpanded` (the name of the property declared in each data item).

* Every time the `IsExpanded` property value changes in the data object, the corresponding node expands or collapses automatically.

* When a user expands or collapses a node in the UI, `BindableExpandingBehavior` updates the `IsExpanded` property value for the bound object.

State synchronization is implemented as two event handlers corresponding to forward and reverse directions:

1. Forward synchronization (when data changes)

```csharp
public void PropertyChanged(object obj, PropertyChangedEventArgs args) {
    if(args.PropertyName == this.ExpandingProperty) {
        var node = FindNodeByValue(obj, treeView.Nodes);
        node.IsExpanded = (bool)obj.GetType().GetProperty(args.PropertyName).GetValue(obj);
    }
}
```

2. Reverse synchronization (when a user expands/collapses a node)

```csharp
void GridNodeChanged(object sender, TreeListNodeEventArgs e) {
    var propInfo = e.Node.Content.GetType().GetProperty(this.ExpandingProperty);
    propInfo.SetValue(e.Node.Content, e.Node.IsExpanded);
}
```

### Data Model

Both `Parent` and `Child` classes expose the `IsExpanded` property required for synchronization:

```csharp
public bool IsExpanded {
    get { return this._IsExpanded; }
    set { this.SetProperty(ref this._IsExpanded, value, "IsExpanded"); }
}
```

Each `Parent` contains a list of `Child` objects. In turn, each `Child` can contain a list of `Toy` objects, creating a three-level tree structure.

The `DataHelper` class generates a large collection of `Parent` objects populated with nested `Child` objects.

### Setup View

The main window binds the `GridControl` to an `ObservableCollection<Parent>`. Each `Parent` has a collection of `Child` objects, and each `Child` has a collection of `Toy` items. The `TreeListView` displays this hierarchy across three levels.

To synchronize node expanded states with the `ViewModel`, the grid includes the `BindableExpandingBehavior` class as follows:

```xaml
<dxg:GridControl ItemsSource="{Binding Parents}" AutoGenerateColumns="None">
    <dxg:GridControl.View>
        <dxg:TreeListView Name="view"
                          KeyFieldName="Name"
                          ParentFieldName=""
                          AutoWidth="True"
                          ShowIndicator="False"
                          ChildNodesPath="Children">
            <dxmvvm:Interaction.Behaviors>
                <local:BindableExpandingBehavior ExpandingProperty="IsExpanded" />
            </dxmvvm:Interaction.Behaviors>
        </dxg:TreeListView>
    </dxg:GridControl.View>
</dxg:GridControl>
```

## Files to Review

* [MainWindow.xaml](./CS/DevExpress.Example04/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/DevExpress.Example04/MainWindow.xaml))
* [MainWindow.xaml.cs](./CS/DevExpress.Example04/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/DevExpress.Example04/MainWindow.xaml.vb))
* [BindableExpandingBehavior.cs](./CS/DevExpress.Example04/BindableExpandingBehavior.cs) (VB: [BindableExpandingBehavior.vb](./VB/DevExpress.Example04/BindableExpandingBehavior.vb))
* [DataHelper.cs](./CS/DevExpress.Example04/Data/DataHelper.cs) (VB: [DataHelper.vb](./VB/DevExpress.Example04/Data/DataHelper.vb))
* [Parent.cs](./CS/DevExpress.Example04/Data/Parent.cs) (VB: [Parent.vb](./VB/DevExpress.Example04/Data/Parent.vb))

## Documentation

* [TreeListNode](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.TreeListNode)
* [GridControl](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.GridCell.GridControl)
* [IsExpanded](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.TreeListNode.IsExpanded)
* [ExpandingProperty](https://docs.devexpress.com/WPF/DevExpress.Xpf.Core.DXExpander.ExpandingProperty)

## More Examples

* [WPF Data Grid - Specify Custom Content for Headers Displayed in the Column Chooser](https://github.com/DevExpress-Examples/wpf-data-grid-custom-content-for-column-chooser-headers)
* [WPF Data Grid - Bind to Dynamic Data](https://github.com/DevExpress-Examples/wpf-bind-gridcontrol-to-dynamic-data)
* [Implement CRUD Operations in the WPF Data Grid](https://github.com/DevExpress-Examples/wpf-data-grid-implement-crud-operations)
* [WPF Grid - Resize Rows Using a Splitter](https://github.com/sergepilipchuk/wpf-grid-resize-rows-using-splitter)

<!-- feedback -->
## Does This Example Address Your Development Requirements/Objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=wpf-grid-sync-isnodeexpanded-with-view-model&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=wpf-grid-sync-isnodeexpanded-with-view-model&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
