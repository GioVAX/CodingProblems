module PE_Prob009

// A Pythagorean triplet is a set of three natural numbers, a < b < c, for which,
//                              a^2 + b^2 = c^2
//
// For example, 3^2 + 4^2 = 9 + 16 = 25 = 5^2.
//
// There exists exactly one Pythagorean triplet for which a + b + c = 1000.
// Find the product abc.

let tripletsSumming tot =
    seq { for c in [tot-3 .. -1 .. 3] do
            for b in [tot-c .. -1 .. 2] do
                for a in [tot-c-b .. -1 .. 1] do
                    if a+b+c = tot && a <> b then
                        yield (float a, float b, float c)
    }

let isPythagorean (a, b, c) =
    (a ** 2.0) + (b ** 2.0) = (c**2.0)

let solution =
    let (a,b,c) = 
        1000 |> tripletsSumming 
            |> Seq.filter isPythagorean
            |> Seq.head
    a * b * c    
