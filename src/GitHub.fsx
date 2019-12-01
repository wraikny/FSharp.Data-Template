#load "./FSharp.Data.fsx"
open System

type GitHub = FSharp.Data.JsonProvider<"https://api.github.com/repos/fsharp/FSharp.Data/issues">


let printLatestIssuesOf n s =
  let issues =
    GitHub.Load(sprintf "https://api.github.com/repos/%s/issues" s)
    |> Seq.filter (fun x -> x.State = "open")
    |> Seq.sortBy (fun x -> DateTimeOffset(DateTime.Now) - x.UpdatedAt)
    |> Seq.truncate n
    |> Seq.map (fun x -> sprintf "#%d %s" x.Number x.Title)
    |> Seq.toList

  issues
  |> String.concat "\n"
  |> printfn "%d Issues of %s\n%s\n" (min n issues.Length) s


"fsharp/FSharp.Data"
|> printLatestIssuesOf 5

"fsharp/fsharp"
|> printLatestIssuesOf 10

"AmusementCreators/WebSite"
|> printLatestIssuesOf 10