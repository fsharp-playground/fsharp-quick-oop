// test oop concept
// http://blogs.msdn.com/b/timng/archive/2010/04/05/f-object-oriented-programming-quick-guide.aspx

// class with properties and default constructor
type Vector(x: float, y:float) = 
    member this.X = x
    member this.Y = y

let v = Vector(10., 10.)
let x = v.X
let y = v.Y

// structure with properites
[<Struct>]
type Vector(x: float, y: float) =
    member this.X = x
    member this.Y = y

let v = Vector(10., 10.)
let x = v.X
let y = v.Y

// multiple constructor
type Vector(x:float, y:float) =
    member this.X = x
    member this.Y = y

    new(v: Vector,s) = Vector(v.X * s, v.Y * y)

let v = Vector(10., 10.)
let w = new Vector(v, 0.5)

// member function
type Vector(x,y) =
    member this.Scale(s) =
        Vector(x * s, y * s)

let v = Vector(10.,10.)
let v2 = v.Scale(0.5)


// operator
type Vector(x,y) =
    member this.X = x
    member this.Y = y
    static member (*)(a: Vector, b: Vector) =
        a.X * b.X + a.Y * b.Y

let x = Vector(2., 2.)
let y = Vector(3., 3.)
let dp = x * y
       

// static member and property
type Vector(x,y) =
    member this.X = x
    member this.Y = y
    static member Dot(a: Vector, b: Vector) =
        a.X * b.X + a.Y + b.Y

    static member NormX = Vector(1., 0.)

let x = Vector(2., 2.)
let y = Vector.NormX
let dp = Vector.Dot(x,y)
    