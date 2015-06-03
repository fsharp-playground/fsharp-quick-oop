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
    static member (**)(a: Vector, b: Vector) =
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


// class property that user let value computations
// in the constructor
open System

type Vector(x,y) =
    let mag = sqrt(x * x + y * y)
    let rad = if x = 0. && y = 0. then 0.
              else if x >= 0. then asin(y/mag)
              else (-1. * asin(y/mag)) + Math.PI

    member this.Mag = mag
    member this.Rad = rad

let v = Vector(10., 10.)
let mag = v.Mag
let rad = v.Rad

// class member this use private function values
type Vector(x,y) =
    let rotate a =
        let x' = x * cos a - y * sin a
        let y' = y * sin a + y * cos a
        new Vector(x', y')

    member this.RotateByDegrees(d) =
        rotate (d * Math.PI / 180.)

    member this.RotateByRadians(r) =
        rotate r

let v = Vector(10., 0.)
let x = v.RotateByDegrees(90.)
let y = v.RotateByRadians(Math.PI / 6.)


// overloading members
type Car() =
    member this.Drive() =
        this.Drive(10)
        ()
    member this.Drive(mph:int) =
        ()

let c = Car()
c.Drive()
c.Drive(10)

// multiple fields in a class with get/set properties
// not make sense
// no length change after modify x and y

type MutableVector(x : float, y : float) =
    let mutable cx = x
    let mutable cy = y
    member this.X with get() = cx and set(v) = cx <- v
    member this.Y with get() = cy and set(v) = cy <- v
    member this.Length = sqrt(cx * cx + cy * cy)

// Usage:
let v = MutableVector(2., 2.)
v.Length
v.X <- 0.
v.Y <- 0.
v.Length


