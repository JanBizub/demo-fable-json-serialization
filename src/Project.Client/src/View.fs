[<RequireQualifiedAccess>]
module View
open Fable.Core.JsInterop
open Feliz
open Types
    
[<ReactComponent>]
let Render (state: AppState) dispatch =
  importAll "./style.scss"

  Html.div [
    Html.p [ prop.text (match state.ErrorMessage with None -> "" | Some e -> e) ]
    Html.p [ prop.text "Thoth.JSON serialization tests" ]
    
    Html.p [ prop.text "GET TESTS" ]
    Html.button [
      prop.text "Date Only Test"
      prop.onClick (fun _ -> GetDateOnlyRequest |> dispatch)
    ]
    Html.button [
      prop.text "Persona Test"
      prop.onClick (fun _ -> GetPersonaRequest |> dispatch)
    ]
    Html.button [
      prop.text "Pbs Test"
      prop.onClick (fun _ -> GetPbsRequest |> dispatch)
    ]
    Html.button [
      prop.text "Pbs Menu Test"
      prop.onClick (fun _ -> GetPbsMenuRequest |> dispatch)
    ]
    
    Html.p [ prop.text "POST TESTS" ]

  ]
