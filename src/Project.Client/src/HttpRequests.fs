[<RequireQualifiedAccess>]
module HttpRequests

open System
open Fable.Core
open Thoth.Fetch
open Thoth.Json
open DateOnlyCoderFe

let getDateOnlyTest () : JS.Promise<DateOnly> =
    promise {
        let url = "https://localhost:55784/api/getdateonly"
        
        return! Fetch.get(url, decoder = Decode.dateonly)
    }