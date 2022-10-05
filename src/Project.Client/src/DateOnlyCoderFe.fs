namespace DateOnlyCoderFe

open System
open Thoth.Json

// https://stackoverflow.com/questions/56542404/cannot-generate-auto-encoder-for-microsoft-fsharp-core-unit-please-pass-an-extr

module Decode =
    let dateonly : Decoder<DateOnly> =
        fun path value ->
            if Decode.Helpers.isString value then
                match DateOnly.TryParse (Decode.Helpers.asString value) with
                | true, x -> x |> Ok
                | _ -> (path, BadPrimitive("a dateonly", value)) |> Error
            else
                (path, BadPrimitive("a dateonly", value)) |> Error
                
module Encode =
   let dateonly (value : DateOnly) : JsonValue =
        value.ToString()