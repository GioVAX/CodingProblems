module EulerProb015

//Starting in the top left corner of a 2×2 grid, and only being able to move to the right and down, there are exactly 6 routes to the bottom right corner.

//How many such routes are there through a 20×20 grid?

let computeNext row =
    row
    |> List.scan (+) 0I
    |> List.tail

let solution n =
    let rec loop row = function
    | 0 -> row
    | n -> loop (computeNext row) (n - 1)

    // grid of n squares -> n+1 vertices!!!
    let firstRow = List.init (n+1) (fun _ -> 1I)
    let res = loop firstRow n
    res |> List.last