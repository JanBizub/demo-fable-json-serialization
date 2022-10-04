[<RequireQualifiedAccess>]
module HttpRequests

open Elmish
open System
open Types
open Fable.SimpleHttp
open Fable.SimpleJson
open Project.Domain

let getDateOnlyTest () =
    async {
        let! response =
            Http.request "https://localhost:55784/api/getdateonly"
            |> Http.method GET
            |> Http.header (Headers.contentType "application/json")
            |> Http.send
        
        match response.statusCode with
        | 200 ->
            return
                response.responseText
                |> Json.parseAs<DateOnly>
                |> Ok
        | _ -> 
            return
                (response.statusCode, response.responseText)
                |> Error
    }

let getPersonTest () =
    async {
        let! response =
            Http.request "https://localhost:55784/api/getpersona"
            |> Http.method GET
            |> Http.header (Headers.contentType "application/json")
            |> Http.send
        
        match response.statusCode with
        | 200 ->
            return
                response.responseText
                |> Json.parseAs<Persona>
                |> Ok
        | _ -> 
            return
                (response.statusCode, response.responseText)
                |> Error
    }
    
let getPbsTest () =
    async {
        let! response =
            Http.request "https://localhost:55784/api/getpersona"
            |> Http.method GET
            |> Http.header (Headers.contentType "application/json")
            |> Http.send
        
        match response.statusCode with
        | 200 ->
            return
                response.responseText
                |> Json.parseAs<Pbs>
                |> Ok
        | _ -> 
            return
                (response.statusCode, response.responseText)
                |> Error
    }
    
let getPbsMenu () =
    async {
        let! response =
            Http.request "https://localhost:55784/api/getpbsmenu"
            |> Http.method GET
            |> Http.header (Headers.contentType "application/json")
            |> Http.send
        
        match response.statusCode with
        | 200 ->
            return
                response.responseText
                |> Json.parseAs<PbsMenu>
                |> Ok
        | _ -> 
            return
                (response.statusCode, response.responseText)
                |> Error
    }