module TestDataGenerator

open FsCheck

open EightQueens

let sameColumnGenerator {Row=row; Col=col} =
    //Arb.Default.List<int32>()
    Arb.Default.Int32()
    |> Arb.filter ((<>) row)
    |> Arb.convert 
        (fun r -> { Row=r; Col=col }) 
        (fun {Row=r; Col=_} -> r )

let sameRowGenerator {Row=row; Col=col} =
    Arb.Default.Int32()
    |> Arb.filter ((<>) col)
    |> Arb.convert
        (fun c -> { Row=row; Col=c })
        (fun {Row=_; Col=c} -> c )

//let x' () = Random.newSeed() |> Random.stdRange(0,1) |> fst

let sameDiagonalGenerator {Row=row; Col=col} =
    let x () = Gen.elements [1; -1] |> Gen.sample 0 1 |> List.head
    Arb.Default.Int32()
    |> Arb.filter ((<>) 0)
    |> Arb.convert
        (fun n -> {Row=row + (n * x()); Col=col + (n * x())})
        (fun _ -> 1)

let nextTo {Row=row; Col=col} =
    [(-1,-1);(-1,0);(-1,1);
      (0,-1);        (0,1);
      (1,-1); (1,0); (1,1)]
    |> List.map (fun (dr,dc) -> {Row=row+dr; Col=col+dc})
    |> Gen.elements
    |> Arb.fromGen
