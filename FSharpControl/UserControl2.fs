namespace FSharpControl

open Avalonia
open Avalonia.Controls
open Avalonia.Media

type UserControl2 () =
    inherit UserControl ()

    static let messageProperty = AvaloniaProperty.Register<UserControl1, string>("Message")

    // Avalonia doesn't like the property definitions to be properties
    static member MessageProperty = messageProperty

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
