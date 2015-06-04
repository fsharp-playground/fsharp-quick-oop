module MyVector2 =

    type Vector =
        { X:float; Y:float }
        member this.Length =  sqrt(this.X * this.X + this.Y * this.Y)

    let v = { X = 10.0; Y = 10.0 }
    let l = v.Length
