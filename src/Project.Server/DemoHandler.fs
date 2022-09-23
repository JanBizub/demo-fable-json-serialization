[<RequireQualifiedAccess>]
module DemoHandler

open System
open Microsoft.AspNetCore.Http
open Giraffe

let getDateOnly () =
    fun (next: HttpFunc) (ctx: HttpContext) ->
        task {
            return! json (DateOnly(2022, 11, 11)) next ctx
        }
