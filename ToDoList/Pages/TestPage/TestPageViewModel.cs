using Asv.Avalonia;
using Asv.Common;
using Material.Icons;
using R3;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Threading;
using System.Threading.Tasks;

namespace ToDoList.Pages.TestPage;

[ExportPage(PageId)]
public class TestPageViewModel : PageViewModel<TestPageViewModel>
{
    public const string PageId = "test.page";
    public const MaterialIconKind PageIcon = MaterialIconKind.TestTube;

    private readonly ReactiveProperty<string?> _inputText;
    private readonly ReactiveProperty<string?> _outputText;
    private readonly ReactiveProperty<string?> _value;
    private readonly Subject<bool> _canClearSearchText = new();

    public HistoricalStringProperty InputText { get; }
    public HistoricalStringProperty StringProp { get; }

    public BindableReactiveProperty<string> OutputText { get; }
    public ReactiveCommand ShowTextCommand { get; }
    public ReactiveCommand ClearTextCommand { get; }
    public ReactiveCommand Clear { get; }

    public TestPageViewModel()
        : this(DesignTime.UnitService, DesignTime.CommandService)
    {
        DesignTime.ThrowIfNotDesignMode();
    }

    [ImportingConstructor]
    public TestPageViewModel(IUnitService unit, ICommandService commandService)
        : base(PageId, commandService)
    {
        Title = "Test Page";
        Icon = PageIcon;

        _inputText = new ReactiveProperty<string?>();
        _outputText = new ReactiveProperty<string?>();
        _value = new ReactiveProperty<string?>();

        InputText = new HistoricalStringProperty($"{PageId}.{nameof(InputText)}", _inputText)
        {
            Parent = this,
        };

        OutputText = new BindableReactiveProperty<string>();

        StringProp = new HistoricalStringProperty(
            $"{PageId}.{nameof(StringProp)}",
            _value,
            [
                v =>
                {
                    if (string.IsNullOrWhiteSpace(v))
                        return new Exception("Value shouldn't be empty");

                    return ValidationResult.Success;
                }
            ])
        {
            Parent = this,
        };

        ShowTextCommand = new ReactiveCommand(ShowTextAsync);
        ClearTextCommand = new ReactiveCommand(ClearTextAsync);
        Clear = _canClearSearchText.ToReactiveCommand(_ => _value.Value = string.Empty);

        _canClearSearchTextSubscription = StringProp.ViewValue.Subscribe(txt =>
            _canClearSearchText.OnNext(!string.IsNullOrWhiteSpace(txt))
        );
    }

    private ValueTask ShowTextAsync(Unit unit, CancellationToken cancellationToken)
    {
        OutputText.Value = InputText.ViewValue.Value;
        return ValueTask.CompletedTask;
    }

    private ValueTask ClearTextAsync(Unit unit, CancellationToken cancellationToken)
    {
        InputText.ViewValue.Value = string.Empty;
        OutputText.Value = string.Empty;
        return ValueTask.CompletedTask;
    }

    protected override void AfterLoadExtensions() { }

    public override IEnumerable<IRoutable> GetRoutableChildren()
    {
        yield return InputText;
        yield return StringProp;
    }

    protected override TestPageViewModel GetContext()
    {
        return this;
    }

    public override IExportInfo Source => SystemModule.Instance;

    #region Dispose

    private readonly IDisposable _canClearSearchTextSubscription;

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            ShowTextCommand.Dispose();
            ClearTextCommand.Dispose();
            Clear.Dispose();

            _inputText.Dispose();
            _outputText.Dispose();
            _value.Dispose();

            InputText.Dispose();
            OutputText.Dispose();
            StringProp.Dispose();

            _canClearSearchTextSubscription.Dispose();
            _canClearSearchText.Dispose();
        }

        base.Dispose(disposing);
    }
    #endregion
}
