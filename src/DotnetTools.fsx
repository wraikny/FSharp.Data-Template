#load "./FSharp.Data.fsx"

type Config = FSharp.Data.JsonProvider<"../.config/dotnet-tools.json">

let data = Config.GetSample()

printfn "Version: %d" data.Version