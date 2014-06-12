module impl

open System.Collections.Generic
open System

type Feedback (feedbackStr) =
    let feedback =
        let count chr = feedbackStr |> Seq.filter ((=) chr) |> Seq.length
        (count '-'),(count '+')

    member this.OffPosition = fst feedback
    member this.OnPosition = snd feedback


let guesses:List<string> = new List<string> ()

let initializeGuesses () =
    guesses.Clear()
    let ms = ["A";"B";"C";"D";"E";"F"]
    for m1 in ms do
        for m2 in ms do
            for m3 in ms do
                for m4 in ms do
                    guesses.Add(m1+m2+m3+m4)


let isGuessPossible (feedback:Feedback) prevGuess guess =

    let rec intersect (prevGuessArray: char array, guessList: char list):char list =
        
        match guessList with
        | [] -> []
        | hg :: tg -> let idx = Array.tryFindIndex ((=) hg) prevGuessArray
                      match idx with
                      |Some i -> 
                              prevGuessArray.[i] <- '_'
                              hg :: (intersect (prevGuessArray,tg))
                      |None -> intersect (prevGuessArray,tg)
        
    let generalIntersectionCount = (intersect ((Array.ofSeq prevGuess),(List.ofSeq guess))) 
                                   |> List.length

    let onPosition = (prevGuess, guess) ||> Seq.map2 (=) |> Seq.filter id |> Seq.length

    let offPosition = generalIntersectionCount - onPosition

    feedback.OffPosition = offPosition
    && feedback.OnPosition = onPosition


let filterPossibleGuesses feedback previousGuess =
    let possibleGuesses =
        guesses
        |> List.ofSeq
        |> List.filter (isGuessPossible feedback previousGuess)

    guesses.Clear()
    guesses.AddRange(possibleGuesses)
    guesses


let getNextGuess previousGuess feedbackStr =
    filterPossibleGuesses (Feedback feedbackStr) previousGuess
    |> Seq.head
        

