module MemoizeTests

open Xunit
open FsCheck
open FsCheck.Xunit

open Memoize

let factorial (n:PositiveInt) = [1..n.Get] |> List.reduce (*)
let slowFactorial (n:PositiveInt) = 
    async { do! Async.Sleep 500 } |> ignore
    [1..n.Get] |> List.reduce (*)

let duration f = 
    let timer = new System.Diagnostics.Stopwatch()
    timer.Start()
    f() |> ignore
    timer.ElapsedMilliseconds

[<Property>]
let ``memoize should return the same result as the underlying function`` (num) =
    let mem = memoize factorial
    mem num = factorial num

[<Property>]
let ``memoize for slow computation should run faster on second call`` (num:PositiveInt) =
    let mem = memoize slowFactorial
    let dur1 = duration (fun () -> mem num )
    let dur2 = duration (fun () -> mem num )
    dur1 > dur2