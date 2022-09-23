module Types

open System
open Project.Domain

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
    
    | GetPersonaRequest
    | GetPersonaResponse of Persona
    
    | HttpError of exn