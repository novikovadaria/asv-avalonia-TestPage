using Asv.Avalonia;
using Asv.Common;
using R3;
using ToDoList.Pages.TestPage.Commands;

namespace ToDoList.Pages.TestPage
{
    [ExportExtensionFor<IHomePage>]
    public class HomePageTestExtention : IExtensionFor<IHomePage>
    {
        public void Extend(IHomePage context, CompositeDisposable contextDispose)
        {
            context.Tools.Add(
                OpenTestPageCommand.StaticInfo.CreateAction().DisposeItWith(contextDispose)
            );
        }
    }
}
