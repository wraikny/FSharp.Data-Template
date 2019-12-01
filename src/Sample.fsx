#load "./FSharp.Data.fsx"

type GitHub = FSharp.Data.JsonProvider<"https://api.github.com/repos/fsharp/FSharp.Data/issues">

(*
GitHub.GetSamples()
|> Seq.filter (fun x -> x.State = "open")
|> Seq.truncate 5
|> Seq.map(fun x -> sprintf "#%d: %s" x.Number x.Title)
|> String.concat "\n"
|> printfn "%s"
*)

let printIssues n (x : GitHub.Root []) =
  x |> Seq.filter (fun x -> x.State = "open")
    |> Seq.truncate n
    |> Seq.map(fun x -> sprintf "#%d: %s" x.Number x.Title)
    |> String.concat "\n"
    |> printfn "%s"

GitHub.GetSamples() |> printIssues 3
printfn ""

GitHub.Load("https://api.github.com/repos/AmusementCreators/WebSite/issues")
|> printIssues 7
