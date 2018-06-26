namespace MinmalFsharpXamarinFormsMac
open Xamarin.Forms
open Xamarin.Forms.Platform.MacOS
open AppKit

type App() as this =
    inherit Application()
    let stack = StackLayout(VerticalOptions = LayoutOptions.Center)
    let label = Label(XAlign = TextAlignment.Center, Text = "Welcome to F# Xamarin.Forms!")
    let btn = Button(Text = "Quit")
    do
        btn.Clicked.Add(fun _ -> this.Quit ())
        stack.Children.Add(label)
        stack.Children.Add(btn)
        base.MainPage <- ContentPage(Content = stack)
        
    
    
   
type AppDelegate () =
    inherit FormsApplicationDelegate ()
    let style = NSWindowStyle.Closable ||| NSWindowStyle.Resizable ||| NSWindowStyle.Titled
    let rect = CoreGraphics.CGRect(200.0,100.0,1024.0,768.0)
    let window = new NSWindow(
                    rect, 
                    style, 
                    NSBackingStore.Buffered, 
                    false, 
                    Title = "Xamarin.Forms on Mac!",
                    TitleVisibility = NSWindowTitleVisibility.Hidden)
    override __.MainWindow with get () = window
    override __.DidFinishLaunching notification = 
                Forms.Init ()
                __.LoadApplication(new App())
                base.DidFinishLaunching(notification)

module main =
    [<EntryPoint>]
    let main args =
        NSApplication.Init ()
        NSApplication.SharedApplication.Delegate <- new AppDelegate();
        NSApplication.Main (args)
        0
