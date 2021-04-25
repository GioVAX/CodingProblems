module CoinChange

let CoinSizes = [1; 2; 5; 10; 50]

let customChange (sizes:int list) (amount:int) : int list =
    []

let change amount = customChange CoinSizes amount