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
      PbsMenu: PbsMenu option
      ErrorMessage: string option }
    static member Empty =
        { CurrentRoute = Route.Root
          DateOnly = None
          Persona = None
          Pbs = None
          PbsMenu = None
          ErrorMessage = None }

type HttpStatusCode = int
type ErrorMessage = string
type HttpError = HttpStatusCode * ErrorMessage


type Msg =
    | GetDateOnlyRequest
    | GetDateOnlyResponse of Result<DateOnly, HttpError>
    
    | GetPersonaRequest
    | GetPersonaResponse of Result<Persona, HttpError>
    
    | GetPbsRequest
    | GetPbsResponse of Result<Pbs, HttpError>
    
    | GetPbsMenuRequest
    | GetPbsMenuResponse of Result<PbsMenu, HttpError>
    
    | HttpError of exn