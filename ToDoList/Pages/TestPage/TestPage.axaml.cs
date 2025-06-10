using Asv.Avalonia;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ToDoList.Pages.TestPage;

[ExportViewFor(typeof(TestPageViewModel))]
public partial class TestPage : UserControl
{
    public TestPage()
    {
        InitializeComponent();
    }
}