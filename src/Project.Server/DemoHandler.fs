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
        
let getPbs () =
    fun (next: HttpFunc) (ctx: HttpContext) ->
        task {
            let pbs =  {
                 Id = Guid.Empty
                 PbsStatus = PbsStatus.Active(ActivePbsStatus.Accepted)
                 Name = "Name of pbs"
                 NameOnly = "Descrioption of pbs"
                 Code = "CPY.CODE"
                 PbsCode = "Code of project"
                 Description = "Descriptop"
                 DescriptionCustomer = Some "Customer description"
                 SortKey = "xxx"
                 Level = 1
                 ModifiedOn = ""
                 ModifiedBy = None
                 Role = Some {Id = Guid.Empty; Name = "test"}
                 ProjectService= Some {Id = Guid.Empty; Name = "test"}
                 ProjectServiceModule = Some {Id = Guid.Empty; Name = "test"}
                 AssignedToCustomer= Some {Id = Guid.Empty; Name = "test"}
                 AssignedTo= Some {Id = Guid.Empty; Name = "test"}
                 ParentPbsId = None
                 OpenRequestsCount= 10
                 TotalRequestsCount = 11 }
            
            return! json pbs next ctx
        }
        
let getPbsMenu () =
        fun (next: HttpFunc) (ctx: HttpContext) ->
        task {
            let pbseMenuItems = [
                { Id = Guid.NewGuid(); Level = 1; Name = "Name"; Code = "Code"; OpenRequestsCount = 0; TotalRequestsCount = 0 }
                { Id = Guid.NewGuid(); Level = 2; Name = "Name"; Code = "Code"; OpenRequestsCount = 0; TotalRequestsCount = 0 }
                { Id = Guid.NewGuid(); Level = 2; Name = "Name"; Code = "Code"; OpenRequestsCount = 0; TotalRequestsCount = 0 }
                { Id = Guid.NewGuid(); Level = 3; Name = "Name"; Code = "Code"; OpenRequestsCount = 0; TotalRequestsCount = 0 }
                { Id = Guid.NewGuid(); Level = 3; Name = "Name"; Code = "Code"; OpenRequestsCount = 0; TotalRequestsCount = 0 }
                { Id = Guid.NewGuid(); Level = 2; Name = "Name"; Code = "Code"; OpenRequestsCount = 0; TotalRequestsCount = 0 }
                { Id = Guid.NewGuid(); Level = 3; Name = "Name"; Code = "Code"; OpenRequestsCount = 0; TotalRequestsCount = 0 }
                { Id = Guid.NewGuid(); Level = 4; Name = "Name"; Code = "Code"; OpenRequestsCount = 0; TotalRequestsCount = 0 }
                { Id = Guid.NewGuid(); Level = 2; Name = "Name"; Code = "Code"; OpenRequestsCount = 0; TotalRequestsCount = 0 }
            ]
            
            let pbsMenu = PbsOperations.createMenu pbseMenuItems
            
            return! json pbsMenu next ctx
        }
