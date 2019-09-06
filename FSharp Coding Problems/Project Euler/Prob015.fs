module PE_Prob015

//Starting in the top left corner of a 2×2 grid, and only being able to move to the right and down, there are exactly 6 routes to the bottom right corner.

//How many such routes are there through a 20×20 grid?

// 1x1 -> v(04) -> 2
// 2x2 -> v(09) -> 6
// 3x3 -> v(16) -> 22

// f(n) = f(n-1) + n*2

//  +--+--+--+
//  +--+--+--+
//  +--+--+--+
//  +--+--+--+

let addLayer prev n =
    prev + n*2

let solution n =
    [2..n]
    |> List.fold addLayer 2
