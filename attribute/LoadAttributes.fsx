

#load "FsAttributes.fs"

open IO
open System.IO

// full qualify
let x = IO.stdin

// auto open
let k = { Stream = FileStream "hello.txt" }
k.ReadLine



