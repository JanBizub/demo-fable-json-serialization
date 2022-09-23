module State

open Elmish
open Microsoft.FSharp.Core
open Types
open TimesheetAppRouter

let init result =
    let state, cmd =
        urlUpdate result AppState.Empty

    state, Cmd.batch []

let update msg (state: AppState) =
    match msg with
    | GetDateOnlyRequest ->
        { state with Cars = [] }, Cmd.OfPromise.either HttpRequests.getDateOnlyTest () GetDateOnlyResponse HttpError

    | GetDateOnlyResponse dateOnly ->
        Browser.Dom.console.log dateOnly
        { state with Cars = [] }, Cmd.none

    | HttpError exn -> { state with ErrorMessage = $"Error: {exn.Message}" |> Some }, Cmd.none