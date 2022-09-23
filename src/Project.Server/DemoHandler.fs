[<RequireQualifiedAccess>]
module DemoHandler

open System
open Microsoft.AspNetCore.Http
open Giraffe
open Project.Domain

let getDateOnly () =
    fun (next: HttpFunc) (ctx: HttpContext) ->
        task {
            return! json (DateOnly(2022, 11, 11)) next ctx
        }
        
let getPersona () =
    fun (next: HttpFunc) (ctx: HttpContext) ->
        task {
            let persona = { PersonType = Evil; Money = Some 155m; GenderTransition = Ok Whatever }
            
            return! json persona next ctx
        }