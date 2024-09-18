namespace FSharpControl

open Avalonia
open Avalonia.Media
open Avalonia.Rendering.SceneGraph
open Avalonia.Skia
open Avalonia.Platform
open System.Diagnostics
open SkiaSharp

type TextDraw(bounds : Rect, message : string)  =
    interface ICustomDrawOperation with
        member this.Equals(other) = this.Equals(other)
        member _.Bounds = bounds
        member _.Dispose() = ()
        member _.HitTest(p: Point) = false
        member _.Render(context : ImmediateDrawingContext) =
            let leaseFeature = context.TryGetFeature<ISkiaSharpApiLeaseFeature>();
            if isNull leaseFeature then
                Debug.WriteLine("Current rendering API is not Skia")
            else
                use lease = leaseFeature.Lease()
                let canvas = lease.SkCanvas
                canvas.Clear(SKColors.Yellow)
                use textPaint = new SKPaint(Color = SKColors.Black, TextSize = 20.0f, TextAlign = SKTextAlign.Left)
                let textBounds = textPaint.MeasureText(message)
                let x = single bounds.Left + (single bounds.Width - textBounds) / 2.0f
                let y = single bounds.Top + (single bounds.Height - textBounds) / 2.0f
                canvas.DrawText(message, x, y, textPaint)
                canvas.Restore()