module EulerProb017

// If the numbers 1 to 5 are written out in words: one, two, three, four, five, then there are 3 + 3 + 5 + 4 + 4 = 19 letters used in total.

// If all the numbers from 1 to 1000 (one thousand) inclusive were written out in words, how many letters would be used?


// NOTE: Do not count spaces or hyphens. For example, 342 (three hundred and forty-two) contains 23 letters and 115 (one hundred and fifteen) contains 20 letters. 
// The use of "and" when writing out numbers is in compliance with British usage.

let map = Map.ofList [
     (0, "");
     (1, "one");
     (2, "two");
     (3, "three");
     (4, "four");
     (5, "five");
     (6, "six");
     (7, "seven");
     (8, "eight");
     (9, "nine");
     (10, "ten");
     (11, "eleven");
     (12, "twelve");
     (13, "thirteen");
     (14, "fourteen");
     (15, "fifteen");
     (16, "sixteen");
     (17, "seventeen");
     (18, "eighteen");
     (19, "nineteen");
     (20, "twenty");
     (30, "thirty");
     (40, "forty");
     (50, "fifty");
     (60, "sixty");
     (70, "seventy");
     (80, "eighty");
     (90, "ninety");
     ]

let split n b =
     (n/b,n%b)

let rec toLetters = function
     | n when n < 21 ->
          map.[n]
     | n when n = 1000 -> "one thousand"
     | n when n < 100 ->
          let (tens, units) = split n 10
          map.[tens*10]+"-"+map.[units]
     | n when n < 1000 ->
          match split n 100 with
          | (h, 0) -> map.[h]+" hundred"
          | (hundreds, rest) -> map.[hundreds]+" hundred and "+(toLetters rest)
     | n -> failwith $"unknown number {n}"

let normalize (s:string) =
     s.Replace("-", "").Replace(" ", "")

let solution n =
     [1..n]
     |> List.map (toLetters >> normalize)
     |> List.sumBy (String.length >> bigint)