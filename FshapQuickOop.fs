// test oop concept
// http://blogs.msdn.com/b/timng/archive/2010/04/05/f-object-oriented-programming-quick-guide.aspx

module Default = 
    // class with properties and default constructor
    type Vector(x: float, y:float) =
        member this.X = x
        member this.Y = y

    let v = Vector(10., 10.)
    let x = v.X
    let y = v.Y

module Structure =
    // structure with properites
    [<Struct>]
    type Vector(x: float, y: float) =
        member this.X = x
        member this.Y = y

    let v = Vector(10., 10.)
    let x = v.X
    let y = v.Y

module MultipleContstructor =
    // multiple constructor
    type Vector(x:float, y:float) =
        member this.X = x
        member this.Y = y

        new(v: Vector,s) = Vector(v.X * s, v.Y * y)

    let v = Vector(10., 10.)
    let w = new Vector(v, 0.5)

module MemberFunction = 
    // member function
    type Vector(x,y) =
        member this.Scale(s) =
            Vector(x * s, y * s)

    let v = Vector(10.,10.)
    let v2 = v.Scale(0.5)


module Operator =
    // operator
    type Vector(x,y) =
        member this.X = x
        member this.Y = y
        static member (*)(a: Vector, b: Vector) =
            a.X * b.X + a.Y * b.Y

    let x = Vector(2., 2.)
    let y = Vector(3., 3.)
    let dp = x * y


module StaticMemberAndProperty = 
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


module ConstructorComputation = 
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


module PrivateFunction = 
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


module OverloadingMember =
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


module MutableProperty = 
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
    let len1 = v.Length
    v.X <- 0.
    v.Y <- 0.
    let len2 = v.Length


// generic class and functional aguments
module GenericClass = 
    type Factory<'T>(f: unit -> 'T) = 
        member this.Create() =
            f()


    let strings = Factory<string>(fun() -> "Hello!")
    let res = strings.Create()
    let ints = Factory<int>(fun () -> 10)
    let res2 = ints.Create()

// Extensioni method
module GenericClassAndMethod =
    type List<'T> with
        member this.MyExtensionMethod() =
            this |> Seq.map (fun a -> a.ToString())

    let c = [1;2;3;4]
    let d = c.MyExtensionMethod()



// Expression property
module ExtensionProperty =
    type List<'T> with
        member this.MyExtensionProp =
            this |> Seq.map (fun a -> a.ToString())

    let c = [1;2;3] 
    let d = c.MyExtensionProp

// Indexers
module Indexers =
    type Table() =
        member this.Item
            with get(key: string) = int key

    let tab = Table()
    let x = tab.["10"]
    let y = tab.["12"]

// Indexed properties
module IndexedProperties = 
    type Table() =
        member this.Values 
            with get(key: string) = int key
        member this.MultipleValues
            with get(key1, key2) = key1 + key2

    let tab = Table()
    let x = tab.Values("10")
    let y = tab.Values("12")
    let a = tab.MultipleValues(10, 5)

// Abstract class
module AbstractClass =
    [<AbstractClass>]
    type Shape() =
        abstract Name: string with get
        abstract Scale: float -> Shape


// Derive from base class and overrideing base methods
// with generics
module DeriveFromBaseClass = 
    [<AbstractClass>]
    type Shape<'T>() =
        abstract Name: string with get
        abstract Scale: float -> 'T

    type Vector(angle, mag) =
        inherit Shape<Vector>()
        member this.Angle = angle
        member this.Mag = mag
        override this.Name = "Vector"
        override this.Scale(factor) =
            Vector(angle, mag * factor)


    let v = Vector(45., 10.)
    let v2 = v.Scale(0.5)

// call base class method ...
module CallingBaseClassMethod =
    type Animal() =
        member this.Rest() = ()
    
    type Dog() =
        inherit Animal()
        member this.Run() = base.Rest()

    let brain =  Dog() 
    brain.Run()

 
// implement and interface
module ImplementAndInterface =
    type IVector =
        abstract Mag: double with get
        abstract Scale: float -> IVector


    type Vector(x, y) =
        interface IVector with
            member this.Mag = sqrt(x * x + y * y)
            member this.Scale(s) =
                Vector(x * s, y * s) :> IVector
        member this.X = x
        member this.Y = y


    let v = new Vector(1., 2.) :> IVector
    let mag1 = v.Mag
    let w = v.Scale(0.5)
    let mag2 = w.Mag

// implement interface with object expression
module ImplementInterfaceWithObjectExpression =
    type ICustomer =
        abstract Name: string with get
        abstract Age: int with get

    let CreateCustomer name age =
        { new ICustomer with
                member this.Name = name
                member this.Age = age }

    let c = CreateCustomer "Snoopy" 16
    let d = CreateCustomer "Gargield" 5

// event
module Event =

    open System

    type BarkArgs(msg: string) =
        inherit EventArgs()
        member this.Message = msg

    type BarkDelegate = delegate of obj * BarkArgs -> unit

    type Dog() =
        let ev = new Event<BarkDelegate, BarkArgs>()
        member this.Bark(msg)  = ev.Trigger(this, new BarkArgs(msg))

        [<CLIEvent>]
        member this.OnBark = ev.Publish


    let snoopy = new Dog()
    snoopy.OnBark.Add (fun ba -> printfn "%s" ba.Message)
    snoopy.Bark "Hello"


// explicit class constructor
module ExplicitClass =
    type Vector =
        val mutable x: float
        val mutable y: float
        new() = { x = 0. ; y = 0.}

    let v = Vector()
    v.x <- 10.
    v.y <- 10.



// explict public field
module ExplicitPublicField =

    type Vector() =
        [<DefaultValue()>]
        val mutable x: int

        [<DefaultValue()>]
        val mutable y: int

    let v = Vector()
    v.x <- 10
    v.y <- 10


// explicit struct definition
module ExplicitStuctDefinition =
    [<Struct>]
    type Vector =
        val mutable public x: int
        val mutable public y: int


    let mutable v = Vector()
    v.x <- 10
    v.y <- 10

