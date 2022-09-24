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
