module Main

open TimesheetAppRouter
open Elmish
open Elmish.Debug
open Elmish.React
open Elmish.Navigation
open Elmish.UrlParser
open Elmish.HMR // Elmish.HMR must be last open statement in order to HMR works correctly.

Program.mkProgram State.init (State.update) View.Render
|> Program.toNavigable (parseHash pageParser) urlUpdate
#if DEBUG
|> Program.withDebugger
#endif
|> Program.withReactSynchronous "elmish-app"
|> Program.run
