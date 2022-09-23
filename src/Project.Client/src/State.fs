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
    | GetDateOnlyRequest -> state, Cmd.OfPromise.either HttpRequests.getDateOnlyTest () GetDateOnlyResponse HttpError


    | GetDateOnlyResponse dateOnly ->
        console.log dateOnly
        state, Cmd.none


    | GetPersonaRequest -> state, Cmd.OfPromise.either HttpRequests.getPersonTest () GetPersonaResponse HttpError


    | GetPersonaResponse persona ->
        console.log persona
        state, Cmd.none


    | HttpError exn -> { state with ErrorMessage = $"Error: {exn.Message}" |> Some }, Cmd.none