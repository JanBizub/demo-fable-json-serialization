namespace Project.Domain

open System
// #if FABLE_COMPILER
// open Thoth.Json
// #else
// open Thoth.Json.Net
//
// #endif
//
// module Decode =
//     let dateonly : Decoder<DateOnly> =
//         fun path value ->
//             if Decode.Helpers.isString value then
//                 match DateOnly.TryParse (Decode.Helpers.asString value) with
//                 | true, x -> x |> Ok
//                 | _ -> (path, BadPrimitive("a dateonly", value)) |> Error
//             else
//                 (path, BadPrimitive("a dateonly", value)) |> Error
//
// module Encode =
//    let dateonly (value : DateOnly) : JsonValue =
//         value.ToString()


type Alignment =
    | Evil
    | Neutral
    | Good

type Gender =
    | Man
    | Woman
    | Whatever

type Persona =
    { PersonType: Alignment
      Money: decimal option
      GenderTransition: Result<Gender, exn> }