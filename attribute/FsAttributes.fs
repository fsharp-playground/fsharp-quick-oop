namespace IO

open System.IO

type Stdin = { Stream: TextReader }
type Error = Exception

[<RequireQualifiedAccess>]
module IO =
    let stdin() = ()

[<AutoOpen>]
module IOExts =
    type Stdin with
        member this.ReadLine x = ()




