module PE_Prob004

// A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.
//
// Find the largest palindrome made from the product of two 3-digit numbers.

let products (topNum:int) = 
    [for a in topNum.. -1 ..2 do
        for b in topNum.. -1 ..2 do
            yield a*b]
    |> List.sortDescending    

let isNotPalyndrome num =
    let s = num |> string
    let rev = new string(Array.rev (s.ToCharArray()))
    s <> rev

let solution topNum =
    let pal = topNum 
                |> products 
                |> List.skipWhile isNotPalyndrome
                |> List.head
    pal |> int
