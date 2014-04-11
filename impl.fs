module impl


let makeGuess (guessHistory:list<string*string>) =
    
    let lastGuessEntry = guessHistory.[(List.length guessHistory) - 1]
    if (snd lastGuessEntry) = "++++"
    then ""
    else 
        let chr = (fst lastGuessEntry).[3]
        let newChr = chr + (char)1
        if newChr > 'F'
        then ""
        else "AAA" + newChr.ToString()
        
            

        

