module CoinChange

let standardCoinSizes = [1; 2; 5; 10; 50]

let append coin =
    List.map (fun l -> coin::l)

let generateAllChanges previousIteration newCoin =
    previousIteration
    |> Map.fold
        (fun (currentIteration: Map<int, int list list>) amnt oldChanges ->
            let newChanges = 
                match (amnt, oldChanges) with
                | (amount, _) when amount < newCoin -> 
                    oldChanges
                | (_, [[]]) -> 
                    append newCoin currentIteration.[amnt - newCoin]
                | _ ->
                    let withNewCoin = append newCoin currentIteration.[amnt - newCoin]
                    List.append withNewCoin oldChanges

            currentIteration 
                |> Map.add amnt newChanges
        )
        Map.empty

let leastCoins l =
    l
    |> List.sortBy List.length
    |> List.head

let customChange availableSizes amount =
    let initial = 
        [0..amount] |> List.fold (fun m i -> Map.add i ([[]]:int list list) m) Map.empty
    let changes = 
        availableSizes
        |> List.fold generateAllChanges initial
    changes.[amount]

let change amount = 
    customChange standardCoinSizes amount
    |> leastCoins