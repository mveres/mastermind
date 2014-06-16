module program

open System
open impl

[<EntryPoint>]
let main args =
    initializeGuesses ()
    let mutable guess = makeNextGuess "" ""

    while (true) do
        printfn "Is ths it? %s" guess
        printfn "Your feedback:"
        let feedback = Console.ReadLine()
        guess <- makeNextGuess guess feedback

    0
