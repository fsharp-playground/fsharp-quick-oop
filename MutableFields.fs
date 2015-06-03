


















// C#
public class MutableVector
{
    public MutableVector(double x, double y)
    {
        this.X = x;
        this.Y = y;
    }
    public double X { get; set; }
    public double Y { get; set; }
    public double Length
    {
        get { return Math.Sqrt( this.X * this.X + this.Y * this.Y); }
    }
}

// F#
type MutableVector(x : float, y : float) =
    let mutable cx = x
    let mutable cy = y
    member this.X with get() = cx and set(v) = cx <- v
    member this.Y with get() = cy and set(v) = cy <- v
    member this.Length = sqrt(x * x + y * y)

let v = MutableVector(2., 2.)
let len1 = v.Length
v.X <- 0.
v.Y <- 0.
let len2 = v.Length
