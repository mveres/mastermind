module impl

open System.Collections.Generic

let guesses:List<string> = new List<string> ()

let initializeGuesses () =
    guesses.Clear()
    let ms = ["A";"B";"C";"D";"E";"F"]
    for m1 in ms do
        for m2 in ms do
            for m3 in ms do
                for m4 in ms do
                    guesses.Add(m1+m2+m3+m4)


let isGuessPossible feedback previousGuess guess =
    
    //let intersectionCount = Set.intersect (Set.ofSeq previousGuess) (Set.ofSeq guess) |> Set.count

    let rec intersection (prevGuessArray: char array, guessSeq: char list):char list =
        
        match guessSeq with
        | [] -> []
        | hg :: tg -> let idx = Array.tryFindIndex ((=) hg) prevGuessArray
                      match idx with
                      |Some i -> 
                              prevGuessArray.[i] <- '_'
                              hg :: (intersection (prevGuessArray,tg))
                      |None -> intersection (prevGuessArray,tg)
        
    let inter = (intersection ((Array.ofSeq previousGuess),(List.ofSeq guess)))

    let intersectionCount = List.length inter

    if intersectionCount = 4 then false
    else
        match feedback with
        |"" -> intersectionCount = 0
        |"-" -> intersectionCount = 1
        |_ -> intersectionCount < 4

let filterPossibleGuesses feedback previousGuess =
    let possibleGuesses =
        guesses
        |> List.ofSeq
        |> List.filter (isGuessPossible feedback previousGuess)

    guesses.Clear()
    guesses.AddRange(possibleGuesses)
    guesses

let getNextGuess previousGuess feedback =
    filterPossibleGuesses feedback previousGuess
    |> Seq.head
        

