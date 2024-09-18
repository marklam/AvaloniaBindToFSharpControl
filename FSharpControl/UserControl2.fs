namespace FSharpControl

open Avalonia
open Avalonia.Controls
open Avalonia.Media

type UserControl2 () =
    inherit UserControl ()

    // These are required to be fields (ie let) by Avalonia's bindings.
    // If <ProduceReferenceAssembly>false</ProduceReferenceAssembly> is not specified in the fsproj,
    // then the bindings will search the the generated reference assembly - which won't contain these, because a static let binding is internal.
    // And so the bindings will fail when compiling the xaml.
    static member MessageProperty = AvaloniaProperty.Register<UserControl1, string>("Message")

    member this.Message
        with get () = this.GetValue(UserControl2.MessageProperty)
        and  set v = this.SetValue(UserControl2.MessageProperty, v) |> ignore

    override this.Render(context : DrawingContext) =
        base.Render(context)

        let custom =
            new TextDraw(
                new Rect(0., 0., this.Bounds.Width, this.Bounds.Height),
                this.Message
            )
        context.Custom(custom)
