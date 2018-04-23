# How to emulate Binding to the IsExpanded property of the TreeListNode


<p>Because the TreeListNode’s IsExpanded property is not a DependencyProperty, there is no way to create TwoWay binding between the IsExpanded and data source item’s property. The example demonstrates how to emulate this functionality using behaviors.</p>
<p>BindableExpandingBehavior class attaches to a GridControl to provide the functionality. The BindableExpandingBehavior’s ExpandingProperty must be set and has to contain the name of the property in a data item, which will be used to expand/collapse the TreeListNode. The type of the property has to be Boolean.</p>
<p>The behavior will be automatically enabled for each level in TreeListView where a data item contains the same property name set in the BindableExpandingBehavior’s ExpandingProperty.</p>
<p>You can easily add the same functionality to your project using BindableExpandingBehavior class and attaching it as a behavior to your GridControl.</p>

<br/>


