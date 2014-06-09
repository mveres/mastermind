module tests

open FsUnit
open NUnit.Framework
open impl

[<SetUp>]
let setup () =
    initializeGuesses ()

[<Test>]
let ``"" witn "" should guess AAAA`` () =
    getNextGuess "" "" |> should equal "AAAA"

[<Test>]
let ``AAAA witn "" should guess BBBB`` () =
    getNextGuess "AAAA" "" |> should equal "BBBB"

[<Test>]
let ``BBBB witn "" should guess AAAA`` () =
    getNextGuess "BBBB" "" |> should equal "AAAA"

[<Test>]
let ``AAAA and BBBB witn "" should guess CCCC`` () =
    getNextGuess "AAAA" "" |> ignore
    getNextGuess "BBBB" "" |> should equal "CCCC"

[<Test>]
let ``AAAA witn "-" should guess ABBB`` () =
    getNextGuess "AAAA" "-" |> should equal "ABBB"

