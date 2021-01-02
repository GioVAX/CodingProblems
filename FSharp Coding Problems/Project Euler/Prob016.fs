module EulerProb016

// 215 = 32768 and the sum of its digits is 3 + 2 + 7 + 6 + 8 = 26.

// What is the sum of the digits of the number 21000?

let solution n =
     2I ** n 
     |> string
     |> Seq.map (int >> ((+) -48)) 
     |> Seq.reduce (+)