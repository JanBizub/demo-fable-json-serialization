[<RequireQualifiedAccess>]
module HttpRequests

open System
open Fable.Core
open Thoth.Fetch
open Thoth.Json
open Project.Domain
open DateOnlyCoderFe

let getDateOnlyTest () : JS.Promise<DateOnly> =
    promise {
        let url =
            "https://localhost:55784/api/getdateonly"

        let extra =
            Extra.empty
            |> Extra.withCustom Encode.dateonly Decode.dateonly

        return! Fetch.get (url, extra = extra)
    }

let getPersonTest () : JS.Promise<Persona> =
    promise {
        let url =
            "https://localhost:55784/api/getpersona"

        let extra = Extra.empty |> Extra.withDecimal

        return! Fetch.get (url, extra = extra)
    }
    
let getPbsTest () : JS.Promise<Pbs> =
    promise {
        let url =
            "https://localhost:55784/api/getpbs"

        return! Fetch.get (url)
    }
    
let getPbsMenu () : JS.Promise<PbsMenu> =
    promise {
        let url =
            "https://localhost:55784/api/getpbsmenu"

        return! Fetch.get (url)
    }