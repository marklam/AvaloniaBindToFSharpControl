using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using FSharpControl;

namespace CSharpControl;

public class UserControl1 : UserControl
{
    public static readonly StyledProperty<string> MessageProperty = AvaloniaProperty.Register<UserControl1, string>("Message");

    public string Message
    {
        get => GetValue(MessageProperty);
        set => SetValue(MessageProperty, value);
    }

    public override void Render(DrawingContext context)
    {
        base.Render(context);

        var custom =
            new TextDraw(
                new Rect(0, 0, Bounds.Width, Bounds.Height),
                Message
            );

        context.Custom(custom);
    }
}