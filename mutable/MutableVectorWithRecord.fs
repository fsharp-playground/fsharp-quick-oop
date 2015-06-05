

module MyVector1 =
    type Vector = { X: float; Y: float }


    //[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
    module Vectors =
        let length v = sqrt(v.X * v.X + v.Y * v.Y)

    let v = { X = 2.; Y = 2. }
    let len1 = v |> Vectors.length
    let v2 = { X = 3.; Y = 3. }
    // F# support การทำ variable shadowing
    //สำหรับบางกรณีที่ต้องการเปลี่ยนบาง property ใชั record expression ได้
    // let v = { v with Y = 5 }
    let len2 = v2 |> Vectors.length


