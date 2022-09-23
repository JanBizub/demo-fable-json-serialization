module Types

open System

[<RequireQualifiedAccess>]
type Route =
    | Root
    | Invalid

type AppState =
    { CurrentRoute: Route
      Cars: string list
      ErrorMessage: string option }
    static member Empty =
        { CurrentRoute = Route.Root
          Cars = []
          ErrorMessage = None }

type Msg =
    | GetDateOnlyRequest
    | GetDateOnlyResponse of DateOnly
    
    | HttpError of exn