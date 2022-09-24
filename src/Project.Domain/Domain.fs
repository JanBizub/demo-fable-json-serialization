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

// ---------------------------------------------------------------------------------------------------------------------
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
    
    
// ---------------------------------------------------------------------------------------------------------------------
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
    
// ---------------------------------------------------------------------------------------------------------------------
type PbsMenuItem =
    { Id: Guid
      Level: int
      Name: string
      Code: string
      OpenRequestsCount: int
      TotalRequestsCount: int }

module PbsMenuItem =
    let fromPbs (pbs: Pbs) =
        { Id = pbs.Id
          Level = pbs.Level
          Name = pbs.Code + " " + pbs.NameOnly
          Code = pbs.Code
          OpenRequestsCount = pbs.OpenRequestsCount
          TotalRequestsCount = pbs.TotalRequestsCount }

type PbsMenu =
    { Parent: PbsMenuItem
      mutable Children: PbsMenu list }
    
[<RequireQualifiedAccess>]
module PbsOperations =
    let createMenu (menuItems: PbsMenuItem list) =
        let menuFolder (menuRoot: PbsMenu) (pbs: PbsMenuItem) =
            let rec lastParentMenuNodeForPbs (itemToAdd: PbsMenuItem) (tree: PbsMenu) =
                match tree with
                | node when (node.Parent.Level = itemToAdd.Level - 1) -> node
                | node when (node.Children.Length <> 0) ->
                    lastParentMenuNodeForPbs itemToAdd (node.Children |> List.last)
                | _ -> tree

            let addMenuNode (menuRoot: PbsMenu) (pbs: PbsMenuItem) =
                let parent =
                    lastParentMenuNodeForPbs pbs menuRoot

                parent.Children <-
                    parent.Children
                    @ [ { Parent = pbs; Children = [] } ]

                menuRoot

            pbs |> addMenuNode menuRoot

        let rootMenuElement =
            { Parent =
                { Id = Guid.Empty
                  Level = 0
                  Name = "root"
                  Code = "root"
                  OpenRequestsCount = 0
                  TotalRequestsCount = 0 }
              Children = [] }

        menuItems |> List.fold menuFolder rootMenuElement