module Types

open System
open Project.Domain

[<RequireQualifiedAccess>]
type Route =
    | Root
    | Invalid

type AppState =
    { CurrentRoute: Route
      DateOnly: DateOnly option
      Persona: Persona option
      Pbs: Pbs option
      ErrorMessage: string option }
    static member Empty =
        { CurrentRoute = Route.Root
          DateOnly = None
          Persona = None
          Pbs = None
          ErrorMessage = None }

type Msg =
    | GetDateOnlyRequest
    | GetDateOnlyResponse of DateOnly
    
    | GetPersonaRequest
    | GetPersonaResponse of Persona
    
    | GetPbsRequest
    | GetPbsResponse of Pbs
    
    | HttpError of exn