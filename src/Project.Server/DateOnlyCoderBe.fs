namespace DateOnlyCoderBe

open System
open Thoth.Json.Net

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