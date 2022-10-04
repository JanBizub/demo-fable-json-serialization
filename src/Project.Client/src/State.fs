module State

open Elmish
open Microsoft.FSharp.Core
open Types
open TimesheetAppRouter

let console = Browser.Dom.console

let init result =
    let state, cmd =
        urlUpdate result AppState.Empty

    state, Cmd.batch []

let update msg (state: AppState) =
    match msg with
    | GetDateOnlyRequest -> state, Cmd.OfAsync.either HttpRequests.getDateOnlyTest () GetDateOnlyResponse HttpError

    | GetDateOnlyResponse dateOnly ->
        console.log dateOnly
        { state with DateOnly = None}, Cmd.none


    | GetPersonaRequest -> state, Cmd.OfAsync.either HttpRequests.getPersonTest () GetPersonaResponse HttpError
    
    | GetPersonaResponse persona ->
        console.log persona
        { state with Persona = None }, Cmd.none

    
    | GetPbsRequest ->
        state, Cmd.OfAsync.either HttpRequests.getPbsTest () GetPbsResponse HttpError
    
    | GetPbsResponse pbs ->
        console.log pbs
        { state with Pbs = None }, Cmd.none
        
        
    | GetPbsMenuRequest ->
        state, Cmd.OfAsync.either HttpRequests.getPbsMenu () GetPbsMenuResponse HttpError
    
    | GetPbsMenuResponse pbsMenu ->
        console.log pbsMenu
        { state with PbsMenu = None }, Cmd.none

    
    | HttpError exn ->
        { state with ErrorMessage = $"Error: HTTP: {exn.Message}" |> Some }, Cmd.none