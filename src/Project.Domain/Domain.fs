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
    
    
type XrmEntityReference = { Id: Guid; Name: string }

type ActivePbsStatus =
    | Open
    | Defined
    | Setup
    | Prototyped
    | Accepted
    | Closed
    
type InactivePbsStatus =
    | Replaced
    | ToDelete
    | Cancelled


[<RequireQualifiedAccess>]
type PbsStatus =
    | Active of ActivePbsStatus
    | Inactive of InactivePbsStatus

type Pbs =
    { Id: Guid
      PbsStatus: PbsStatus
      Name: string
      NameOnly: string
      Code: string
      PbsCode: string
      Description: string
      DescriptionCustomer: string option
      SortKey: string
      Level: int
      ModifiedOn: string
      ModifiedBy: XrmEntityReference option
      Role: XrmEntityReference option
      ProjectService: XrmEntityReference option
      ProjectServiceModule: XrmEntityReference option
      AssignedToCustomer: XrmEntityReference option
      AssignedTo: XrmEntityReference option
      ParentPbsId: Guid option
      OpenRequestsCount: int
      TotalRequestsCount: int }
