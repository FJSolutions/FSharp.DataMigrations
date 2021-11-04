namespace FSharp.Data.Migrations

open System.IO
open System.Reflection

module internal Internal =

  let normalizePath (path:string) =
    let (+/) path1 path2 = Path.Combine [| path1; path2|]
    let basePath = 
      match Path.IsPathRooted path with
      | true -> path
      | false -> 
          let p = (Assembly.GetEntryAssembly ()).Location
                  |> Directory.GetParent
                  |> string
          p +/ path

    Path.GetFullPath basePath

  let checkScriptFolderExists (path:string) =
    match Directory.Exists path with
    | true -> Ok (DirectoryInfo path)
    | false -> Error $"The scripts folder (%s{path}) doesn't exist!"

  let getScriptFiles (folder:DirectoryInfo) : Result<string list, _> =
    folder.GetFiles("*.sql")
    |> Array.toList
    |> List.sortBy (fun f -> f.Name)
    |> List.map (fun f -> f.Name)
    |> Ok

  let logWriter (writer:TextWriter) (message:string) =
    let writer = if not (isNull writer) then writer else TextWriter.Null
    writer.WriteLine message