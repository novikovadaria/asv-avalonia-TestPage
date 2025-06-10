using Asv.Avalonia;
using Asv.Avalonia.GeoMap;
using ObservableCollections;
using R3;

namespace ToDoList.Pages.TestPage
{
    public interface ITestPage : IPage
    {
        ObservableList<IMapWidget> Widgets { get; }
        ObservableList<IMapAnchor> Anchors { get; }
        BindableReactiveProperty<IMapAnchor?> SelectedAnchor { get; }
    }
}
