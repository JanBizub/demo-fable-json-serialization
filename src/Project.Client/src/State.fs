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
    | GetDateOnlyRequest -> { state with ErrorMessage = None }, Cmd.OfPromise.either HttpRequests.getDateOnlyTest () GetDateOnlyResponse HttpError


    | GetDateOnlyResponse dateOnly ->
        console.log dateOnly
        { state with DateOnly = Some dateOnly }, Cmd.none


    | GetPersonaRequest -> { state with ErrorMessage = None }, Cmd.OfPromise.either HttpRequests.getPersonTest () GetPersonaResponse HttpError


    | GetPersonaResponse persona ->
        console.log persona
        { state with Persona = Some persona }, Cmd.none

    
    | GetPbsRequest ->
        { state with ErrorMessage = None }, Cmd.OfPromise.either HttpRequests.getPbsTest () GetPbsResponse HttpError
    

    | GetPbsResponse pbs ->
        console.log pbs
        { state with Pbs = Some pbs }, Cmd.none
        
        
    | GetPbsMenuRequest ->
        { state with ErrorMessage = None }, Cmd.OfPromise.either HttpRequests.getPbsMenu () GetPbsMenuResponse HttpError
    

    | GetPbsMenuResponse pbsMenu ->
        console.log pbsMenu
        { state with PbsMenu = Some pbsMenu }, Cmd.none

    
    | HttpError exn -> { state with ErrorMessage = $"Error: {exn.Message}" |> Some }, Cmd.none